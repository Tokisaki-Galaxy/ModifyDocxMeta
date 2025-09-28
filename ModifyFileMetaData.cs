using System;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;

namespace ModifyTotalEditingTime
{
    struct DocMetadata
    {
        public bool Edit;
        public bool Overwrite;
        public int TotalEditor;
        public string Creator;
        public string LastModifiedBy;
        public DateTime CreatedDate;
        public DateTime LastChangedDate;
    }

    // 实现 IDisposable 接口
    // 这是管理临时文件目录等非托管资源的正确方式
    internal class ModifyFileMetaData : IDisposable
    {
        private string filePath;
        private string tempDir;
        private XDocument appdoc;
        private XDocument coredoc;
        private DocMetadata metadata;
        private bool disposed = false; // 用于跟踪对象是否已被释放

        // 读写xml的命名空间
        static XNamespace ns = "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties";
        static XNamespace cp = "http://schemas.openxmlformats.org/package/2006/metadata/core-properties";
        static XNamespace dcterms = "http://purl.org/dc/terms/";
        static XNamespace dc = "http://purl.org/dc/elements/1.1/";

        // 将构造函数改为静态工厂方法，并添加全面的错误处理
        // 这种模式（TryCreate）可以更好地处理可能失败的初始化过程
        public static ModifyFileMetaData TryCreate(string filePath, out string errorMessage)
        {
            try
            {
                var instance = new ModifyFileMetaData(filePath);
                errorMessage = null;
                return instance;
            }
            catch (Exception ex)
            {
                // 捕获所有可能的初始化异常，并返回一个友好的错误信息
                errorMessage = $"Unable to load file '{Path.GetFileName(filePath)}' Error: {ex.Message}";
                // 可以根据需要记录完整的异常信息 ex.ToString() 到日志文件中
                return null;
            }
        }

        // 将构造函数设为私有，强制通过 TryCreate 方法创建实例
        private ModifyFileMetaData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file does not exist.", filePath);
            }
            this.filePath = filePath;

            // 生成临时文件目录
            tempDir = Path.Combine(Path.GetTempPath(), "ModifyDocxMeta_" + Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);

            // 解压Docx文件
            try
            {
                ZipFile.ExtractToDirectory(filePath, tempDir);
            }
            catch (InvalidDataException)
            {
                // 如果文件不是有效的zip格式，捕获并抛出更具体的异常
                throw new InvalidDataException("The file is corrupted or not a valid. docx file.");
            }
            // 其他 IOException 等异常会自然冒泡上去

            // 加载XML文件，并检查是否存在
            string appXmlPath = Path.Combine(tempDir, "docProps/app.xml");
            string coreXmlPath = Path.Combine(tempDir, "docProps/core.xml");

            if (!File.Exists(appXmlPath) || !File.Exists(coreXmlPath))
            {
                throw new FileNotFoundException("This is an invalid. docx file, and the core property file is missing.");
            }

            appdoc = XDocument.Load(appXmlPath);
            coredoc = XDocument.Load(coreXmlPath);

            // 初始化元数据，现在这些Get方法是安全的
            metadata.TotalEditor = Convert.ToInt32(GetTotalEditingTime() ?? "0"); // 如果为null，默认值为0
            metadata.CreatedDate = GetCreatedDate() ?? DateTime.Now;
            metadata.Creator = GetCreator() ?? string.Empty;
            metadata.LastChangedDate = GetLastChangedDate() ?? DateTime.Now;
            metadata.LastModifiedBy = GetLastModifiedBy() ?? string.Empty;
        }

        ~ModifyFileMetaData()
        {
            // 这个析构函数只是一个安全网，调用 Dispose(false)
            // 正常情况下，它不应该被执行
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // 通知GC不要再调用析构函数
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // 仅当 disposing 为 true 时，才释放托管资源（如果存在）
                // 这里没有托管资源需要释放

                // 总是释放非托管资源（临时文件）
                if (Directory.Exists(tempDir))
                {
                    try
                    {
                        Directory.Delete(tempDir, true);
                    }
                    catch (IOException)
                    {
                        // 忽略删除失败的情况，这通常不会发生，但如果发生也不应让程序崩溃
                    }
                }
                disposed = true;
            }
        }

        public void SetOverwrite(bool overwrite)
        {
            metadata.Overwrite = overwrite;
        }

        // 使用空条件运算符 (?.)，如果链条中任何一部分为 null，整个表达式返回 null
        public string GetTotalEditingTime()
        {
            return appdoc.Root?.Element(ns + "TotalTime")?.Value;
        }

        public void ModifyTotalEditingTime(int targetTime)
        {
            metadata.Edit = true;
            metadata.TotalEditor = targetTime;
        }

        public string GetCreator()
        {
            return coredoc.Root?.Element(dc + "creator")?.Value;
        }

        public void ModifyCreator(string targetCreator)
        {
            metadata.Edit = true;
            metadata.Creator = targetCreator;
        }

        public string GetLastModifiedBy()
        {
            return coredoc.Root?.Element(cp + "lastModifiedBy")?.Value;
        }

        public void ModifyLastModifiedBy(string targetLastModifiedBy)
        {
            metadata.Edit = true;
            metadata.LastModifiedBy = targetLastModifiedBy;
        }

        public DateTime? GetCreatedDate() // 返回可空类型 DateTime?
        {
            var dateStr = coredoc.Root?.Element(dcterms + "created")?.Value;
            if (string.IsNullOrEmpty(dateStr))
                return null;
            return StringToDate(dateStr);
        }

        public void ModifyCreatedDate(DateTime targetCreatedDate)
        {
            metadata.Edit = true;
            metadata.CreatedDate = targetCreatedDate;
        }

        public DateTime? GetLastChangedDate() // 返回可空类型 DateTime?
        {
            var dateStr = coredoc.Root?.Element(dcterms + "modified")?.Value;
            if (string.IsNullOrEmpty(dateStr))
                return null;
            return StringToDate(dateStr);
        }

        public void ModifyLastChangedDate(DateTime targetLastChangedDate)
        {
            metadata.Edit = true;
            metadata.LastChangedDate = targetLastChangedDate;
        }

        // 让 Save 方法返回一个结果对象，而不是 bool，并添加错误处理
        // 这样UI层可以知道是成功还是失败，以及失败的原因
        public (bool Success, string Message) Save()
        {
            if (!metadata.Edit)
            {
                return (false, "No changes have been made.");
            }

            try
            {
                // 安全地修改或创建 XML 元素
                EnsureAndSetElementValue(appdoc.Root, ns + "TotalTime", metadata.TotalEditor.ToString());
                appdoc.Save(Path.Combine(tempDir, "docProps/app.xml"));

                EnsureAndSetElementValue(coredoc.Root, dc + "creator", metadata.Creator);
                EnsureAndSetElementValue(coredoc.Root, cp + "lastModifiedBy", metadata.LastModifiedBy);
                EnsureAndSetElementValue(coredoc.Root, dcterms + "created", DateToString(metadata.CreatedDate));
                EnsureAndSetElementValue(coredoc.Root, dcterms + "modified", DateToString(metadata.LastChangedDate));
                coredoc.Save(Path.Combine(tempDir, "docProps/core.xml"));

                string targetFilePath = filePath;
                if (!metadata.Overwrite)
                {
                    string dir = Path.GetDirectoryName(filePath);
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string ext = Path.GetExtension(filePath);
                    targetFilePath = Path.Combine(dir, $"{fileName}-modified{ext}");
                }

                // 在创建新文件前，如果目标文件已存在且是原文件（覆盖模式），先删除
                if (metadata.Overwrite && File.Exists(targetFilePath))
                {
                    File.Delete(targetFilePath);
                }

                ZipFile.CreateFromDirectory(tempDir, targetFilePath, CompressionLevel.Optimal, false);

                return (true, $"File '{Path.GetFileName(targetFilePath)}' Metadata modification succeeded！");
            }
            catch (Exception ex)
            {
                // 捕获所有保存时可能发生的异常
                return (false, $"Error saving file: {ex.Message}");
            }
        }

        // 辅助方法，确保元素存在并设置其值
        private void EnsureAndSetElementValue(XElement parent, XName elementName, string value)
        {
            var element = parent?.Element(elementName);
            if (element != null)
            {
                element.Value = value ?? string.Empty;
            }
            else if (parent != null)
            {
                // 如果元素不存在，则创建它
                parent.Add(new XElement(elementName, value ?? string.Empty));
            }
        }


        private DateTime StringToDate(string str)
        {
            return DateTime.Parse(str, null, System.Globalization.DateTimeStyles.RoundtripKind);
        }

        private String DateToString(DateTime date)
        {
            return date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
    }
}
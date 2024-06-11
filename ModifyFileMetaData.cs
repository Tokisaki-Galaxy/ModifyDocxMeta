using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;
using System.Windows.Forms;

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
    internal class ModifyFileMetaData
	{
		private string filePath;
		private string tempDir;
		private XDocument appdoc;
		private XDocument coredoc;
		private DocMetadata metadata;

		// 读写xml的命名空间
        static XNamespace ns = "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties";
        static XNamespace cp = "http://schemas.openxmlformats.org/package/2006/metadata/core-properties";
        static XNamespace dcterms = "http://purl.org/dc/terms/";
        static XNamespace dc = "http://purl.org/dc/elements/1.1/";

        public ModifyFileMetaData(string filePath)
		{
			if (File.Exists(filePath))
			{
				this.filePath = filePath;
			}
			else { throw new FileNotFoundException(); }

			// 生成临时文件目录
			tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			Directory.CreateDirectory(tempDir);

			// 解压Docx文件
			ZipFile.ExtractToDirectory(filePath, tempDir);
			appdoc = XDocument.Load(Path.Combine(tempDir, "docProps/app.xml"));
			coredoc = XDocument.Load(Path.Combine(tempDir, "docProps/core.xml"));
			metadata.TotalEditor = Convert.ToInt32(GetTotalEditingTime());
			metadata.CreatedDate = GetCreatedDate();
			metadata.Creator = GetCreator();
			metadata.LastChangedDate = GetLastChangedDate();
			metadata.LastModifiedBy = GetLastModifiedBy();
		}

		~ModifyFileMetaData()
		{
			Directory.Delete(tempDir,true);
		}

		public void SetOverwrite(bool overwrite)
        {
            metadata.Overwrite = overwrite;
        }

		public string GetTotalEditingTime()
		{
			// Get the total editing time
			return appdoc.Element(ns + "Properties").Element(ns + "TotalTime").Value;
		}

		public void ModifyTotalEditingTime(int targetTime)
		{
			// Modify the total editing time
			metadata.Edit = true;
			metadata.TotalEditor = targetTime;
		}

		public string GetCreator()
		{
			// Get the creator
			return coredoc.Element(cp + "coreProperties").Element(dc + "creator").Value;
		}

		public void ModifyCreator(string targetCreator)
		{
			// Modify the creator
			metadata.Edit = true;
			metadata.Creator = targetCreator;
		}

		public string GetLastModifiedBy()
		{
			// Get the last modified by
			return coredoc.Element(cp + "coreProperties").Element(cp + "lastModifiedBy").Value;
		}

		public void ModifyLastModifiedBy(string targetLastModifiedBy)
		{
			// Modify the last modified by
			metadata.Edit = true;
			metadata.LastModifiedBy = targetLastModifiedBy;
		}

		public DateTime GetCreatedDate()
		{
			// Get the created date
			return StringToDate(
				coredoc.Element(cp + "coreProperties").Element(dcterms + "created").Value);
		}

		public void ModifyCreatedDate(DateTime targetCreatedDate)
		{
			// Modify the created date
			metadata.Edit = true;
			metadata.CreatedDate = targetCreatedDate;
		}

		public DateTime GetLastChangedDate()
		{
			// Get the last changed date
			return StringToDate(
				coredoc.Element(cp + "coreProperties").Element(dcterms + "modified").Value);
		}

		public void ModifyLastChangedDate(DateTime targetLastChangedDate)
		{
			// Modify the last changed date
			metadata.Edit = true;
			metadata.LastChangedDate = targetLastChangedDate;
		}

		public bool Save()
		{
            if (metadata.Edit == true)
            {
                // 修改app.xml
                appdoc.Element(ns + "Properties").Element(ns + "TotalTime").Value = metadata.TotalEditor.ToString();
                appdoc.Save(Path.Combine(tempDir, "docProps/app.xml"));

                // 修改core.xml
                coredoc.Element(cp + "coreProperties").Element(dc + "creator").Value = metadata.Creator;
                coredoc.Element(cp + "coreProperties").Element(cp + "lastModifiedBy").Value = metadata.LastModifiedBy;
                coredoc.Element(cp + "coreProperties").Element(dcterms + "created").Value = DateToString(metadata.CreatedDate);
                coredoc.Element(cp + "coreProperties").Element(dcterms + "modified").Value = DateToString(metadata.LastChangedDate);
                coredoc.Save(Path.Combine(tempDir, "docProps/core.xml"));

                if (metadata.Overwrite)
                {
                    File.Delete(filePath);
                    ZipFile.CreateFromDirectory(tempDir, filePath);
                }
                else
                {
                    string originalFileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    string extension = Path.GetExtension(filePath);
                    string newFileName = originalFileNameWithoutExtension + "-已修改" + extension;
                    string newFilePath = Path.Combine(Path.GetDirectoryName(filePath), newFileName);
                    ZipFile.CreateFromDirectory(tempDir, newFilePath, CompressionLevel.Optimal, false);
                }
                MessageBox.Show('"' + Path.GetFileName(filePath) + '"' + "文件元数据修改成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
			return false;
        }

		public DateTime StringToDate(string str)
		{
			// Convert string to DateTime
			return DateTime.Parse(str, null, System.Globalization.DateTimeStyles.RoundtripKind);
		}

		public String DateToString(DateTime date)
		{
			// Convert DateTime to string
			return date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
		}
	}
}

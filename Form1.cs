using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ModifyTotalEditingTime
{
	public partial class Form1 : System.Windows.Forms.Form
	{
		public Form1()
		{
			InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void b_openfilepath_Click(object sender, EventArgs e)
		{
			// 打开文件选择框
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "";
			// openFileDialog.Filter = "Word Documents|*.doc;*.docx";
			openFileDialog.Filter = "Word Documents|*.docx";
            openFileDialog.RestoreDirectory = true;
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string filePath = openFileDialog.FileName;
				// 在这里使用filePath
				m_filePath.Clear();
				m_filePath.AppendText(filePath);
				// 打开文件
				b_openFile_Click(sender, e);
			}
		}

		private void b_ProcessFile_Click(object sender, EventArgs e)
		{
            // 创建实例
            ModifyFileMetaData modifyFileMetaData = ModifyFileMetaData.TryCreate(m_filePath.Text, out string errorMessage);

            // 同样，必须用 using 语句
            using (modifyFileMetaData)
            {
                if (modifyFileMetaData == null)
                {
                    MessageBox.Show(errorMessage, "Failed to process file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    modifyFileMetaData.ModifyTotalEditingTime(Convert.ToInt32(m_totaltime.Text));
                    modifyFileMetaData.ModifyCreator(m_creator.Text);
                    modifyFileMetaData.ModifyLastModifiedBy(m_lastModifiedBy.Text);
                    modifyFileMetaData.ModifyCreatedDate(DateTime.Parse(m_createdtime.Text));
                    modifyFileMetaData.ModifyLastChangedDate(DateTime.Parse(m_modifiedtime.Text));

                    modifyFileMetaData.SetOverwrite(m_isOverwrite.Checked);

                    // 调用新的 Save 方法并检查结果
                    var result = modifyFileMetaData.Save();
                    if (result.Success)
                    {
                        MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Save fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("The input format is incorrect. Please check the editor-in-chief time (should be a number) and date format. \n error：" + ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // 捕获其他所有未预料到的异常
                    MessageBox.Show("An unknown error occurred：" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // fileMetaData.Dispose() 会在这里被自动调用
        }

		private void b_openFile_Click(object sender, EventArgs e)
        {
            m_totaltime.Clear();
            m_createdtime.Clear();
            m_modifiedtime.Clear();
            m_creator.Clear();
			m_lastModifiedBy.Clear();
            // 使用新的 TryCreate 模式
            ModifyFileMetaData fileMetaData = ModifyFileMetaData.TryCreate(m_filePath.Text, out string errorMessage);

            // 必须用 using 语句来确保 Dispose 被调用，从而删除临时文件
            using (fileMetaData)
            {
                if (fileMetaData == null)
                {
                    MessageBox.Show(errorMessage, "Failed to open file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 现在可以安全地获取数据，因为构造函数已经成功
                m_totaltime.AppendText(fileMetaData.GetTotalEditingTime() ?? "0");
                m_creator.AppendText(fileMetaData.GetCreator() ?? "");
                m_lastModifiedBy.AppendText(fileMetaData.GetLastModifiedBy() ?? "");

                // 处理可能为 null 的日期
                DateTime? createdDate = fileMetaData.GetCreatedDate();
                m_createdtime.AppendText(createdDate.HasValue ? createdDate.Value.ToString() : "");

                DateTime? modifiedDate = fileMetaData.GetLastChangedDate();
                m_modifiedtime.AppendText(modifiedDate.HasValue ? modifiedDate.Value.ToString() : "");
            } // fileMetaData.Dispose() 会在这里被自动调用
        }
	}
}

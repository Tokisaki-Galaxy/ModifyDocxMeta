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
	public partial class Form1 : Form
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
			ModifyFileMetaData modifyFileMetaData = new ModifyFileMetaData(m_filePath.Text);
			try
			{
				modifyFileMetaData.ModifyTotalEditingTime(Convert.ToInt32(m_totaltime.Text));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			modifyFileMetaData.ModifyCreator(m_creator.Text);
			modifyFileMetaData.ModifyLastModifiedBy(m_lastModifiedBy.Text);

			modifyFileMetaData.ModifyCreatedDate(modifyFileMetaData.StringToDate(m_createdtime.Text));
			modifyFileMetaData.ModifyLastChangedDate(modifyFileMetaData.StringToDate(m_modifiedtime.Text));

			modifyFileMetaData.SetOverwrite(m_isOverwrite.Checked);
			modifyFileMetaData.Save();
		}

		private void b_openFile_Click(object sender, EventArgs e)
        {
            m_totaltime.Clear();
            m_createdtime.Clear();
            m_modifiedtime.Clear();
            m_creator.Clear();
			m_lastModifiedBy.Clear();
			try
			{
				ModifyFileMetaData FileMetaData = new ModifyFileMetaData(m_filePath.Text);
				m_totaltime.AppendText(FileMetaData.GetTotalEditingTime());
				m_creator.AppendText(FileMetaData.GetCreator());
				m_lastModifiedBy.AppendText(FileMetaData.GetLastModifiedBy());
				m_createdtime.AppendText(FileMetaData.GetCreatedDate().ToString());
				m_modifiedtime.AppendText(FileMetaData.GetLastChangedDate().ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
	}
}

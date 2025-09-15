namespace ModifyTotalEditingTime
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.b_ProcessFile = new System.Windows.Forms.Button();
            this.m_filePath = new System.Windows.Forms.TextBox();
            this.m_totaltime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_modifiedtime = new System.Windows.Forms.TextBox();
            this.m_createdtime = new System.Windows.Forms.TextBox();
            this.m_lastModifiedBy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_creator = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b_openfilepath = new System.Windows.Forms.Button();
            this.b_openFile = new System.Windows.Forms.Button();
            this.m_isOverwrite = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_ProcessFile
            // 
            resources.ApplyResources(this.b_ProcessFile, "b_ProcessFile");
            this.b_ProcessFile.Name = "b_ProcessFile";
            this.b_ProcessFile.UseVisualStyleBackColor = true;
            this.b_ProcessFile.Click += new System.EventHandler(this.b_ProcessFile_Click);
            // 
            // m_filePath
            // 
            resources.ApplyResources(this.m_filePath, "m_filePath");
            this.m_filePath.Name = "m_filePath";
            // 
            // m_totaltime
            // 
            resources.ApplyResources(this.m_totaltime, "m_totaltime");
            this.m_totaltime.Name = "m_totaltime";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_totaltime);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.m_modifiedtime);
            this.groupBox2.Controls.Add(this.m_createdtime);
            this.groupBox2.Controls.Add(this.m_lastModifiedBy);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.m_creator);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // m_modifiedtime
            // 
            resources.ApplyResources(this.m_modifiedtime, "m_modifiedtime");
            this.m_modifiedtime.Name = "m_modifiedtime";
            // 
            // m_createdtime
            // 
            resources.ApplyResources(this.m_createdtime, "m_createdtime");
            this.m_createdtime.Name = "m_createdtime";
            // 
            // m_lastModifiedBy
            // 
            resources.ApplyResources(this.m_lastModifiedBy, "m_lastModifiedBy");
            this.m_lastModifiedBy.Name = "m_lastModifiedBy";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // m_creator
            // 
            resources.ApplyResources(this.m_creator, "m_creator");
            this.m_creator.Name = "m_creator";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // b_openfilepath
            // 
            resources.ApplyResources(this.b_openfilepath, "b_openfilepath");
            this.b_openfilepath.Name = "b_openfilepath";
            this.b_openfilepath.UseVisualStyleBackColor = true;
            this.b_openfilepath.Click += new System.EventHandler(this.b_openfilepath_Click);
            // 
            // b_openFile
            // 
            resources.ApplyResources(this.b_openFile, "b_openFile");
            this.b_openFile.Name = "b_openFile";
            this.b_openFile.UseVisualStyleBackColor = true;
            this.b_openFile.Click += new System.EventHandler(this.b_openFile_Click);
            // 
            // m_isOverwrite
            // 
            resources.ApplyResources(this.m_isOverwrite, "m_isOverwrite");
            this.m_isOverwrite.Name = "m_isOverwrite";
            this.m_isOverwrite.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.b_ProcessFile;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_isOverwrite);
            this.Controls.Add(this.b_openFile);
            this.Controls.Add(this.b_openfilepath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_filePath);
            this.Controls.Add(this.b_ProcessFile);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_ProcessFile;
        private System.Windows.Forms.TextBox m_filePath;
        private System.Windows.Forms.TextBox m_totaltime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox m_creator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_openfilepath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_modifiedtime;
        private System.Windows.Forms.TextBox m_createdtime;
        private System.Windows.Forms.TextBox m_lastModifiedBy;
        private System.Windows.Forms.Button b_openFile;
        private System.Windows.Forms.CheckBox m_isOverwrite;
    }
}


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
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_ProcessFile
            // 
            this.b_ProcessFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_ProcessFile.Location = new System.Drawing.Point(305, 390);
            this.b_ProcessFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.b_ProcessFile.Name = "b_ProcessFile";
            this.b_ProcessFile.Size = new System.Drawing.Size(93, 33);
            this.b_ProcessFile.TabIndex = 0;
            this.b_ProcessFile.Text = "处理";
            this.b_ProcessFile.UseVisualStyleBackColor = true;
            this.b_ProcessFile.Click += new System.EventHandler(this.b_ProcessFile_Click);
            // 
            // m_filePath
            // 
            this.m_filePath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.m_filePath.Location = new System.Drawing.Point(54, 19);
            this.m_filePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_filePath.Name = "m_filePath";
            this.m_filePath.Size = new System.Drawing.Size(206, 27);
            this.m_filePath.TabIndex = 2;
            // 
            // m_totaltime
            // 
            this.m_totaltime.Location = new System.Drawing.Point(177, 33);
            this.m_totaltime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_totaltime.Name = "m_totaltime";
            this.m_totaltime.Size = new System.Drawing.Size(185, 27);
            this.m_totaltime.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_totaltime);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(386, 79);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "app.xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "总编辑时间";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_modifiedtime);
            this.groupBox2.Controls.Add(this.m_createdtime);
            this.groupBox2.Controls.Add(this.m_lastModifiedBy);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.m_creator);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBox2.Location = new System.Drawing.Point(12, 147);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(386, 232);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "core.xml";
            // 
            // m_modifiedtime
            // 
            this.m_modifiedtime.Location = new System.Drawing.Point(177, 177);
            this.m_modifiedtime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_modifiedtime.Name = "m_modifiedtime";
            this.m_modifiedtime.Size = new System.Drawing.Size(185, 27);
            this.m_modifiedtime.TabIndex = 11;
            // 
            // m_createdtime
            // 
            this.m_createdtime.Location = new System.Drawing.Point(177, 126);
            this.m_createdtime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_createdtime.Name = "m_createdtime";
            this.m_createdtime.Size = new System.Drawing.Size(185, 27);
            this.m_createdtime.TabIndex = 10;
            // 
            // m_lastModifiedBy
            // 
            this.m_lastModifiedBy.Location = new System.Drawing.Point(177, 78);
            this.m_lastModifiedBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_lastModifiedBy.Name = "m_lastModifiedBy";
            this.m_lastModifiedBy.Size = new System.Drawing.Size(185, 27);
            this.m_lastModifiedBy.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "最后一次保存的日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "创建内容日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "最后一个修改者";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "创建者";
            // 
            // m_creator
            // 
            this.m_creator.Location = new System.Drawing.Point(177, 30);
            this.m_creator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_creator.Name = "m_creator";
            this.m_creator.Size = new System.Drawing.Size(185, 27);
            this.m_creator.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label2.Location = new System.Drawing.Point(14, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "路径";
            // 
            // b_openfilepath
            // 
            this.b_openfilepath.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.b_openfilepath.Location = new System.Drawing.Point(268, 13);
            this.b_openfilepath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.b_openfilepath.Name = "b_openfilepath";
            this.b_openfilepath.Size = new System.Drawing.Size(34, 37);
            this.b_openfilepath.TabIndex = 1;
            this.b_openfilepath.Text = "...";
            this.b_openfilepath.UseVisualStyleBackColor = true;
            this.b_openfilepath.Click += new System.EventHandler(this.b_openfilepath_Click);
            // 
            // b_openFile
            // 
            this.b_openFile.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.b_openFile.Location = new System.Drawing.Point(308, 13);
            this.b_openFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.b_openFile.Name = "b_openFile";
            this.b_openFile.Size = new System.Drawing.Size(90, 37);
            this.b_openFile.TabIndex = 8;
            this.b_openFile.Text = "打开";
            this.b_openFile.UseVisualStyleBackColor = true;
            this.b_openFile.Click += new System.EventHandler(this.b_openFile_Click);
            // 
            // m_isOverwrite
            // 
            this.m_isOverwrite.AutoSize = true;
            this.m_isOverwrite.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_isOverwrite.Location = new System.Drawing.Point(14, 392);
            this.m_isOverwrite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_isOverwrite.Name = "m_isOverwrite";
            this.m_isOverwrite.Size = new System.Drawing.Size(106, 24);
            this.m_isOverwrite.TabIndex = 9;
            this.m_isOverwrite.Text = "覆盖原文件";
            this.m_isOverwrite.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 393);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "52pojie.cn sakura-galaxy";
            // 
            // Form1
            // 
            this.AcceptButton = this.b_ProcessFile;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 439);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_isOverwrite);
            this.Controls.Add(this.b_openFile);
            this.Controls.Add(this.b_openfilepath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_filePath);
            this.Controls.Add(this.b_ProcessFile);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ModifyDocxMeta";
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
        private System.Windows.Forms.Label label7;
    }
}


namespace xxEncryptTool
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
            this.richTextBoxLoadFile = new System.Windows.Forms.RichTextBox();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.richTextBoxEncryptFile = new System.Windows.Forms.RichTextBox();
            this.labelTips1 = new System.Windows.Forms.Label();
            this.labelTips2 = new System.Windows.Forms.Label();
            this.labelTips0 = new System.Windows.Forms.Label();
            this.labelTips3 = new System.Windows.Forms.Label();
            this.labelTips4 = new System.Windows.Forms.Label();
            this.buttonRecover = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxLoadFile
            // 
            this.richTextBoxLoadFile.Location = new System.Drawing.Point(48, 56);
            this.richTextBoxLoadFile.Name = "richTextBoxLoadFile";
            this.richTextBoxLoadFile.Size = new System.Drawing.Size(252, 270);
            this.richTextBoxLoadFile.TabIndex = 0;
            this.richTextBoxLoadFile.Text = "";
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLoadFile.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonLoadFile.Location = new System.Drawing.Point(48, 12);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(110, 38);
            this.buttonLoadFile.TabIndex = 2;
            this.buttonLoadFile.Text = "载入文件";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.ButtonLoadFile_Click);
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEncrypt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonEncrypt.Location = new System.Drawing.Point(372, 12);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(133, 38);
            this.buttonEncrypt.TabIndex = 4;
            this.buttonEncrypt.Text = "开始加密";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.ButtonEncrypt_Click);
            // 
            // richTextBoxEncryptFile
            // 
            this.richTextBoxEncryptFile.Location = new System.Drawing.Point(372, 56);
            this.richTextBoxEncryptFile.Name = "richTextBoxEncryptFile";
            this.richTextBoxEncryptFile.Size = new System.Drawing.Size(401, 270);
            this.richTextBoxEncryptFile.TabIndex = 3;
            this.richTextBoxEncryptFile.Text = "";
            // 
            // labelTips1
            // 
            this.labelTips1.AutoSize = true;
            this.labelTips1.Font = new System.Drawing.Font("宋体", 9F);
            this.labelTips1.Location = new System.Drawing.Point(46, 365);
            this.labelTips1.Name = "labelTips1";
            this.labelTips1.Size = new System.Drawing.Size(65, 12);
            this.labelTips1.TabIndex = 5;
            this.labelTips1.Text = "labelTips1";
            // 
            // labelTips2
            // 
            this.labelTips2.AutoSize = true;
            this.labelTips2.Font = new System.Drawing.Font("宋体", 9F);
            this.labelTips2.Location = new System.Drawing.Point(46, 386);
            this.labelTips2.Name = "labelTips2";
            this.labelTips2.Size = new System.Drawing.Size(65, 12);
            this.labelTips2.TabIndex = 6;
            this.labelTips2.Text = "labelTips2";
            // 
            // labelTips0
            // 
            this.labelTips0.AutoSize = true;
            this.labelTips0.Font = new System.Drawing.Font("宋体", 9F);
            this.labelTips0.Location = new System.Drawing.Point(46, 343);
            this.labelTips0.Name = "labelTips0";
            this.labelTips0.Size = new System.Drawing.Size(65, 12);
            this.labelTips0.TabIndex = 7;
            this.labelTips0.Text = "labelTips0";
            // 
            // labelTips3
            // 
            this.labelTips3.AutoSize = true;
            this.labelTips3.Font = new System.Drawing.Font("宋体", 9F);
            this.labelTips3.Location = new System.Drawing.Point(46, 408);
            this.labelTips3.Name = "labelTips3";
            this.labelTips3.Size = new System.Drawing.Size(65, 12);
            this.labelTips3.TabIndex = 8;
            this.labelTips3.Text = "labelTips3";
            // 
            // labelTips4
            // 
            this.labelTips4.AutoSize = true;
            this.labelTips4.Font = new System.Drawing.Font("宋体", 9F);
            this.labelTips4.Location = new System.Drawing.Point(46, 429);
            this.labelTips4.Name = "labelTips4";
            this.labelTips4.Size = new System.Drawing.Size(65, 12);
            this.labelTips4.TabIndex = 9;
            this.labelTips4.Text = "labelTips4";
            // 
            // buttonRecover
            // 
            this.buttonRecover.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRecover.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonRecover.Location = new System.Drawing.Point(640, 12);
            this.buttonRecover.Name = "buttonRecover";
            this.buttonRecover.Size = new System.Drawing.Size(133, 38);
            this.buttonRecover.TabIndex = 10;
            this.buttonRecover.Text = "还原备份";
            this.buttonRecover.UseVisualStyleBackColor = true;
            this.buttonRecover.Click += new System.EventHandler(this.ButtonRecover_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRecover);
            this.Controls.Add(this.labelTips4);
            this.Controls.Add(this.labelTips3);
            this.Controls.Add(this.labelTips0);
            this.Controls.Add(this.labelTips2);
            this.Controls.Add(this.labelTips1);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.richTextBoxEncryptFile);
            this.Controls.Add(this.buttonLoadFile);
            this.Controls.Add(this.richTextBoxLoadFile);
            this.Name = "Form1";
            this.Text = "XX ENCRYPT TOOL   by cndy1860";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxLoadFile;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.RichTextBox richTextBoxEncryptFile;
        private System.Windows.Forms.Label labelTips1;
        private System.Windows.Forms.Label labelTips2;
        private System.Windows.Forms.Label labelTips0;
        private System.Windows.Forms.Label labelTips3;
        private System.Windows.Forms.Label labelTips4;
        private System.Windows.Forms.Button buttonRecover;
    }
}


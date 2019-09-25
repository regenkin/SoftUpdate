namespace SoftUpdate
{
    partial class UpdateForm
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
            this.TxtMsg = new System.Windows.Forms.Label();
            this.ProgressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // TxtMsg
            // 
            this.TxtMsg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtMsg.Location = new System.Drawing.Point(12, 81);
            this.TxtMsg.Name = "TxtMsg";
            this.TxtMsg.Size = new System.Drawing.Size(453, 12);
            this.TxtMsg.TabIndex = 0;
            this.TxtMsg.Text = "12";
            this.TxtMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBarUpdate
            // 
            this.ProgressBarUpdate.Location = new System.Drawing.Point(12, 22);
            this.ProgressBarUpdate.Name = "ProgressBarUpdate";
            this.ProgressBarUpdate.Size = new System.Drawing.Size(453, 40);
            this.ProgressBarUpdate.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 108);
            this.Controls.Add(this.ProgressBarUpdate);
            this.Controls.Add(this.TxtMsg);
            this.Name = "Form1";
            this.Text = "更新程序";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TxtMsg;
        private System.Windows.Forms.ProgressBar ProgressBarUpdate;
    }
}


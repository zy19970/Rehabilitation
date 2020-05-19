namespace LED
{
    partial class LED
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.picR = new System.Windows.Forms.PictureBox();
            this.picD = new System.Windows.Forms.PictureBox();
            this.picG = new System.Windows.Forms.PictureBox();
            this.picY = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picY)).BeginInit();
            this.SuspendLayout();
            // 
            // picR
            // 
            this.picR.Image = global::LED.Properties.Resources.lightR;
            this.picR.Location = new System.Drawing.Point(0, 0);
            this.picR.Name = "picR";
            this.picR.Size = new System.Drawing.Size(40, 41);
            this.picR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picR.TabIndex = 2;
            this.picR.TabStop = false;
            // 
            // picD
            // 
            this.picD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picD.Image = global::LED.Properties.Resources.lightDark;
            this.picD.Location = new System.Drawing.Point(0, 0);
            this.picD.Name = "picD";
            this.picD.Size = new System.Drawing.Size(40, 41);
            this.picD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picD.TabIndex = 0;
            this.picD.TabStop = false;
            this.picD.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picG
            // 
            this.picG.Image = global::LED.Properties.Resources.lightG;
            this.picG.Location = new System.Drawing.Point(0, 0);
            this.picG.Name = "picG";
            this.picG.Size = new System.Drawing.Size(40, 41);
            this.picG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picG.TabIndex = 1;
            this.picG.TabStop = false;
            // 
            // picY
            // 
            this.picY.Image = global::LED.Properties.Resources.lightY;
            this.picY.Location = new System.Drawing.Point(0, 0);
            this.picY.Name = "picY";
            this.picY.Size = new System.Drawing.Size(40, 41);
            this.picY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picY.TabIndex = 3;
            this.picY.TabStop = false;
            // 
            // LED
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.picD);
            this.Controls.Add(this.picY);
            this.Controls.Add(this.picR);
            this.Controls.Add(this.picG);
            this.Name = "LED";
            this.Size = new System.Drawing.Size(192, 190);
            this.Load += new System.EventHandler(this.LED_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picD;
        private System.Windows.Forms.PictureBox picG;
        private System.Windows.Forms.PictureBox picR;
        private System.Windows.Forms.PictureBox picY;
    }
}

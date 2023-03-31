namespace Client_AGV
{
    partial class Controls
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btExit = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.btLeft = new System.Windows.Forms.Button();
            this.btUp = new System.Windows.Forms.Button();
            this.btRtrg = new System.Windows.Forms.Button();
            this.btRtlf = new System.Windows.Forms.Button();
            this.btDown = new System.Windows.Forms.Button();
            this.btRight = new System.Windows.Forms.Button();
            this.btFor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(12, 12);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(50, 50);
            this.btExit.TabIndex = 19;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(68, 180);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(50, 50);
            this.btBack.TabIndex = 17;
            this.btBack.Text = "BACK";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btLeft
            // 
            this.btLeft.Location = new System.Drawing.Point(12, 124);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(50, 50);
            this.btLeft.TabIndex = 16;
            this.btLeft.Text = "LF";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // btUp
            // 
            this.btUp.Location = new System.Drawing.Point(68, 68);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(50, 50);
            this.btUp.TabIndex = 15;
            this.btUp.Text = "UP";
            this.btUp.UseVisualStyleBackColor = true;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // btRtrg
            // 
            this.btRtrg.Location = new System.Drawing.Point(124, 68);
            this.btRtrg.Name = "btRtrg";
            this.btRtrg.Size = new System.Drawing.Size(50, 50);
            this.btRtrg.TabIndex = 14;
            this.btRtrg.Text = "RT RG";
            this.btRtrg.UseVisualStyleBackColor = true;
            this.btRtrg.Click += new System.EventHandler(this.btRtrg_Click);
            // 
            // btRtlf
            // 
            this.btRtlf.Location = new System.Drawing.Point(12, 68);
            this.btRtlf.Name = "btRtlf";
            this.btRtlf.Size = new System.Drawing.Size(50, 50);
            this.btRtlf.TabIndex = 13;
            this.btRtlf.Text = "RT LF";
            this.btRtlf.UseVisualStyleBackColor = true;
            this.btRtlf.Click += new System.EventHandler(this.btRtlf_Click);
            // 
            // btDown
            // 
            this.btDown.Location = new System.Drawing.Point(68, 124);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(50, 50);
            this.btDown.TabIndex = 12;
            this.btDown.Text = "DW";
            this.btDown.UseVisualStyleBackColor = true;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btRight
            // 
            this.btRight.Location = new System.Drawing.Point(124, 124);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(50, 50);
            this.btRight.TabIndex = 11;
            this.btRight.Text = "RG";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // btFor
            // 
            this.btFor.Location = new System.Drawing.Point(68, 12);
            this.btFor.Name = "btFor";
            this.btFor.Size = new System.Drawing.Size(50, 50);
            this.btFor.TabIndex = 10;
            this.btFor.Text = "FOR";
            this.btFor.UseVisualStyleBackColor = true;
            this.btFor.Click += new System.EventHandler(this.btFor_Click);
            // 
            // Controls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 242);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btLeft);
            this.Controls.Add(this.btUp);
            this.Controls.Add(this.btRtrg);
            this.Controls.Add(this.btRtlf);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.btRight);
            this.Controls.Add(this.btFor);
            this.Name = "Controls";
            this.Text = "Controls";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Button btUp;
        private System.Windows.Forms.Button btRtrg;
        private System.Windows.Forms.Button btRtlf;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btFor;
    }
}
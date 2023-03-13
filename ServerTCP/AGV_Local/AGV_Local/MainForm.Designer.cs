namespace AGV_Local
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Home = new System.Windows.Forms.TabPage();
            this.Players_management = new System.Windows.Forms.TabPage();
            this.panelWS = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Server_configuration = new System.Windows.Forms.TabPage();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbIp = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Home.SuspendLayout();
            this.Players_management.SuspendLayout();
            this.Server_configuration.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Home);
            this.tabControl1.Controls.Add(this.Players_management);
            this.tabControl1.Controls.Add(this.Server_configuration);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(422, 442);
            this.tabControl1.TabIndex = 0;
            // 
            // Home
            // 
            this.Home.Controls.Add(this.panelWS);
            this.Home.Location = new System.Drawing.Point(4, 22);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(414, 416);
            this.Home.TabIndex = 0;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            // 
            // Players_management
            // 
            this.Players_management.Controls.Add(this.label1);
            this.Players_management.Controls.Add(this.button3);
            this.Players_management.Controls.Add(this.checkedListBox1);
            this.Players_management.Controls.Add(this.button2);
            this.Players_management.Location = new System.Drawing.Point(4, 22);
            this.Players_management.Name = "Players_management";
            this.Players_management.Padding = new System.Windows.Forms.Padding(3);
            this.Players_management.Size = new System.Drawing.Size(414, 416);
            this.Players_management.TabIndex = 1;
            this.Players_management.Text = "Players management";
            this.Players_management.UseVisualStyleBackColor = true;
            // 
            // panelWS
            // 
            this.panelWS.Location = new System.Drawing.Point(6, 6);
            this.panelWS.Name = "panelWS";
            this.panelWS.Size = new System.Drawing.Size(400, 400);
            this.panelWS.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Users Online";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(92, 174);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 24);
            this.button3.TabIndex = 17;
            this.button3.Text = "Delete Selc. User";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "User 1",
            "User 2",
            "User 3",
            "..."});
            this.checkedListBox1.Location = new System.Drawing.Point(22, 29);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(174, 139);
            this.checkedListBox1.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 24);
            this.button2.TabIndex = 15;
            this.button2.Text = "Delete All";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Server_configuration
            // 
            this.Server_configuration.Controls.Add(this.lbPort);
            this.Server_configuration.Controls.Add(this.lbIp);
            this.Server_configuration.Controls.Add(this.tbPort);
            this.Server_configuration.Controls.Add(this.tbIp);
            this.Server_configuration.Controls.Add(this.btStart);
            this.Server_configuration.Location = new System.Drawing.Point(4, 22);
            this.Server_configuration.Name = "Server_configuration";
            this.Server_configuration.Padding = new System.Windows.Forms.Padding(3);
            this.Server_configuration.Size = new System.Drawing.Size(414, 416);
            this.Server_configuration.TabIndex = 2;
            this.Server_configuration.Text = "Server configuration";
            this.Server_configuration.UseVisualStyleBackColor = true;
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(72, 61);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(26, 13);
            this.lbPort.TabIndex = 11;
            this.lbPort.Text = "Port";
            // 
            // lbIp
            // 
            this.lbIp.AutoSize = true;
            this.lbIp.Location = new System.Drawing.Point(81, 14);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(17, 13);
            this.lbIp.TabIndex = 12;
            this.lbIp.Text = "IP";
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.Location = new System.Drawing.Point(36, 77);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(99, 26);
            this.tbPort.TabIndex = 10;
            this.tbPort.Text = "1";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIp
            // 
            this.tbIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIp.Location = new System.Drawing.Point(36, 30);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(99, 26);
            this.tbIp.TabIndex = 9;
            this.tbIp.Text = "127.0.0.1";
            this.tbIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(48, 127);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 8;
            this.btStart.Text = "START";
            this.btStart.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 442);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "AGV Local Control Screen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabControl1.ResumeLayout(false);
            this.Home.ResumeLayout(false);
            this.Players_management.ResumeLayout(false);
            this.Players_management.PerformLayout();
            this.Server_configuration.ResumeLayout(false);
            this.Server_configuration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Home;
        private System.Windows.Forms.Panel panelWS;
        private System.Windows.Forms.TabPage Players_management;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage Server_configuration;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbIp;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Button btStart;
    }
}


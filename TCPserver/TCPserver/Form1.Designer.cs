namespace TCPserver
{
    partial class Form1
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
            this.panelWS = new System.Windows.Forms.Panel();
            this.btStart = new System.Windows.Forms.Button();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lbIp = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpOnline = new System.Windows.Forms.TabPage();
            this.tbOnline = new System.Windows.Forms.TextBox();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.stopsv = new System.Windows.Forms.Button();
            this.tbUsers = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpOnline.SuspendLayout();
            this.tpUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWS
            // 
            this.panelWS.Location = new System.Drawing.Point(2, 27);
            this.panelWS.Name = "panelWS";
            this.panelWS.Size = new System.Drawing.Size(400, 400);
            this.panelWS.TabIndex = 0;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(213, 31);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(71, 27);
            this.btStart.TabIndex = 8;
            this.btStart.Text = "START";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbIp
            // 
            this.tbIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIp.Location = new System.Drawing.Point(3, 32);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(99, 26);
            this.tbIp.TabIndex = 9;
            this.tbIp.Text = "127.0.0.1";
            this.tbIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.Location = new System.Drawing.Point(108, 32);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(99, 26);
            this.tbPort.TabIndex = 10;
            this.tbPort.Text = "1";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbIp
            // 
            this.lbIp.AutoSize = true;
            this.lbIp.Location = new System.Drawing.Point(6, 16);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(17, 13);
            this.lbIp.TabIndex = 12;
            this.lbIp.Text = "IP";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(114, 16);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(26, 13);
            this.lbPort.TabIndex = 11;
            this.lbPort.Text = "Port";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccountsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.generateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(827, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addAccountsToolStripMenuItem
            // 
            this.addAccountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addClientToolStripMenuItem,
            this.removeClientToolStripMenuItem});
            this.addAccountsToolStripMenuItem.Name = "addAccountsToolStripMenuItem";
            this.addAccountsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.addAccountsToolStripMenuItem.Text = "Users";
            this.addAccountsToolStripMenuItem.ToolTipText = "Manage clients";
            // 
            // addClientToolStripMenuItem
            // 
            this.addClientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addClientsToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.addClientToolStripMenuItem.Name = "addClientToolStripMenuItem";
            this.addClientToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addClientToolStripMenuItem.Text = "Manage clients";
            // 
            // addClientsToolStripMenuItem
            // 
            this.addClientsToolStripMenuItem.Name = "addClientsToolStripMenuItem";
            this.addClientsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addClientsToolStripMenuItem.Text = "Add clients";
            this.addClientsToolStripMenuItem.ToolTipText = "Create a new client adding a User name and password";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.removeToolStripMenuItem.Text = "Remove selected";
            this.removeToolStripMenuItem.ToolTipText = "Remove the selecteds clients from data base";
            // 
            // removeClientToolStripMenuItem
            // 
            this.removeClientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removePlayerToolStripMenuItem,
            this.removeAllPlayersToolStripMenuItem});
            this.removeClientToolStripMenuItem.Name = "removeClientToolStripMenuItem";
            this.removeClientToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.removeClientToolStripMenuItem.Text = "Players online";
            this.removeClientToolStripMenuItem.ToolTipText = "Manage players online";
            // 
            // removePlayerToolStripMenuItem
            // 
            this.removePlayerToolStripMenuItem.Name = "removePlayerToolStripMenuItem";
            this.removePlayerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.removePlayerToolStripMenuItem.Text = "Kick player selected";
            this.removePlayerToolStripMenuItem.ToolTipText = "Kick a player form the current game\r\n";
            this.removePlayerToolStripMenuItem.Click += new System.EventHandler(this.removePlayerToolStripMenuItem_Click);
            // 
            // removeAllPlayersToolStripMenuItem
            // 
            this.removeAllPlayersToolStripMenuItem.Name = "removeAllPlayersToolStripMenuItem";
            this.removeAllPlayersToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.removeAllPlayersToolStripMenuItem.Text = "Kick all players";
            this.removeAllPlayersToolStripMenuItem.ToolTipText = "Kick all players form the current game";
            this.removeAllPlayersToolStripMenuItem.Click += new System.EventHandler(this.removeAllPlayersToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notepadToolStripMenuItem,
            this.excelToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.ToolTipText = "Export data base";
            // 
            // notepadToolStripMenuItem
            // 
            this.notepadToolStripMenuItem.Name = "notepadToolStripMenuItem";
            this.notepadToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.notepadToolStripMenuItem.Text = "Notepad";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.stopsv);
            this.groupBox1.Controls.Add(this.btStart);
            this.groupBox1.Controls.Add(this.lbPort);
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Controls.Add(this.lbIp);
            this.groupBox1.Controls.Add(this.tbIp);
            this.groupBox1.Location = new System.Drawing.Point(406, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 415);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server managment";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpOnline);
            this.tabControl1.Controls.Add(this.tpUsers);
            this.tabControl1.Location = new System.Drawing.Point(9, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 211);
            this.tabControl1.TabIndex = 14;
            // 
            // tpOnline
            // 
            this.tpOnline.Controls.Add(this.tbOnline);
            this.tpOnline.Location = new System.Drawing.Point(4, 22);
            this.tpOnline.Name = "tpOnline";
            this.tpOnline.Padding = new System.Windows.Forms.Padding(3);
            this.tpOnline.Size = new System.Drawing.Size(192, 185);
            this.tpOnline.TabIndex = 0;
            this.tpOnline.Text = "Online";
            this.tpOnline.UseVisualStyleBackColor = true;
            // 
            // tbOnline
            // 
            this.tbOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOnline.Location = new System.Drawing.Point(3, 3);
            this.tbOnline.Multiline = true;
            this.tbOnline.Name = "tbOnline";
            this.tbOnline.ReadOnly = true;
            this.tbOnline.Size = new System.Drawing.Size(186, 179);
            this.tbOnline.TabIndex = 0;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.tbUsers);
            this.tpUsers.Location = new System.Drawing.Point(4, 22);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsers.Size = new System.Drawing.Size(192, 185);
            this.tpUsers.TabIndex = 1;
            this.tpUsers.Text = "Users";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // stopsv
            // 
            this.stopsv.Location = new System.Drawing.Point(290, 31);
            this.stopsv.Name = "stopsv";
            this.stopsv.Size = new System.Drawing.Size(71, 27);
            this.stopsv.TabIndex = 13;
            this.stopsv.Text = "STOP";
            this.stopsv.UseVisualStyleBackColor = true;
            this.stopsv.Click += new System.EventHandler(this.stopsv_Click);
            // 
            // tbUsers
            // 
            this.tbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUsers.Location = new System.Drawing.Point(3, 3);
            this.tbUsers.Multiline = true;
            this.tbUsers.Name = "tbUsers";
            this.tbUsers.ReadOnly = true;
            this.tbUsers.Size = new System.Drawing.Size(186, 179);
            this.tbUsers.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 432);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelWS);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Server Screen";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpOnline.ResumeLayout(false);
            this.tpOnline.PerformLayout();
            this.tpUsers.ResumeLayout(false);
            this.tpUsers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelWS;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbIp;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllPlayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notepadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button stopsv;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpOnline;
        private System.Windows.Forms.TextBox tbOnline;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.TextBox tbUsers;
    }
}
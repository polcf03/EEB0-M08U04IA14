namespace TCPserver
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
            this.Client_Security = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.Server_configuration = new System.Windows.Forms.TabPage();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbIp = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.TabPage();
            this.panelWS = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Selected_user = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agv_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pasword_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_online = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Client_Security.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.Server_configuration.SuspendLayout();
            this.Home.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Client_Security
            // 
            this.Client_Security.Controls.Add(this.dataGridView1);
            this.Client_Security.Controls.Add(this.menuStrip1);
            this.Client_Security.Location = new System.Drawing.Point(4, 22);
            this.Client_Security.Name = "Client_Security";
            this.Client_Security.Padding = new System.Windows.Forms.Padding(3);
            this.Client_Security.Size = new System.Drawing.Size(416, 415);
            this.Client_Security.TabIndex = 3;
            this.Client_Security.Text = "Client";
            this.Client_Security.ToolTipText = "Manage clients, online players and export cliens data base";
            this.Client_Security.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected_user,
            this.id_user,
            this.User_name,
            this.Agv_id,
            this.pasword_user,
            this.User_online});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(410, 385);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccountsToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(410, 24);
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
            this.addClientsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addClientsToolStripMenuItem.Text = "Add clients";
            this.addClientsToolStripMenuItem.ToolTipText = "Create a new client adding a User name and password";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.removeToolStripMenuItem.Text = "Remove";
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
            this.removePlayerToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.removePlayerToolStripMenuItem.Text = "Kick player";
            this.removePlayerToolStripMenuItem.ToolTipText = "Kick a player form the current game\r\n";
            // 
            // removeAllPlayersToolStripMenuItem
            // 
            this.removeAllPlayersToolStripMenuItem.Name = "removeAllPlayersToolStripMenuItem";
            this.removeAllPlayersToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.removeAllPlayersToolStripMenuItem.Text = "Kick all players";
            this.removeAllPlayersToolStripMenuItem.ToolTipText = "Kick all players form the current game";
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
            this.Server_configuration.ToolTipText = "Server configuration";
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
            // Home
            // 
            this.Home.Controls.Add(this.panelWS);
            this.Home.Location = new System.Drawing.Point(4, 22);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(416, 415);
            this.Home.TabIndex = 0;
            this.Home.Text = "Home";
            this.Home.ToolTipText = "Game screen";
            this.Home.UseVisualStyleBackColor = true;
            // 
            // panelWS
            // 
            this.panelWS.Location = new System.Drawing.Point(6, 6);
            this.panelWS.Name = "panelWS";
            this.panelWS.Size = new System.Drawing.Size(400, 400);
            this.panelWS.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Home);
            this.tabControl1.Controls.Add(this.Client_Security);
            this.tabControl1.Controls.Add(this.Server_configuration);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(424, 441);
            this.tabControl1.TabIndex = 0;
            // 
            // Selected_user
            // 
            this.Selected_user.HeaderText = "Selec.";
            this.Selected_user.Name = "Selected_user";
            this.Selected_user.ReadOnly = true;
            this.Selected_user.Width = 40;
            // 
            // id_user
            // 
            this.id_user.HeaderText = "Id";
            this.id_user.Name = "id_user";
            this.id_user.ReadOnly = true;
            this.id_user.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id_user.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id_user.Width = 30;
            // 
            // User_name
            // 
            this.User_name.HeaderText = "User name";
            this.User_name.Name = "User_name";
            this.User_name.ReadOnly = true;
            this.User_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.User_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.User_name.Width = 80;
            // 
            // Agv_id
            // 
            this.Agv_id.HeaderText = "AGV";
            this.Agv_id.Name = "Agv_id";
            this.Agv_id.ReadOnly = true;
            this.Agv_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Agv_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Agv_id.Width = 30;
            // 
            // pasword_user
            // 
            this.pasword_user.HeaderText = "Password";
            this.pasword_user.Name = "pasword_user";
            this.pasword_user.ReadOnly = true;
            this.pasword_user.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pasword_user.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pasword_user.Width = 70;
            // 
            // User_online
            // 
            this.User_online.HeaderText = "Online";
            this.User_online.Name = "User_online";
            this.User_online.ReadOnly = true;
            this.User_online.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.User_online.Width = 40;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 441);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "AGV Local Control Screen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Client_Security.ResumeLayout(false);
            this.Client_Security.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Server_configuration.ResumeLayout(false);
            this.Server_configuration.PerformLayout();
            this.Home.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Client_Security;
        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.TabPage Server_configuration;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbIp;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabPage Home;
        private System.Windows.Forms.Panel panelWS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Agv_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pasword_user;
        private System.Windows.Forms.DataGridViewCheckBoxColumn User_online;
    }
}


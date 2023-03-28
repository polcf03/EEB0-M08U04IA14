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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Selected_user = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agv_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pasword_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_online = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stopsv = new System.Windows.Forms.Button();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.removeClientToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeClientToolStripMenuItem.Text = "Players online";
            this.removeClientToolStripMenuItem.ToolTipText = "Manage players online";
            // 
            // removePlayerToolStripMenuItem
            // 
            this.removePlayerToolStripMenuItem.Name = "removePlayerToolStripMenuItem";
            this.removePlayerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removePlayerToolStripMenuItem.Text = "Kick player selected";
            this.removePlayerToolStripMenuItem.ToolTipText = "Kick a player form the current game\r\n";
            this.removePlayerToolStripMenuItem.Click += new System.EventHandler(this.removePlayerToolStripMenuItem_Click);
            // 
            // removeAllPlayersToolStripMenuItem
            // 
            this.removeAllPlayersToolStripMenuItem.Name = "removeAllPlayersToolStripMenuItem";
            this.removeAllPlayersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(3, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(411, 350);
            this.dataGridView1.TabIndex = 0;
            // 
            // Selected_user
            // 
            this.Selected_user.HeaderText = "Selec.";
            this.Selected_user.Name = "Selected_user";
            this.Selected_user.ReadOnly = true;
            this.Selected_user.Width = 50;
            // 
            // id_user
            // 
            this.id_user.HeaderText = "Id";
            this.id_user.Name = "id_user";
            this.id_user.ReadOnly = true;
            this.id_user.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id_user.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id_user.Width = 35;
            // 
            // User_name
            // 
            this.User_name.HeaderText = "User name";
            this.User_name.Name = "User_name";
            this.User_name.ReadOnly = true;
            this.User_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.User_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.User_name.Width = 90;
            // 
            // Agv_id
            // 
            this.Agv_id.HeaderText = "AGV";
            this.Agv_id.Name = "Agv_id";
            this.Agv_id.ReadOnly = true;
            this.Agv_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Agv_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Agv_id.Width = 40;
            // 
            // pasword_user
            // 
            this.pasword_user.HeaderText = "Password";
            this.pasword_user.Name = "pasword_user";
            this.pasword_user.ReadOnly = true;
            this.pasword_user.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pasword_user.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // User_online
            // 
            this.User_online.HeaderText = "Online";
            this.User_online.Name = "User_online";
            this.User_online.ReadOnly = true;
            this.User_online.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.User_online.Width = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stopsv);
            this.groupBox1.Controls.Add(this.dataGridView1);
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
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Agv_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pasword_user;
        private System.Windows.Forms.DataGridViewCheckBoxColumn User_online;
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
    }
}
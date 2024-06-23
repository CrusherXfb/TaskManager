namespace TaskManager
{
    partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageProcesses = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStripProcess = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.снятьЗадачуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listViewProcesses = new TaskManager.ListViewSmooth();
			this.tabControl1.SuspendLayout();
			this.tabPageProcesses.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStripProcess.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPageProcesses);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(0, 25);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(800, 400);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageProcesses
			// 
			this.tabPageProcesses.Controls.Add(this.listViewProcesses);
			this.tabPageProcesses.Location = new System.Drawing.Point(4, 22);
			this.tabPageProcesses.Name = "tabPageProcesses";
			this.tabPageProcesses.Size = new System.Drawing.Size(792, 374);
			this.tabPageProcesses.TabIndex = 0;
			this.tabPageProcesses.Text = "Processes";
			this.tabPageProcesses.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(792, 374);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 428);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(800, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
			this.runToolStripMenuItem.Text = "Run";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// contextMenuStripProcess
			// 
			this.contextMenuStripProcess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.снятьЗадачуToolStripMenuItem});
			this.contextMenuStripProcess.Name = "contextMenuStripProcess";
			this.contextMenuStripProcess.Size = new System.Drawing.Size(181, 48);
			// 
			// снятьЗадачуToolStripMenuItem
			// 
			this.снятьЗадачуToolStripMenuItem.Name = "снятьЗадачуToolStripMenuItem";
			this.снятьЗадачуToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.снятьЗадачуToolStripMenuItem.Text = "Снять задачу";
			this.снятьЗадачуToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click_KILL);
			// 
			// listViewProcesses
			// 
			this.listViewProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewProcesses.FullRowSelect = true;
			this.listViewProcesses.HideSelection = false;
			this.listViewProcesses.Location = new System.Drawing.Point(0, 0);
			this.listViewProcesses.MultiSelect = false;
			this.listViewProcesses.Name = "listViewProcesses";
			this.listViewProcesses.Size = new System.Drawing.Size(792, 374);
			this.listViewProcesses.TabIndex = 0;
			this.listViewProcesses.UseCompatibleStateImageBehavior = false;
			this.listViewProcesses.View = System.Windows.Forms.View.Details;
			this.listViewProcesses.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnClick);
			this.listViewProcesses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewProcesses_MouseClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "TaskManager";
			this.tabControl1.ResumeLayout(false);
			this.tabPageProcesses.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStripProcess.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageProcesses;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ListViewSmooth listViewProcesses;
        //private System.Windows.Forms.ListView listViewProcesses;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripProcess;
		private System.Windows.Forms.ToolStripMenuItem снятьЗадачуToolStripMenuItem;
	}
}


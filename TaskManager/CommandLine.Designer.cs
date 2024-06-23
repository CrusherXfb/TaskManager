namespace TaskManager
{
	partial class CommandLine
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandLine));
			this.button_OK = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.button_Browse = new System.Windows.Forms.Button();
			this.comboBoxFilename = new System.Windows.Forms.ComboBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// button_OK
			// 
			this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button_OK.Location = new System.Drawing.Point(103, 132);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(75, 23);
			this.button_OK.TabIndex = 0;
			this.button_OK.Text = "OK";
			this.button_OK.UseVisualStyleBackColor = true;
			this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.Location = new System.Drawing.Point(184, 132);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 1;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			// 
			// button_Browse
			// 
			this.button_Browse.Location = new System.Drawing.Point(265, 131);
			this.button_Browse.Name = "button_Browse";
			this.button_Browse.Size = new System.Drawing.Size(75, 23);
			this.button_Browse.TabIndex = 2;
			this.button_Browse.Text = "Browse";
			this.button_Browse.UseVisualStyleBackColor = true;
			this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
			// 
			// comboBoxFilename
			// 
			this.comboBoxFilename.FormattingEnabled = true;
			this.comboBoxFilename.Location = new System.Drawing.Point(106, 79);
			this.comboBoxFilename.Name = "comboBoxFilename";
			this.comboBoxFilename.Size = new System.Drawing.Size(234, 21);
			this.comboBoxFilename.TabIndex = 3;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(46, 41);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// CommandLine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(343, 167);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.comboBoxFilename);
			this.Controls.Add(this.button_Browse);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_OK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CommandLine";
			this.Text = "Run";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button_OK;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Button button_Browse;
		private System.Windows.Forms.ComboBox comboBoxFilename;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
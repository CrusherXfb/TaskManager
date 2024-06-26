using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq.Expressions;
using System.IO;

namespace TaskManager
{
	public partial class CommandLine : Form
	{
		public ComboBox ComboBoxFileName 
		{ 
			get
			{
				return comboBoxFilename;
			}
		}
		public CommandLine()
		{
			InitializeComponent();
			Load();
		}

		public void Load()
		{
			StreamReader sr = new StreamReader("ProgramList.txt");
			while(!sr.EndOfStream)
			{
				string item = sr.ReadLine();
				comboBoxFilename.Items.Add(item);

			}
			comboBoxFilename.Text = comboBoxFilename.Items[0].ToString();
			sr.Close();
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo(comboBoxFilename.Text);
				Process process = new Process();
				process.StartInfo = startInfo;
				process.Start();
				string proc = comboBoxFilename.Text;
				if (!comboBoxFilename.Items.Contains(proc))
					comboBoxFilename.Items.Insert(0, proc);
				else
				{
					comboBoxFilename.Items.Remove(proc);
					comboBoxFilename.Text = proc;
					comboBoxFilename.Items.Insert(0, proc);
				}
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Nicht Helicopter", MessageBoxButtons.OK, MessageBoxIcon.Error);
			
			}			
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		} 

		private void button_Browse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Executable (*.exe)|*.exe|All files (*.*)|*.*";
			DialogResult result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
				comboBoxFilename.Text = openFileDialog.FileName;
		}

		private void CommandLine_FormClosing(object sender, FormClosingEventArgs e)
		{
			comboBoxFilename.Focus();
		}

		private void comboBoxFilename_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)13)
			{
				button_OK_Click(sender, e);
			}			
		}

		private void CommandLine_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.Escape)
			{
				Close();
			}
		}
	}
}

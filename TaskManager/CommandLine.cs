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

namespace TaskManager
{
	public partial class CommandLine : Form
	{
		public CommandLine()
		{
			InitializeComponent();
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo(comboBoxFilename.Text);
			Process process = new Process();
			process.StartInfo = startInfo;
			process.Start();
			Close();
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button_Browse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Executable (*.exe)|*.exe;";
			openFileDialog.ShowDialog();
			comboBoxFilename.Text = openFileDialog.FileName;
		}
	}
}

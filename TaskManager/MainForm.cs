﻿using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
			SetColumns();
			statusStrip1.Items.Add("");


			
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			 
			LoadProcesses();




			//listViewProcesses.Items.Clear();
			//foreach (var process in processes)
			//{
			//	ListViewItem item = new ListViewItem(process.ProcessName);
			//	listViewProcesses.Items.Add(item);
			//}
		}

		void SetColumns()
		{
			listViewProcesses.Columns.Add("PID");
			listViewProcesses.Columns.Add("Name");
			
		}

		void LoadProcesses()
		{

			//listViewProcesses.Items.Clear();

			//Process[] processes = Process.GetProcesses();
			//for (int i = 0; i < processes.Length; i++)
			//{
			//	ListViewItem item = new ListViewItem();
			//	item.Text = processes[i].Id.ToString();
			//	item.SubItems.Add(processes[i].ProcessName.ToString());
			//	listViewProcesses.Items.Add(item);
			//}
			FindProcesses();
			statusStrip1.Items[0].Text = ($"Количество процессов: {listViewProcesses.Items.Count}");


		}

		void FindProcesses()
		{
			Process[] processes = Process.GetProcesses();
			for (int i = 0; i < processes.Length; i++)
			{
				bool found = false;
				for (int j = 0; j < listViewProcesses.Items.Count; j++)
				{
					ListViewItem lVprocess = listViewProcesses.Items[j];
					if (processes[i].Id == Convert.ToInt32(lVprocess.SubItems[0].Text))
					{
						found = true;
					}
				}
				if (found == false)
				{
					ListViewItem item = new ListViewItem();
					item.Text = processes[i].Id.ToString();
					item.SubItems.Add(processes[i].ProcessName.ToString());
					listViewProcesses.Items.Add(item);
				}
			}

			for (int i = 0; i < listViewProcesses.Items.Count; i++)
			{
				bool found = false;
				for (int j = 0; j < processes.Length; j++)
				{
					ListViewItem lVprocess = listViewProcesses.Items[j];
					if (processes[i].Id == Convert.ToInt32(lVprocess.SubItems[0].Text))
					{
						found = true;
					}
				}
				if (found == false)
				{
					listViewProcesses.Items.RemoveAt(i);
				}
			}



		}
		
	}
}

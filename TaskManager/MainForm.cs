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
using System.Collections;

namespace TaskManager
{
    public partial class MainForm : Form
    {
		Dictionary<int, Process> d_processes;
        public MainForm()
        {
			
			InitializeComponent();
			SetColumns();
			statusStrip1.Items.Add("");
			LoadProcesses();
			SortListView();

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			AddNewProcesses();

			RemoveOldProcesses();
			//SortListView();
			statusStrip1.Items[0].Text = ($"Количество процессов: {listViewProcesses.Items.Count}");

		}

		void SetColumns()
		{
			listViewProcesses.Columns.Add("PID");
			listViewProcesses.Columns.Add("Name");
			
		}

		void LoadProcesses()
		{
			/*
			//Process[] processes = Process.GetProcesses();
			//for (int i = 0; i < processes.Length; i++)
			//{
			//	ListViewItem item = new ListViewItem();
			//	item.Text = processes[i].Id.ToString();
			//	item.SubItems.Add(processes[i].ProcessName.ToString());
			//	listViewProcesses.Items.Add(item);
			//}
			//FindProcesses();
			*/

			d_processes = Process.GetProcesses().ToDictionary(item => item.Id, item => item);
			foreach(var i in d_processes)
			{
				ListViewItem item = new ListViewItem();
				item.Text = i.Key.ToString();
				item.SubItems.Add(i.Value.ProcessName.ToString());
				listViewProcesses.Items.Add(item);
			}



			statusStrip1.Items[0].Text = ($"Количество процессов: {listViewProcesses.Items.Count}");


		}

		//void FindProcesses()
		//{
		//	Process[] processes = Process.GetProcesses();
		//	for (int i = 0; i < processes.Length; i++)
		//	{
		//		bool found = false;
		//		for (int j = 0; j < listViewProcesses.Items.Count; j++)
		//		{
		//			ListViewItem lVprocess = listViewProcesses.Items[j];
		//			if (processes[i].Id == Convert.ToInt32(lVprocess.SubItems[0].Text))
		//			{
		//				found = true;
		//			}
		//		}
		//		if (found == false)
		//		{
		//			ListViewItem item = new ListViewItem();
		//			item.Text = processes[i].Id.ToString();
		//			item.SubItems.Add(processes[i].ProcessName.ToString());
		//			listViewProcesses.Items.Add(item);
		//		}
		//	}

		//	for (int i = 0; i < listViewProcesses.Items.Count; i++)
		//	{
		//		bool found = false;
		//		for (int j = 0; j < processes.Length; j++)
		//		{
		//			ListViewItem lVprocess = listViewProcesses.Items[j];
		//			if (processes[i].Id == Convert.ToInt32(lVprocess.SubItems[0].Text))
		//			{
		//				found = true;
		//			}
		//		}
		//		if (found == false)
		//		{
		//			listViewProcesses.Items.RemoveAt(i);
		//		}
		//	}
		//}
		
		void AddNewProcesses()
		{
			Dictionary<int, Process> d_processes = Process.GetProcesses().ToDictionary(item => item.Id, item=>item);
			foreach (var process in d_processes)
			{
				if (!this.d_processes.ContainsKey(process.Key))
				{
					//this.d_processes.Add(process.Key, process.Value);
					AddProcessToListView(process.Value);
				}
			}
		}

		void AddProcessToListView(Process process)
		{
			ListViewItem item = new ListViewItem();
			item.Text = process.Id.ToString();
			item.SubItems.Add(process.ProcessName);
			listViewProcesses.Items.Add(item);
		}

		void RemoveOldProcesses()
		{
			this.d_processes = Process.GetProcesses().ToDictionary(item => item.Id, item => item);

			/*
			//Dictionary<int, Process> d_processes = Process.GetProcesses().ToDictionary(item => item.Id, item => item);
			//while (true)
			//{
			//	bool deleted = false;
			//	foreach (var process in this.d_processes)
			//	{
			//		if (!d_processes.ContainsKey(process.Key))
			//		{
			//			this.d_processes.Remove(process.Key);
			//			listViewProcesses.Items.RemoveAt(FindProcessIndexById(process.Key));
			//			deleted = true;
			//			break;
			//		}
			//	}
			//	if (deleted == false)
			//		break;
			//}

			//statusStrip1.Items[0].Text = ($"Количество процессов: {listViewProcesses.Items.Count}");
			*/

			for (int i = 0; i < listViewProcesses.Items.Count; i++)
			{
				if (!d_processes.ContainsKey(Convert.ToInt32(listViewProcesses.Items[i].Text)))
				{
					listViewProcesses.Items.RemoveAt(i);
				}
			}
		}

		void SortListView()
		{
			listViewProcesses.ListViewItemSorter = new ListViewItemComparer();
		}

		class ListViewItemComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				return int.Parse(((ListViewItem)x).Text).CompareTo(int.Parse(((ListViewItem)y).Text));
			}
		}

		//int FindProcessIndexById(int id)
		//{
		//	for(int i = 0; i < listViewProcesses.Items.Count; i++)
		//	{
		//		if (listViewProcesses.Items[i].Text == id.ToString())
		//			return i;
		//	}
		//	return 0;
		//}
	}
}













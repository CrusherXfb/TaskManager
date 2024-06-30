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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Globalization;
using static TaskManager.ListViewItemComparer;
using System.Reflection;

namespace TaskManager
{
    public partial class MainForm : Form
    {
		readonly int ramFactor = 1024;
		readonly string suffix = "kB";
		Dictionary<int, Process> d_processes;
		CommandLine cmd = new CommandLine();

		enum ColumnName
		{
			PID,
			Name
		}

		public MainForm()
        {			
			InitializeComponent();
			SetColumns();
			statusStrip1.Items.Add("");
			LoadProcesses();
			AllignColumns();
			//SortListView();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			AddNewProcesses();

			RemoveOldProcesses();

			UpdateExistingProcesses();
			//SortListView();

			statusStrip1.Items[0].Text = ($"Количество процессов: {listViewProcesses.Items.Count}");

		}

		void SetColumns()
		{
			listViewProcesses.Columns.Add("PID");
			listViewProcesses.Columns.Add("Name");
			listViewProcesses.Columns.Add("Working set");
			listViewProcesses.Columns.Add("Peak working set");



			foreach (ColumnHeader column in listViewProcesses.Columns)
			{
				if (column.Width < 100)
				{
					column.Width = 100;
				}
			}
			//listViewProcesses.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);

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
				//ListViewItem item = new ListViewItem();
				//item.Text = i.Key.ToString();
				//item.SubItems.Add(i.Value.ProcessName.ToString());
				//listViewProcesses.Items.Add(item);
				AddProcessToListView(i.Value);
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
			item.SubItems.Add($"{process.WorkingSet64 / ramFactor} {suffix}");
			item.SubItems.Add($"{process.PeakWorkingSet64 / ramFactor} {suffix}");
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

		private void ColumnClick(object o, ColumnClickEventArgs e)
		{
			//ListViewItemComparer sorter = new ListViewItemComparer(e.Column);
			//listViewProcesses.ListViewItemSorter = new ListViewItemComparer();

			//ListViewItemComparer sorter = GetListViewSorter(e.Column);
			//listViewProcesses.ListViewItemSorter = sorter;
			//listViewProcesses.Sort();

			listViewProcesses.ListViewItemSorter = GetListSorter(e.Column);
			listViewProcesses.Sort();
		}

		ListSortingClass GetListSorter(int index)
		{
			ListSortingClass lsc = (ListSortingClass)listViewProcesses.ListViewItemSorter;
			if (lsc == null)
			{
				lsc = new ListSortingClass();
			}
			lsc.Index = index;
			string columnName = listViewProcesses.Columns[index].Text;
			//MessageBox.Show(columnName);
			switch (columnName)
			{
				case "PID":
					lsc.Type = ListSortingClass.ValueType.Integer;
					break;
				case "Name":
					lsc.Type = ListSortingClass.ValueType.String;
					break;
				case "Working set":
				case "Peak working set":
					lsc.Type = ListSortingClass.ValueType.Memory;
					break;
			}
			lsc.direction = lsc.direction == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			return lsc;
		}


		private ListViewItemComparer GetListViewSorter(int columnIndex)
		{
			ListViewItemComparer sorter = (ListViewItemComparer)listViewProcesses.ListViewItemSorter;
			if (sorter == null)
			{
				sorter = new ListViewItemComparer();
			}

			sorter.ColumnIndex = columnIndex;

			//string columnName = listViewProcesses.Columns[columnIndex].Name;
			switch (columnIndex)
			{
				case 0:
					sorter.ColumnType = ColumnDataType.Int;
					break;
				default:
					sorter.ColumnType = ColumnDataType.String;
					break;
			}

			if (sorter.SortDirection == SortOrder.Ascending)
			{
				sorter.SortDirection = SortOrder.Descending;
			}
			else
			{
				sorter.SortDirection = SortOrder.Ascending;
			}

			return sorter;
		}

		//class ListViewItemComparer : IComparer
		//{
		//	private int col;

		//	public ListViewItemComparer(int column)
		//	{
		//		col = column;
		//	}

		//	public int Compare(object x, object y)
		//	{
		//		if (col == 0)
		//			return int.Parse(((ListViewItem)x).SubItems[col].Text).CompareTo(int.Parse(((ListViewItem)y).SubItems[col].Text));
		//		else
		//			return ((ListViewItem)x).SubItems[col].Text.CompareTo(((ListViewItem)y).SubItems[col].Text);
		//	}
		//}

		void UpdateExistingProcesses()
		{
			for (int i = 0; i < listViewProcesses.Items.Count; i++)
			{
				try
				{
					int id = Convert.ToInt32(listViewProcesses.Items[i].Text);
					listViewProcesses.Items[i].SubItems[2].Text = $"{d_processes[id].WorkingSet64 / ramFactor} {suffix}";
					listViewProcesses.Items[i].SubItems[3].Text = $"{d_processes[id].PeakWorkingSet64 / ramFactor} {suffix}";
				}
				catch { }
			}
			
			
		}

		private void runToolStripMenuItem_Click(object sender, EventArgs e)
		{
			cmd.ShowDialog();
		}

		//private void listViewProcesses_MouseClick(object sender, MouseEventArgs e)
		//{
		//	if (e.Button == MouseButtons.Right)
		//	{
		//		if (listViewProcesses.FocusedItem != null)
		//		{
		//			contextMenuStripProcess.Show(Cursor.Position);
		//		}
		//	}
		//}

		private void ToolStripMenuItem_Click_KILL(object sender, EventArgs e)
		{
			//MessageBox.Show(this, listViewProcesses.SelectedItems[0].Text);
			d_processes[Convert.ToInt32(listViewProcesses.SelectedItems[0].Text)].Kill();
			//Process p = Process.GetProcessById(Convert.ToInt32(listViewProcesses.SelectedItems[0].Text));
			//p.Kill();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			StreamWriter sw = new StreamWriter("ProgramList.txt");

			for (int i = 0; i < cmd.ComboBoxFileName.Items.Count; i++)
			{
				sw.WriteLine(cmd.ComboBoxFileName.Items[i]);
			}
			sw.Close();
		}

		void AllignColumns()
		{
			for (int i = 0; i < listViewProcesses.Columns.Count; i++)
			{
				int value;
				if (Int32.TryParse(listViewProcesses.Items[0].SubItems[i].Text.Split(' ')[0], out value) == true)
				{
					listViewProcesses.Columns[i].TextAlign = HorizontalAlignment.Right;
				}
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













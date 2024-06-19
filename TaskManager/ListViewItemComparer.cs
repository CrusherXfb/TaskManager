using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
	class ListViewItemComparer : IComparer
	{
		public int Compare(object x, object y)
		{
			return int.Parse(((ListViewItem)x).Text).CompareTo(int.Parse(((ListViewItem)y).Text));
		}
	}
}

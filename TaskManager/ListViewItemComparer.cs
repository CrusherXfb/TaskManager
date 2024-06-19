//#define SORTING_CLASS


#if SORTING_CLASS


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
		public ListViewItemComparer(int column)
		{
			ColumnToSort = column;
		}

		public ListViewItemComparer()
		{
			ColumnToSort = 0;
		}

		/// <summary>
		/// Specifies the column to be sorted
		/// </summary>
		private int ColumnToSort;

		public int Compare(object x, object y)
		{
			ListViewItem listviewX, listviewY;

			// Cast the objects to be compared to ListViewItem objects
			listviewX = (ListViewItem)x;
			listviewY = (ListViewItem)y;

			// Compare the two items
			if (ColumnToSort == 0)
				return int.Parse(listviewX.Text).CompareTo(int.Parse(listviewY.Text));
			else
				return int.Parse(listviewX.SubItems[ColumnToSort].Text).CompareTo(int.Parse(listviewY.SubItems[ColumnToSort].Text));
		}

		/// <summary>
		/// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
		/// </summary>
		public int SortColumn
		{
			set
			{
				ColumnToSort = value;
			}
			get
			{
				return ColumnToSort;
			}
		}

	}
}



#endif

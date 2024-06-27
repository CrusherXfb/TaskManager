using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
	internal class ListSortingClass : IComparer
	{
		public enum ValueType
		{
			String,
			Integer,
			Memory
		}
		public ValueType Type { get; set; }

		public int Index { get; set; }
		public SortOrder direction;

		public ListSortingClass(int column = 0)
		{
			this.Index = column;
			direction = SortOrder.None;
		}

		public int Compare(object x, object y)
		{
			ListViewItem lviX = x as ListViewItem;
			ListViewItem lviY = y as ListViewItem;

			if (lviX == null && lviY == null)
			{return 0;}
			else if (lviX == null)
			{return -1;}
			else if (lviY == null)
			{return 1;}

			int result = 0;

			int X_value;
			int Y_value;
			switch (this.Type)
			{
				case ValueType.Integer:
					{
						Int32.TryParse(lviY.SubItems[Index].Text, out Y_value);
						Int32.TryParse(lviX.SubItems[Index].Text, out X_value);
						result = X_value.CompareTo(Y_value);
					}
					break;
				case ValueType.String:
					{
						result = 
						String.Compare
							(
								((ListViewItem)x).SubItems[Index].Text,
								((ListViewItem)y).SubItems[Index].Text
							);
					}
					break;
				case ValueType.Memory:
					{
						double x_memory, y_memory;
						Double.TryParse(lviX.SubItems[Index].Text.Split(' ')[0], out x_memory);
						Double.TryParse(lviY.SubItems[Index].Text.Split(' ')[0], out y_memory);
						result = x_memory.CompareTo(y_memory);
					
					}
					break;

			}

			return direction == SortOrder.Ascending ? result : -result;
		}


		//public int Compare(object x, object y)
		//{
		//	return String.Compare(((ListViewItem)x).SubItems[column].Text,
		//						  ((ListViewItem)y).SubItems[column].Text);

		//	//if (column == 0)
		//	//	return int.Parse(((ListViewItem)x).SubItems[column].Text).CompareTo(int.Parse(((ListViewItem)y).SubItems[column].Text));
		//	//else
		//	//	return ((ListViewItem)x).SubItems[column].Text.CompareTo(((ListViewItem)y).SubItems[column].Text);

		//}


	}
}

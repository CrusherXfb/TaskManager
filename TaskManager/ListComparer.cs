using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TaskManager
{
	public class ListViewItemComparer : IComparer
	{
		public enum ColumnDataType
		{
			Long,
			Int,
			Short,
			Decimal,
			DateTime,
			String
		}

		private int _columnIndex;
		public int ColumnIndex
		{
			get
			{
				return _columnIndex;
			}
			set
			{
				_columnIndex = value;
			}
		}

		private SortOrder _sortDirection;
		public SortOrder SortDirection
		{
			get
			{
				return _sortDirection;
			}
			set
			{
				_sortDirection = value;
			}
		}

		private ColumnDataType _columnType;
		public ColumnDataType ColumnType
		{
			get
			{
				return _columnType;
			}
			set
			{
				_columnType = value;
			}
		}


		public ListViewItemComparer()
		{
			_sortDirection = SortOrder.None;
		}

		public int Compare(object x, object y)
		{
			ListViewItem lviX = x as ListViewItem;
			ListViewItem lviY = y as ListViewItem;

			int result;

			if (lviX == null && lviY == null)
			{
				result = 0;
			}
			else if (lviX == null)
			{
				result = -1;
			}

			else if (lviY == null)
			{
				result = 1;
			}

			switch (ColumnType)
			{
				case ColumnDataType.DateTime:
					DateTime xDt = DateTime.Parse(lviX.SubItems[ColumnIndex].Text);
					DateTime yDt = DateTime.Parse(lviY.SubItems[ColumnIndex].Text);
					result = DateTime.Compare(xDt, yDt);
					break;

				case ColumnDataType.Decimal:
					Decimal xD = decimal.Parse(lviX.SubItems[ColumnIndex].Text.Replace("$", string.Empty).Replace(",", string.Empty));
					Decimal yD = decimal.Parse(lviY.SubItems[ColumnIndex].Text.Replace("$", string.Empty).Replace(",", string.Empty));
					result = Decimal.Compare(xD, yD);
					break;
				case ColumnDataType.Short:
					short xShort = short.Parse(lviX.SubItems[ColumnIndex].Text);
					short yShort = short.Parse(lviY.SubItems[ColumnIndex].Text);
					result = xShort.CompareTo(yShort);
					break;
				case ColumnDataType.Int:
					int xInt = int.Parse(lviX.SubItems[ColumnIndex].Text);
					int yInt = int.Parse(lviY.SubItems[ColumnIndex].Text);
					result = xInt.CompareTo(yInt);
					break;
				case ColumnDataType.Long:
					long xLong = long.Parse(lviX.SubItems[ColumnIndex].Text);
					long yLong = long.Parse(lviY.SubItems[ColumnIndex].Text);
					result = xLong.CompareTo(yLong);
					break;
				default:

					result = string.Compare(
						lviX.SubItems[ColumnIndex].Text,
						lviY.SubItems[ColumnIndex].Text,
						false);

				break; 
			}
			if (SortDirection == SortOrder.Descending)
			{
				return -result;
			}
			else
			{
				return result;
			}
		}
	}









	/*
	internal class ListComparer:IComparer //Реализуем интерфейс IComparer
	{
		int column;

		public ListComparer(int column = 0)
		{
			this.column = column;
		}

		public int Compare(object x, object y)
		{
			return String.Compare(((ListViewItem)x).SubItems[column].Text,
								  ((ListViewItem)y).SubItems[column].Text);

			//if (column == 0)
			//	return int.Parse(((ListViewItem)x).SubItems[column].Text).CompareTo(int.Parse(((ListViewItem)y).SubItems[column].Text));
			//else
			//	return ((ListViewItem)x).SubItems[column].Text.CompareTo(((ListViewItem)y).SubItems[column].Text);

		}
		
	}

	*/
}

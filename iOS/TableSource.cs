//
// TableSource.cs
//
// Created by Thomas Dubiel on 20.12.2016
// Copyright 2016 Thomas Dubiel. All rights reserved.
//
using System;
using UIKit;

namespace MyMusic.iOS
{
	public class TableSource : UITableViewSource
	{
		string[] items;
		string cellId = "MyTableCell";

		ViewController controller;

		public TableSource(string[] items, ViewController controller)
		{
			this.items = items;
			this.controller = controller;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return items.Length;
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(cellId, indexPath);
			var item = items[indexPath.Row];

			//if (cell == null)
			//{
			//	cell = new UITableViewCell(UITableViewCellStyle.Default, cellId);
			//}

			cell.TextLabel.Text = item;
			return cell;
		}

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true);
			var item = items[indexPath.Row];
			controller.PlaySong(item);
		}
	}
}

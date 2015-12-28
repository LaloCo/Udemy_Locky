using Foundation;
using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using UIKit;
using Locky.Shared;

namespace Locky.iOS
{
	partial class PasswordsTableViewController : UITableViewController
	{
        List<Password> items;
		public PasswordsTableViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            items = new List<Password>();
        }

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            items = await Passwords.readPasswords();
            TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return items.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = TableView.DequeueReusableCell("passwordCell");

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, "passwordCell");
            }

            cell.TextLabel.Text = items[indexPath.Row].Name;

            return cell;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "detailsSegue")
            {
                var destinationViewController = segue.DestinationViewController as DetailsViewController;

                if (destinationViewController != null)
                {
                    destinationViewController.password = items[TableView.IndexPathForSelectedRow.Row].PasswordValue;
                }
            }
        }
	}
}

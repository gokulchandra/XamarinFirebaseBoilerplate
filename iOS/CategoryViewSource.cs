using System;
using FirstAppPCL;
using Foundation;
using UIKit;

namespace FirstApp.iOS
{
	public class CategoryViewSource : UITableViewSource
	{
		CourseCategoryManager courseCategoryManager  ;
		const String cellId = "categoryCell";
		public CategoryViewSource(CourseCategoryManager courseCategoryManager)
		{
			this.courseCategoryManager = courseCategoryManager;		
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellId);
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default,cellId);
			}
			courseCategoryManager.MoveTo(indexPath.Row);
			cell.TextLabel.Text = courseCategoryManager.Current.Title;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return courseCategoryManager.Length;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			courseCategoryManager.MoveTo(indexPath.Row);
			CoursePagerViewController coursesViewController = new CoursePagerViewController(courseCategoryManager.Current.Title);
			AppDelegate appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
			appDelegate.RootNavigationController.PushViewController(coursesViewController, true);
		}
	}
}

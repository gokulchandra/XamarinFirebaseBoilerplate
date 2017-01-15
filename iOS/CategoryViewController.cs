using System;
using FirstAppPCL;
using UIKit;

namespace FirstApp.iOS
{
	public partial class CategoryViewController : UITableViewController
	{
		CourseCategoryManager courseCategoryManager;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "Categories";

			courseCategoryManager = new CourseCategoryManager();
			UITableView tableView = this.View as UITableView;
			tableView.Source = new CategoryViewSource(courseCategoryManager);

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


using System;

using UIKit;
using FirstAppPCL;

namespace FirstApp.iOS
{
	public partial class CoursesViewController : UIViewController
	{
		public Course Course { get; set; }
		public int CurrentPosition { get; set; }

		public CoursesViewController() : base("CoursesViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			CourseName.Text = Course.Title;
			imageView.Image = UIImage.FromBundle(Course.Image);
			//NextButton.TouchUpInside += NextButton_TouchUpInside;
			//PreviousButton.TouchUpInside += PreviousButton_TouchUpInside;
		}

		void UIUpdate()
		{
			CourseName.Text = Course.Title;
			imageView.Image = UIImage.FromBundle(Course.Image);
			//NextButton.Enabled = courseManager.canMoveNext;
			//PreviousButton.Enabled = courseManager.canMovePrevious;
		}

		//void NextButton_TouchUpInside(object sender, EventArgs e)
		//{
		//	courseManager.MoveNext();
		//	UIUpdate();

		//}

		//void PreviousButton_TouchUpInside(object sender, EventArgs e)
		//{
		//	courseManager.MovePrevious();
		//	UIUpdate();
		//}


		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


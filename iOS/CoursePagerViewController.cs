using System;
using FirstAppPCL;
using UIKit;

namespace FirstApp.iOS
{
	public partial class CoursePagerViewController : UIViewController
	{
		UIPageViewController pageViewController;
		CourseManager courseManager;
		String categoryTitle;
		public CoursePagerViewController(String categoryTitle)
		{
			this.categoryTitle = categoryTitle;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			pageViewController = new UIPageViewController(
				UIPageViewControllerTransitionStyle.Scroll,
				UIPageViewControllerNavigationOrientation.Horizontal
			);
			pageViewController.View.Frame = View.Bounds;
			View.AddSubview(pageViewController.View);

			courseManager = new CourseManager(categoryTitle);
			courseManager.MoveFirst();

			//CoursesViewController firstCVC = CreateCourseViewController();
			CoursePagerViewControllerDataSource dataSource = new CoursePagerViewControllerDataSource(courseManager);
			pageViewController.DataSource = dataSource;

			CoursesViewController firstViewController = dataSource.GetFirstViewController();

			pageViewController.SetViewControllers(
				new UIViewController[] { firstViewController },
				UIPageViewControllerNavigationDirection.Forward,
				false,
				null
			);

			//pageViewController.GetNextViewController = GetNextViewController;
			//pageViewController.GetPreviousViewController = GetNextViewController;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		//CoursesViewController CreateCourseViewController()
		//{
		//	CoursesViewController coursesViewController = new CoursesViewController();
		//	coursesViewController.Course = courseManager.Current;
		//	coursesViewController.CurrentPosition = courseManager.CurrentPosition;
		//	return coursesViewController;
				
		//}

		//public UIViewController GetNextViewController(
		//	UIPageViewController pageViewController,
		//	UIViewController referenceViewController)
		//{
		//	CoursesViewController returnCourseViewController = null;
		//	CoursesViewController referenceCourseViewController = referenceViewController as CoursesViewController;
		//	if (referenceCourseViewController != null)
		//	{
		//		courseManager.MoveTo(referenceCourseViewController.CurrentPosition);
		//		if (courseManager.canMoveNext)
		//		{
		//			courseManager.MoveNext();
		//			returnCourseViewController = CreateCourseViewController();
		//		}
		//	}
		//	return returnCourseViewController;
		//}

		//public UIViewController GetPreviousViewController(
		//	UIPageViewController pageViewController,
		//	UIViewController referenceViewController)
		//{
		//	CoursesViewController returnCourseViewController = null;
		//	CoursesViewController referenceCourseViewController = referenceViewController as CoursesViewController;
		//	if (referenceCourseViewController != null)
		//	{
		//		courseManager.MoveTo(referenceCourseViewController.CurrentPosition);
		//		if (courseManager.canMovePrevious)
		//		{
		//			courseManager.MovePrevious();
		//			returnCourseViewController =  CreateCourseViewController();
		//		}
		//	}
		//	return returnCourseViewController;
		//}
	}
}


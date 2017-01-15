using System;
using FirstAppPCL;
using UIKit;

namespace FirstApp.iOS
{
	public class CoursePagerViewControllerDataSource : UIPageViewControllerDataSource
	{
		CourseManager courseManager;
		public CoursePagerViewControllerDataSource(CourseManager courseManager)
		{
			this.courseManager = courseManager;
		}

		public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			CoursesViewController returnCourseViewController = null;
			CoursesViewController referenceCourseViewController = referenceViewController as CoursesViewController;
			if (referenceCourseViewController != null)
			{
				courseManager.MoveTo(referenceCourseViewController.CurrentPosition);
				if (courseManager.canMoveNext)
				{
					courseManager.MoveNext();
					returnCourseViewController = CreateCourseViewController();
				}
			}
			return returnCourseViewController;
		}

		public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			CoursesViewController returnCourseViewController = null;
			CoursesViewController referenceCourseViewController = referenceViewController as CoursesViewController;
			if (referenceCourseViewController != null)
			{
				courseManager.MoveTo(referenceCourseViewController.CurrentPosition);
				if (courseManager.canMovePrevious)
				{
					courseManager.MovePrevious();
					returnCourseViewController = CreateCourseViewController();
				}
			}
			return returnCourseViewController;
		}

		internal CoursesViewController GetFirstViewController()
		{
			courseManager.MoveFirst();
			return CreateCourseViewController();
		}

		CoursesViewController CreateCourseViewController()
		{
			CoursesViewController coursesViewController = new CoursesViewController();
			coursesViewController.Course = courseManager.Current;
			coursesViewController.CurrentPosition = courseManager.CurrentPosition;
			return coursesViewController;

		}

	}
}

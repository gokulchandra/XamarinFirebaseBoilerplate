using System;
using Android.Support.V4.App;
using FirstAppPCL;

namespace FirstApp.Droid
{
	public class CoursePagerAdapter : FragmentStatePagerAdapter
	{
		CourseManager courseManager; 
		public CoursePagerAdapter(FragmentManager fm, CourseManager courseManager)
			:base(fm)
		{
			this.courseManager = courseManager;
		}

		public override int Count
		{
			get { return courseManager.Length; }
		}

		public override Fragment GetItem(int position)
		{
			courseManager.MoveTo(position);
			CourseFragment courseFragment = new CourseFragment();
			courseFragment.course = courseManager.Current;
			return courseFragment;
		}

		public CourseManager CourseManager
		{
			set
			{
				courseManager = value;
				NotifyDataSetChanged();
			}	
		}

		public override int GetItemPosition(Java.Lang.Object objectValue)
		{
			return PositionNone;
		}
	}
}

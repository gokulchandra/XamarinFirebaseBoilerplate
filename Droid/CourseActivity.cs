
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using FirstAppPCL;

namespace FirstApp.Droid
{
	[Activity(Label = "CourseActivity", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	//[Activity(Label = "CourseActivity")]
	public class CourseActivity : FragmentActivity
	{
		public const String DISPLAY_TITLE_INTENT_EXTRA = "titleExtra";
		CourseManager courseManager;
		CourseCategoryManager courseCategoryManager;
		CoursePagerAdapter coursePagerAdapter;
		ViewPager coursePager;
		DrawerLayout drawerLayout;
		ListView drawerListView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			courseCategoryManager = new CourseCategoryManager();
			courseCategoryManager.MoveFirst();
			String displayCategoryTitle = courseCategoryManager.Current.Title;
			//Intent startupIntent = this.Intent;
			//if (null != startupIntent)
			//{
			//	displayCategoryTitle = startupIntent.GetStringExtra(DISPLAY_TITLE_INTENT_EXTRA);
			//}


			SetContentView(Resource.Layout.CourseActivity);
			courseManager = new CourseManager(displayCategoryTitle);
			courseManager.MoveFirst();

			coursePagerAdapter = new CoursePagerAdapter(SupportFragmentManager, courseManager);

			coursePager = FindViewById<ViewPager>(Resource.Id.coursePager);
			coursePager.Adapter = coursePagerAdapter;

			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
			drawerListView = FindViewById<ListView>(Resource.Id.categoryDrawerListView);


			drawerListView.Adapter = new CourseCategoryManagerAdapter(
				this, Android.Resource.Layout.SimpleListItem1, courseCategoryManager);

			drawerListView.ItemClick += DrawerListView_ItemClick;

		}

		void DrawerListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			drawerLayout.CloseDrawer(drawerListView);

			courseCategoryManager.MoveTo(e.Position);
			courseManager = new CourseManager(courseCategoryManager.Current.Title);
			coursePagerAdapter.CourseManager = courseManager;

			coursePager.CurrentItem = 0;
		}
	}
}

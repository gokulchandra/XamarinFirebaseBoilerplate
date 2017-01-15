using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FirstAppPCL;

namespace FirstApp.Droid
{
	//[Activity(Label = "FirstApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{

		Button buttonPrevious;
		Button buttonNext;
		TextView courseTitle;
		ImageView imageView;
		TextView textDescription;
		CourseManager courseManager;

		void UpdateUI()
		{
			
			courseTitle.Text = courseManager.Current.Title;
			textDescription.Text = courseManager.Current.Description;
			imageView.SetImageResource(ResourceHelper.TranslateDrawableUsingReflection(courseManager.Current.Image));
			buttonPrevious.Enabled = courseManager.canMovePrevious;
			buttonNext.Enabled = courseManager.canMoveNext;

		}

		void ButtonPrevious_Click(object sender, EventArgs e)
		{
			courseManager.MovePrevious();
			UpdateUI();

		}

		void ButtonNext_Click(object sender, EventArgs e)
		{
			courseManager.MoveNext();
			UpdateUI();
		}

		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());

			SetContentView(Resource.Layout.Courses);

			buttonPrevious = FindViewById<Button>(Resource.Id.buttonPrevious);
			buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
			courseTitle = FindViewById<TextView>(Resource.Id.courseTextView);
			imageView = FindViewById<ImageView>(Resource.Id.imageView);
			textDescription = FindViewById<TextView>(Resource.Id.smallTextView);

			courseManager = new CourseManager("");

			buttonPrevious.Click += ButtonPrevious_Click;
			buttonNext.Click += ButtonNext_Click;


		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FirstApp.Droid
{
	[Activity(Label = "Courses")]
	public class Courses : Activity
	{
		void ButtonPrevious_Click(object sender, EventArgs e)
		{
			courseTitle.Text = "Prev Clicked!";
		}

		void ButtonNext_Click(object sender, EventArgs e)
		{
			courseTitle.Text = "Next Clicked!";
		}

		Button buttonPrevious;
		Button buttonNext;
		TextView courseTitle;
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Courses);

			buttonPrevious = FindViewById<Button>(Resource.Id.buttonPrevious);
			buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
			courseTitle = FindViewById<TextView>(Resource.Id.courseTextView);

			buttonPrevious.Click += ButtonPrevious_Click;
			buttonNext.Click += ButtonNext_Click;
		

		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using FirstAppPCL;

namespace FirstApp.Droid
{
	public class CourseFragment : Fragment
	{
		public Course course { get; set; }
		TextView courseTitle;
		ImageView imageView;
		TextView textDescription;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			View rootView =  inflater.Inflate(Resource.Layout.CourseFragment, container, false);

			courseTitle = rootView.FindViewById<TextView>(Resource.Id.courseTextView);
			imageView = rootView.FindViewById<ImageView>(Resource.Id.imageView);
			textDescription = rootView.FindViewById<TextView>(Resource.Id.smallTextView);

			courseTitle.Text = course.Title;
			textDescription.Text = course.Description;
			imageView.SetImageResource(ResourceHelper.TranslateDrawableUsingReflection(course.Image));

			return rootView;

			//return base.OnCreateView(inflater, container, savedInstanceState);
		}
	}
}

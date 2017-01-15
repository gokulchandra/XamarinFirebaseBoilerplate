using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using FirstAppPCL;

namespace FirstApp.Droid
{
	public class CourseCategoryManagerAdapter : BaseAdapter<CourseCategory>
	{
		CourseCategoryManager courseCategoryManager;

		Context context;

		int layoutResourceId;


		public CourseCategoryManagerAdapter(Context context, 
    		int layoutResourceId, CourseCategoryManager courseCategoryManager)
		{
			this.context = context;
			this.layoutResourceId = layoutResourceId;
			this.courseCategoryManager = courseCategoryManager;
		}

		public override CourseCategory this[int position]
		{
			get
			{
				courseCategoryManager.MoveTo(position);
				return courseCategoryManager.Current;
			}
		}

		public override int Count
		{
			get
			{
				return courseCategoryManager.Length;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (convertView == null)
			{
				LayoutInflater inflater = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
				view = inflater.Inflate(layoutResourceId, null);
			}
			TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
			textView.Text = this[position].Title;
			return view;
		}
	}
}

using System;
namespace FirstAppPCL
{
	public class CourseCategoryManager
	{
		public CourseCategoryManager()
		{
			categories = InitCourseCategories();
			lastIndex = categories.Length - 1;
		}

		private readonly CourseCategory[] categories;
		private int currentIndex = 0;
		private readonly int lastIndex;

		private CourseCategory[] InitCourseCategories()
		{
			var initCategories = new CourseCategory[] {
				new CourseCategory{
					Title = "Android",
					Description = "Description 1"
				},
				new CourseCategory{
					Title = "Windows",
					Description = "Description 2"

				},
				new CourseCategory{
					Title = "iOS",
					Description = "Description 3"
				}
			};

			return initCategories;
		}

		public void MoveFirst()
		{
			currentIndex = 0;
		}

		public void MoveNext()
		{
			if (currentIndex <= lastIndex)
				currentIndex++;
		}

		public void MovePrevious()
		{
			if (currentIndex > 0)
				currentIndex--;
		}

		public void MoveTo(int position)
		{
			if (position >= 0 && position <= lastIndex)
				currentIndex = position;
			else {
				throw new IndexOutOfRangeException(
					String.Format("{0} is an invalid position. Must be between 0 and {1}",
								  position, lastIndex)
				);
			}
		}

		public int Length
		{
			get { return categories.Length; }
		}

		public Boolean canMovePrevious
		{
			get { return currentIndex > 0; }
		}

		public Boolean canMoveNext
		{
			get { return currentIndex < lastIndex; }
		}


		public CourseCategory Current
		{
			get { return categories[currentIndex]; }
		}

		public int CurrentPosition
		{
			get { return currentIndex; }
		}
	}

}

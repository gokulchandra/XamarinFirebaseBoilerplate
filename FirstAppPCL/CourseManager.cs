using System;
namespace FirstAppPCL
{
	public class CourseManager
	{
		private readonly Course[] courses;
		private int currentIndex = 0;
		private readonly int lastIndex;
		public CourseManager(String category)
		{
			switch (category)
			{
				case "Android":
					courses =InitCourses("Android");
					break;
				case "iOS":
					courses =InitCourses("IOS");
					break;
				case "Windows":
					courses =InitCourses("Windows");
					break;
				default:
					courses = InitCourses("");
					break;
			}

			lastIndex = courses.Length -1;
		}



		private Course[] InitCourses(String category)
		{
			var initCourses = new Course[] { 
				new Course{
					Title = category + "Title 1",
					Description = category + "Description 1",
					Image = "shirt_1"
				},
				new Course{
					Title = category + "Title 2",
					Description = category + "Description 2",
					Image = "shirt_2"
				},
				new Course{
					Title = category + "Title 3",
					Description = category + "Description 3",
					Image = "shirt_3"
				}
			};

			return initCourses;
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
			if (currentIndex > 0 )
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
			get { return courses.Length; }
		}

		public Boolean canMovePrevious
		{
			get { return currentIndex > 0; }
		}

		public Boolean canMoveNext
		{
			get { return currentIndex < lastIndex; }
		}


		public Course Current
		{
			get { return courses[currentIndex]; }
		}

		public int CurrentPosition
		{
			get { return currentIndex; }
		}
	}
}

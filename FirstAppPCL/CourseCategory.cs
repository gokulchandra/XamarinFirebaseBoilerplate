﻿using System;
namespace FirstAppPCL
{
	public class CourseCategory
	{
		public CourseCategory()
		{
		}

		public String Title { get; internal set; }
		public String Description { get; internal set; }

		public String ToString()
		{
			return this.Title;
		}
	}
}

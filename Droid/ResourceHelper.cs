using System;
using System.Collections.Generic;
using System.Reflection;
using Java.Lang.Reflect;

namespace FirstApp.Droid
{
	public static class ResourceHelper
	{
		static Dictionary<String, int> resourceDict = new Dictionary<string, int>();
		public static int TranslateDrawable(String drawableName)
		{
			int resourceValue = -1;
			switch (drawableName)
			{
				case "shirt_1":
					resourceValue = Resource.Drawable.shirt_1;
					break;
				case "shirt_2":
					resourceValue = Resource.Drawable.shirt_2;
					break;
				case "shirt_3":
					resourceValue = Resource.Drawable.shirt_3;
					break;
			}
			return resourceValue;
		}

		public static int TranslateDrawableUsingReflection(String drawableName)
		{
			int resourceValue = -1;
			if (resourceDict.ContainsKey(drawableName))
			{
				resourceValue = resourceDict[drawableName];
			}
			else {
				Type resourceType = typeof(Resource.Drawable);
				FieldInfo fieldName = resourceType.GetField(drawableName);
				resourceValue = (int)fieldName.GetValue(null);
				resourceDict.Add(drawableName, resourceValue);
			}

			return resourceValue;
		}
	}
}

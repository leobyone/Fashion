using Fashion.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Fashion.Common
{
	public static class Util
	{
		public static List<Condition> ConvertCodiontions(string conditions)
		{
			return JArray.Parse(HttpUtility.UrlDecode(conditions)).ToObject<List<Condition>>();
		}

		public static List<Sort> ConvertSorts(string sorts)
		{
			return JArray.Parse(HttpUtility.UrlDecode(sorts)).ToObject<List<Sort>>();
		}

		public static string GetSortString(string sorts)
		{
			string result = "";
			List<Sort> sortList = ConvertSorts(sorts);
			foreach (var item in sortList)
			{
				if ((int)SortEnum.ASC == item.SortBy)
				{
					result += item.Field + " ASC";
				}
				else if ((int)SortEnum.DESC == item.SortBy)
				{
					result += item.Field + " DESC";
				}
			}

			return result;
		}
	}
}

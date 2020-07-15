﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fashion.Common.Helper
{
	/// <summary>
	/// 泛型递归求树形结构
	/// </summary>
	public static class RecursionHelper
	{
		public static void LoopToAppendChildren(List<PermissionTree> all, PermissionTree curItem, int pid, bool needbtn)
		{

			var subItems = all.Where(ee => ee.Pid == curItem.value).ToList();

			var btnItems = subItems.Where(ss => ss.isbtn == true).ToList();
			if (subItems.Count > 0)
			{
				curItem.btns = new List<PermissionTree>();
				curItem.btns.AddRange(btnItems);
			}
			else
			{
				curItem.btns = null;
			}

			if (!needbtn)
			{
				subItems = subItems.Where(ss => ss.isbtn == false).ToList();
			}
			if (subItems.Count > 0)
			{
				curItem.children = new List<PermissionTree>();
				curItem.children.AddRange(subItems);
			}
			else
			{
				curItem.children = null;
			}

			if (curItem.isbtn)
			{
				//curItem.label += "按钮";
			}

			foreach (var subItem in subItems)
			{
				if (subItem.value == pid && pid > 0)
				{
					//subItem.disabled = true;//禁用当前节点
				}
				LoopToAppendChildren(all, subItem, pid, needbtn);
			}
		}



		public static void LoopNaviBarAppendChildren(List<NavigationBar> all, NavigationBar curItem)
		{

			var subItems = all.Where(ee => ee.pid == curItem.id).ToList();

			if (subItems.Count > 0)
			{
				curItem.children = new List<NavigationBar>();
				curItem.children.AddRange(subItems);
			}
			else
			{
				curItem.children = null;
			}


			foreach (var subItem in subItems)
			{
				LoopNaviBarAppendChildren(all, subItem);
			}
		}

		public static void LoopRouterAppendChildren(List<Router> routers, List<Router> newRouters, int parendId)
		{
			var list = routers.Where(r => r.pid == parendId).ToList();
			newRouters.AddRange(list);

			foreach (var item in list)
			{
				if (parendId == 0)
				{
					item.component = "Layout";
				}
				else
				{
					item.component = item.component;
				}
			}

			foreach (var child in newRouters)
			{
				child.children = new List<Router>();
				LoopRouterAppendChildren(routers, child.children, child.id);
			}
		}



		public static void LoopToAppendChildrenT<T>(List<T> all, T curItem, string parentIdName = "Pid", string idName = "value", string childrenName = "children")
		{
			var subItems = all.Where(ee => ee.GetType().GetProperty(parentIdName).GetValue(ee, null).ToString() == curItem.GetType().GetProperty(idName).GetValue(curItem, null).ToString()).ToList();

			if (subItems.Count > 0) curItem.GetType().GetField(childrenName).SetValue(curItem, subItems);
			foreach (var subItem in subItems)
			{
				LoopToAppendChildrenT(all, subItem);
			}
		}
	}

	public class PermissionTree
	{
		public int value { get; set; }
		public int Pid { get; set; }
		public string label { get; set; }
		public int order { get; set; }
		public bool isbtn { get; set; }
		public bool disabled { get; set; }
		public List<PermissionTree> children { get; set; }
		public List<PermissionTree> btns { get; set; }
	}

	public class NavigationBar
	{
		public int id { get; set; }
		public int pid { get; set; }
		public int order { get; set; }
		public string name { get; set; }
		public bool ishide { get; set; } = false;
		public string path { get; set; }
		public string iconCls { get; set; }
		public NavigationBarMeta meta { get; set; }
		public List<NavigationBar> children { get; set; }
	}

	public class NavigationBarMeta
	{
		public string title { get; set; }
		public string icon { get; set; }
	}

	public class Router
	{
		public int id { get; set; }
		public int pid { get; set; }
		public string path { get; set; }
		public string component { get; set; }
		public string name { get; set; }
		public bool ishide { get; set; } = false;
		public Meta meta { get; set; }
		public List<Router> children { get; set; }
	}

	public class Meta
	{
		public string title { get; set; }
		public string icon { get; set; }
	}
}

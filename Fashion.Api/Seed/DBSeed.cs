using Fashion.Model.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Fashion.Api.Seed
{
	public class DBSeed
	{
		private static string GitJsonFileFormat = "https://github.com/anjoy8/Blog.Data.Share/raw/master/ .Data.json/{0}.tsv";
		/// <summary>
		/// 异步添加种子数据
		/// </summary>
		/// <param name="myContext"></param>
		/// <returns></returns>
		public static async Task SeedAsync(MyContext myContext)
		{
			try
			{
				// 如果生成过了，第二次，就不用再执行一遍了,注释掉该方法即可

				#region 自动创建数据库暂停服务
				// 自动创建数据库，注意版本是 sugar 5.x 版本的

				// 注意：这里还是有些问题，比如使用mysql的话，如果通过这个方法创建空数据库，字符串不是utf8的，所以还是手动创建空的数据库吧，然后设置数据库为utf-8，我再和作者讨论一下。
				// 但是使用SqlServer 和 Sqlite 好像没有这个问题。
				//myContext.Db.DbMaintenance.CreateDatabase(); 
				#endregion


				// 创建表
				myContext.CreateTableByEntity(false,
					typeof(Module),
					typeof(ModulePermission),
					typeof(OperateLog),
					typeof(Permission),
					typeof(Role),
					typeof(RoleModulePermission),
					typeof(User),
					typeof(UserRole),
					typeof(Product),
					typeof(ProductSku),
					typeof(ProductImage),
					typeof(Brand),
					typeof(Category),
					typeof(Fashion.Model.Models.Attribute),
					typeof(AttributeGroup),
					typeof(AttributeValue));

				// 后期单独处理某些表
				//myContext.Db.CodeFirst.InitTables(typeof(sysUserInfo));
				//myContext.Db.CodeFirst.InitTables(typeof(Permission)); 
				//myContext.Db.CodeFirst.InitTables(typeof(Advertisement));

				Console.WriteLine("Database:WMBlog created success!");
				Console.WriteLine();

				Console.WriteLine("Seeding database...");

				//#region Module
				//List<Module> modules = new List<Module>();
				//modules.Add(new Module() { s})
				//if (!await myContext.Db.Queryable<Module>().AnyAsync())
				//{
				//	myContext.GetEntityDB<Module>().InsertRange(JsonHelper.ParseFormByJson<List<Module>>(GetNetData.Get(string.Format(GitJsonFileFormat, "Module"))));
				//	Console.WriteLine("Table:Module created success!");
				//}
				//else
				//{
				//	Console.WriteLine("Table:Module already exists...");
				//}
				//#endregion


				#region Permission
				List<Permission> permissions = new List<Permission>();
				var home = new Permission()
				{
					Code = "-",
					Name = "首页",
					IsButton = false,
					IsHide = false,
					Action = "",
					ParentId = 0,
					ModuleId = 0,
					OrderSort = 1,
					Icon = "fa-qq",
					Enabled = true,
					CreationTime = DateTime.Now,
					LastModificationTime = DateTime.Now
				};
				myContext.GetEntityDB<Permission>().Insert(home);
				var system = new Permission()
				{
					Code = "-",
					Name = "系统管理",
					IsButton = false,
					IsHide = false,
					Action = "",
					ParentId = 0,
					ModuleId = 0,
					OrderSort = 1,
					Icon = "fa-users",
					Enabled = true,
					CreationTime = DateTime.Now,
					LastModificationTime = DateTime.Now
				};
				myContext.GetEntityDB<Permission>().Insert(system);
				permissions.Add(new Permission()
				{
					Code = "/User/List",
					Name = "用户管理",
					IsButton = false,
					IsHide = false,
					Action = "",
					ParentId = system.Id,
					ModuleId = 0,
					OrderSort = 1,
					Enabled = true,
					CreationTime = DateTime.Now,
					LastModificationTime = DateTime.Now
				});
				permissions.Add(new Permission()
				{
					Code = "/Module/List",
					Name = "接口管理",
					IsButton = false,
					IsHide = false,
					Action = "",
					ParentId = system.Id,
					ModuleId = 0,
					OrderSort = 1,
					Enabled = true,
					CreationTime = DateTime.Now,
					LastModificationTime = DateTime.Now
				});
				permissions.Add(new Permission()
				{
					Code = "/Permission/List",
					Name = "菜单管理",
					IsButton = false,
					IsHide = false,
					Action = "",
					ParentId = system.Id,
					ModuleId = 0,
					OrderSort = 1,
					Enabled = true,
					CreationTime = DateTime.Now,
					LastModificationTime = DateTime.Now
				});

				myContext.GetEntityDB<Permission>().InsertRange(permissions);
				Console.WriteLine("Table:Permission created success!");

				#endregion

				#region Role
				List<Role> roles = new List<Role>();
				roles.Add(new Role()
				{
					Name = "SuperAdmin",
					Description = "超级管理员",
					OrderSort = 1,
					Enabled = true,
					CreationTime = DateTime.Now,
					LastModificationTime = DateTime.Now
				});
				roles.Add(new Role()
				{
					Name = "Admin",
					Description = "普通管理员",
					OrderSort = 2,
					Enabled = true,
					CreationTime = DateTime.Now,
					LastModificationTime = DateTime.Now
				});
				if (!await myContext.Db.Queryable<Role>().AnyAsync())
				{
					myContext.GetEntityDB<Role>().InsertRange(roles);
					Console.WriteLine("Table:Role created success!");
				}
				else
				{
					Console.WriteLine("Table:Role already exists...");
				}
				#endregion

				#region RoleModulePermission
				List<RoleModulePermission> roleModulePermissions = new List<RoleModulePermission>();
				roleModulePermissions.Add(new RoleModulePermission()
				{
					RoleId = 1,
					ModuleId = 0,
					PermissionId = 1,
					CreationTime = DateTime.Now
				});
				roleModulePermissions.Add(new RoleModulePermission()
				{
					RoleId = 1,
					ModuleId = 0,
					PermissionId = 2,
					CreationTime = DateTime.Now
				});
				roleModulePermissions.Add(new RoleModulePermission()
				{
					RoleId = 1,
					ModuleId = 0,
					PermissionId = 3,
					CreationTime = DateTime.Now
				});
				if (!await myContext.Db.Queryable<RoleModulePermission>().AnyAsync())
				{
					myContext.GetEntityDB<RoleModulePermission>().InsertRange(roleModulePermissions);
					Console.WriteLine("Table:RoleModulePermission created success!");
				}
				else
				{
					Console.WriteLine("Table:RoleModulePermission already exists...");
				}
				#endregion

				#region UserRole
				List<UserRole> userRoles = new List<UserRole>();
				userRoles.Add(new UserRole()
				{
					UserId = 1,
					RoleId = 1,
					CreationTime = DateTime.Now,
					LastModificationTime = DateTime.Now
				});
				if (!await myContext.Db.Queryable<UserRole>().AnyAsync())
				{
					myContext.GetEntityDB<UserRole>().InsertRange(userRoles);
					Console.WriteLine("Table:UserRole created success!");
				}
				else
				{
					Console.WriteLine("Table:UserRole already exists...");
				}
				#endregion

				#region User
				List<User> users = new List<User>();
				users.Add(new User()
				{
					LoginName = "admin",
					Password = "E1ADC3949BA59ABBE56E057F2F883E",
					Status = 1,
					CreationTime = DateTime.Now,
					LastModificationTime = DateTime.Now,
					LastLoginTime = DateTime.Now,
					LoginErrorCount = 0
				});
				if (!await myContext.Db.Queryable<User>().AnyAsync())
				{
					myContext.GetEntityDB<User>().InsertRange(users);
					Console.WriteLine("Table:sysUserInfo created success!");
				}
				else
				{
					Console.WriteLine("Table:sysUserInfo already exists...");
				}
				#endregion

				Console.WriteLine("Done seeding database.");
				Console.WriteLine();

			}
			catch (Exception ex)
			{
				throw new Exception("1、注意要先创建空的数据库\n2、" + ex.Message);
			}
		}
	}
}

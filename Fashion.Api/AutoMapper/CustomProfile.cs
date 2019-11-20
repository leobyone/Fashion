using AutoMapper;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashion.Api.AutoMapper
{
	public class CustomProfile : Profile
	{
		/// <summary>
		/// 配置构造函数，用来创建关系映射
		/// </summary>
		public CustomProfile()
		{
			CreateMap<User, UserDto>();
			CreateMap<UserDto, User>();
			CreateMap<Role, RoleDto>();
			CreateMap<RoleDto, Role>();
			CreateMap<Module, ModuleDto>();
			CreateMap<ModuleDto, Module>();
			CreateMap<Permission, PermissionDto>();
			CreateMap<PermissionDto, Permission>();
		}
	}
}

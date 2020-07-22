using AutoMapper;
using Fashion.Common;
using Fashion.Common.Helper;
using Fashion.IRepository;
using Fashion.IRepositoty;
using Fashion.IServices;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Services
{
	public class UserServices : BaseServices<User>, IUserServices
	{
		private IUserRepository _userRepository;
		private IUserRoleRepository _userRoleRepository;
		private IRoleRepository _roleRepository;
		private IMapper _mapper;

		public UserServices(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_userRoleRepository = userRoleRepository;
			_roleRepository = roleRepository;
			_mapper = mapper;
			baseRepository = userRepository;
		}

		public async Task<UserDto> GetUserById(int id)
		{
			var model = await baseRepository.QueryById(id);
			var dto = _mapper.Map<UserDto>(model);

			var userRoleList = await _userRoleRepository.Query(t => t.UserId == id && t.IsDeleted == false);
			foreach (var item in userRoleList)
			{
				dto.RoleIds = item.RoleId + ",";
			}

			if (!string.IsNullOrEmpty(dto.RoleIds))
			{
				dto.RoleIds = dto.RoleIds.Substring(0, dto.RoleIds.Length - 1);
			}

			return dto;
		}

		public async Task<List<User>> GetUsersByNameAndPwd(string name, string pwd)
		{
			var list = await baseRepository.Query(t => t.LoginName == name && t.Password == pwd);
			return list;
		}

		public async Task<PageModel<UserDto>> GetPageList(int page, int size, string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<User>(conditionList);
			var pageModel = await baseRepository.QueryPage(where, page, size, sort);
			var mapList = _mapper.Map<List<User>, List<UserDto>>(pageModel.data);

			return new PageModel<UserDto>()
			{
				page = pageModel.page,
				dataCount = pageModel.dataCount,
				pageCount = pageModel.pageCount,
				PageSize = pageModel.page,
				data = mapList
			};
		}

		public async Task<List<UserDto>> GetList(string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<User>(conditionList);
			var list = await baseRepository.Query(where);
			return _mapper.Map<List<User>, List<UserDto>>(list);
		}

		[UseTran]
		public async Task<int> AddUser(User user)
		{
			int userId = 0;
			userId = await Add(user);

			if (!string.IsNullOrEmpty(user.RoleIds))
			{
				var arr = user.RoleIds.Split(",");
				UserRole userRole = new UserRole();
				foreach (var item in arr)
				{
					userRole.UserId = userId;
					userRole.RoleId = Convert.ToInt32(item);
					await _userRoleRepository.Add(userRole);
				}
			}

			return userId;
		}

		[UseTran]
		public async Task<bool> UpdateUser(UserDto dto)
		{
			int userId = dto.Id;
			var entity = await _userRepository.QueryById(userId);
			var pwd = entity.Password;
			entity = _mapper.Map<User>(dto);
			entity.Password = pwd;
			entity.LastModificationTime = DateTime.Now;
			await _userRepository.Update(entity);

			if (!string.IsNullOrEmpty(dto.RoleIds))
			{
				//先删除已有的用户角色
				await _userRoleRepository.Delete(t => t.UserId == userId);

				var arr = dto.RoleIds.Split(",");
				UserRole userRole = new UserRole();
				foreach (var item in arr)
				{
					userRole.UserId = userId;
					userRole.RoleId = Convert.ToInt32(item);
					await _userRoleRepository.Add(userRole);
				}
			}

			return true;
		}

		[UseTran]
		public async Task<bool> DeleteUser(int userId)
		{
			var user = await _userRepository.QueryById(userId);
			user.IsDeleted = true;
			await _userRepository.Update(user);

			if (!string.IsNullOrEmpty(user.RoleIds))
			{
				//先删除已有的用户角色
				await _userRoleRepository.Delete(t => t.UserId == userId);
			}

			return true;
		}

		public async Task<string> GetRoleNames(string name, string pwd)
		{
			var roleNames = "";
			var list = await baseRepository.Query(t => t.LoginName == name && t.Password == pwd);
			if (list.Count > 0)
			{
				var user = list[0];
				var roleList = await _roleRepository.GetRoleListByUserId(user.Id);

				if (roleList.Count > 0)
				{
					foreach (var item in roleList)
					{
						roleNames += item.Name + ",";
					}

					roleNames = roleNames.Substring(0, roleNames.Length - 1);
				}
			}

			return roleNames;
		}
	}
}

using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.IServices
{
	public interface IUserServices: IBaseServices<User>
	{
		Task<UserDto> GetUserById(int id);

		Task<List<User>> GetUsersByNameAndPwd(string name, string pwd);

		Task<PageModel<UserDto>> GetPageList(int page, int size, string conditions, string sorts);

		Task<int> AddUser(User user);

		Task<bool> UpdateUser(UserDto user);

		Task<bool> DeleteUser(int userId);

		Task<string> GetRoleNames(string name, string pwd);
	}
}

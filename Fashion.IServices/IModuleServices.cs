using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;

namespace Fashion.IServices
{	
	/// <summary>
	/// ModuleServices
	/// </summary>	
    public interface IModuleServices :IBaseServices<Module>
	{
		Task<ModuleDto> GetModuleById(int id);
		Task<List<ModuleDto>> GetList(string conditions, string sorts);
		Task<PageModel<ModuleDto>> GetPageList(int page, int size, string conditions, string sorts);
	}
}

	
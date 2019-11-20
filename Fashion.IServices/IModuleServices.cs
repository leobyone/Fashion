using System;
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
		Task<PageModel<ModuleDto>> GetPageList(int page, int size, string keyword);
	}
}

	
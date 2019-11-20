using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;
using AutoMapper;
using System.Threading.Tasks;
using Fashion.Model;
using Fashion.Model.Dtos;
using System.Collections.Generic;

namespace Fashion.Services
{	
	/// <summary>
	/// ModuleServices
	/// </summary>	
	public class ModuleServices : BaseServices<Module>, IModuleServices
    {
        IModuleRepository repository;
		IMapper _mapper;

        public ModuleServices(IModuleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            baseRepository = repository;
			_mapper = mapper;
        }

		public async Task<ModuleDto> GetModuleById(int id)
		{
			var model = await baseRepository.QueryById(id);
			var dto = _mapper.Map<ModuleDto>(model);
			return dto;
		}

		public async Task<PageModel<ModuleDto>> GetPageList(int page, int size, string keyword)
		{
			var pageModel = await QueryPage(t => t.IsDeleted == false && (t.Name != null && t.Name.Contains(keyword)), page, size, "Id desc");
			var mapList = _mapper.Map<List<Module>, List<ModuleDto>>(pageModel.data);

			return new PageModel<ModuleDto>()
			{
				page = pageModel.page,
				dataCount = pageModel.dataCount,
				pageCount = pageModel.pageCount,
				PageSize = pageModel.page,
				data = mapList
			};
		}
	}
}

	
using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;
using AutoMapper;
using System.Threading.Tasks;
using Fashion.Model;
using Fashion.Model.Dtos;
using System.Collections.Generic;
using Fashion.Common;
using Fashion.Common.Helper;

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

		public async Task<List<ModuleDto>> GetList(string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Module>(conditionList);
			var list = await baseRepository.Query(where);
			return _mapper.Map<List<Module>, List<ModuleDto>>(list);
		}

		public async Task<PageModel<ModuleDto>> GetPageList(int page, int size, string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Module>(conditionList);
			var pageModel = await baseRepository.QueryPage(where, page, size, sort);
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

	
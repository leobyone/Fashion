using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;
using Fashion.Model;
using Fashion.Model.Dtos;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using Fashion.Common;
using Fashion.Common.Helper;

namespace Fashion.Services
{	
	/// <summary>
	/// CategoryServices
	/// </summary>	
	public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        ICategoryRepository repository;
		IMapper _mapper;

		public CategoryServices(ICategoryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            baseRepository = repository;
			_mapper = mapper;
        }

		public async Task<CategoryDto> GetCategoryById(int id)
		{
			var model = await baseRepository.QueryById(id);
			var dto = _mapper.Map<CategoryDto>(model);
			return dto;
		}

		public async Task<List<CategoryDto>> GetList(string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Category>(conditionList);
			var list = await baseRepository.Query(where);
			return _mapper.Map<List<Category>, List<CategoryDto>>(list);
		}

		public async Task<PageModel<CategoryDto>> GetPageList(int page, int size, string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Category>(conditionList);
			var pageModel = await baseRepository.QueryPage(where, page, size, sort);
			var mapList = _mapper.Map<List<Category>, List<CategoryDto>>(pageModel.data);

			return new PageModel<CategoryDto>()
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

	
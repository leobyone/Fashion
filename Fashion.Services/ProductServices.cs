


using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;
using AutoMapper;
using Fashion.Model.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;
using Fashion.Model;
using Fashion.Common;
using Fashion.Common.Helper;

namespace Fashion.Services
{
	/// <summary>
	/// ProductServices
	/// </summary>	
	public class ProductServices : BaseServices<Product>, IProductServices
	{
		IProductRepository repository;
		IMapper _mapper;

		public ProductServices(IProductRepository repository, IMapper mapper)
		{
			this.repository = repository;
			baseRepository = repository;
			_mapper = mapper;
		}

		public async Task<ProductDto> GetProductById(int id)
		{
			var model = await baseRepository.QueryById(id);
			var dto = _mapper.Map<ProductDto>(model);
			return dto;
		}

		public async Task<List<ProductDto>> GetList(string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Product>(conditionList);
			var list = await baseRepository.Query(where);
			return _mapper.Map<List<Product>, List<ProductDto>>(list);
		}

		public async Task<PageModel<ProductDto>> GetPageList(int page, int size, string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Product>(conditionList);
			var pageModel = await baseRepository.QueryPage(where, page, size, sort);
			var mapList = _mapper.Map<List<Product>, List<ProductDto>>(pageModel.data);

			return new PageModel<ProductDto>()
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


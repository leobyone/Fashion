using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fashion.IServices;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class CategoryController : ControllerBase
	{
		ICategoryServices _categoryServices;
		public CategoryController(ICategoryServices categoryServices)
		{
			_categoryServices = categoryServices;
		}

		[HttpGet]
		public async Task<MessageModel<CategoryDto>> Get(int id)
		{
			var data = new MessageModel<CategoryDto>();
			var category = await _categoryServices.GetCategoryById(id);

			if (category != null)
			{
				data.data = category;
				data.success = true;
				data.msg = "获取成功";
			}

			return data;
		}

		[HttpPost]
		public async Task<MessageModel<string>> Post([FromBody] Category category)
		{
			var data = new MessageModel<string>();

			var id = (await _categoryServices.Add(category));
			data.success = id > 0;
			if (data.success)
			{
				data.msg = "添加成功";
				data.data = id.ObjToString();
			}

			return data;
		}

		[HttpPut]
		public async Task<MessageModel<string>> Update([FromBody] Category category)
		{
			var data = new MessageModel<string>();
			if (category != null && category.Id > 0)
			{
				data.success = await _categoryServices.Update(category);
				if (data.success)
				{
					data.msg = "更新成功";
					data.data = category?.Id.ObjToString();
				}
			}

			return data;
		}

		[HttpDelete]
		public async Task<MessageModel<string>> Delete(int id)
		{
			var data = new MessageModel<string>();
			if (id > 0)
			{
				var category = await _categoryServices.QueryById(id);
				category.IsDeleted = true;
				data.success = await _categoryServices.Update(category);
				if (data.success)
				{
					data.msg = "删除成功";
					data.data = category?.Id.ObjToString();
				}
			}

			return data;
		}

		[HttpGet]
		[Route("list")]
		public async Task<MessageModel<List<CategoryDto>>> GetList(string conditions, string sorts)
		{
			var list = await _categoryServices.GetList(conditions, sorts);
			return new MessageModel<List<CategoryDto>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}

		[HttpGet]
		[Route("pagelist")]
		public async Task<MessageModel<PageModel<CategoryDto>>> GetPageList(int page, int size, string conditions, string sorts)
		{
			var list = await _categoryServices.GetPageList(page, size, conditions, sorts);
			return new MessageModel<PageModel<CategoryDto>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}
	}
}
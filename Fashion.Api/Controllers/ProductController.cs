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
	public class ProductController : ControllerBase
	{
		IProductServices _productServices;
		public ProductController(IProductServices productServices)
		{
			_productServices = productServices;
		}

		[HttpGet]
		public async Task<MessageModel<ProductDto>> Get(int id)
		{
			var data = new MessageModel<ProductDto>();
			var product = await _productServices.GetProductById(id);

			if (product != null)
			{
				data.data = product;
				data.success = true;
				data.msg = "获取成功";
			}

			return data;
		}

		[HttpPost]
		public async Task<MessageModel<string>> Post([FromBody] Product product)
		{
			var data = new MessageModel<string>();

			var id = (await _productServices.Add(product));
			data.success = id > 0;
			if (data.success)
			{
				data.msg = "添加成功";
				data.data = id.ObjToString();
			}

			return data;
		}

		[HttpPut]
		public async Task<MessageModel<string>> Update([FromBody] Product product)
		{
			var data = new MessageModel<string>();
			if (product != null && product.Id > 0)
			{
				data.success = await _productServices.Update(product);
				if (data.success)
				{
					data.msg = "更新成功";
					data.data = product?.Id.ObjToString();
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
				var product = await _productServices.QueryById(id);
				product.IsDeleted = true;
				data.success = await _productServices.Update(product);
				if (data.success)
				{
					data.msg = "删除成功";
					data.data = product?.Id.ObjToString();
				}
			}

			return data;
		}

		[HttpGet]
		[Route("list")]
		public async Task<MessageModel<List<ProductDto>>> GetList(string conditions, string sorts)
		{
			var list = await _productServices.GetList(conditions, sorts);
			return new MessageModel<List<ProductDto>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}

		[HttpGet]
		[Route("pagelist")]
		public async Task<MessageModel<PageModel<ProductDto>>> GetPageList(int page, int size, string conditions, string sorts)
		{
			var list = await _productServices.GetPageList(page, size, conditions, sorts);
			return new MessageModel<PageModel<ProductDto>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}
	}
}
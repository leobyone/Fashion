using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fashion.IServices;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class ModuleController : ControllerBase
    {
		IModuleServices _moduleServices;
		public ModuleController(IModuleServices moduleServices)
		{
			_moduleServices = moduleServices;
		}

		[HttpGet]
		public async Task<MessageModel<ModuleDto>> Get(int id)
		{
			var data = new MessageModel<ModuleDto>();
			var module = await _moduleServices.GetModuleById(id);

			if (module != null)
			{
				data.data = module;
				data.success = true;
				data.msg = "获取成功";
			}

			return data;
		}

		[HttpPost]
		public async Task<MessageModel<string>> Post([FromBody] Module module)
		{
			var data = new MessageModel<string>();

			var id = (await _moduleServices.Add(module));
			data.success = id > 0;
			if (data.success)
			{
				data.msg = "添加成功";
				data.data = id.ObjToString();
			}

			return data;
		}

		[HttpPut]
		public async Task<MessageModel<string>> Update([FromBody] Module module)
		{
			var data = new MessageModel<string>();
			if (module != null && module.Id > 0)
			{
				data.success = await _moduleServices.Update(module);
				if (data.success)
				{
					data.msg = "更新成功";
					data.data = module?.Id.ObjToString();
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
				var module = await _moduleServices.QueryById(id);
				module.IsDeleted = true;
				data.success = await _moduleServices.Update(module);
				if (data.success)
				{
					data.msg = "删除成功";
					data.data = module?.Id.ObjToString();
				}
			}

			return data;
		}

		[HttpGet]
		[Route("list")]
		public async Task<MessageModel<List<ModuleDto>>> GetList(string conditions, string sorts)
		{
			var list = await _moduleServices.GetList(conditions, sorts);
			return new MessageModel<List<ModuleDto>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}

		[HttpGet]
		[Route("pagelist")]
		public async Task<MessageModel<PageModel<ModuleDto>>> GetPageList(int page, int size, string conditions, string sorts)
		{
			var list = await _moduleServices.GetPageList(page, size, conditions, sorts);
			return new MessageModel<PageModel<ModuleDto>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}
	}
}
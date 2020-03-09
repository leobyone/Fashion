using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fashion.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.Util;

namespace Fashion.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize("Permission")]
	public class UploadController : ControllerBase
	{
		private readonly IHostingEnvironment _hostingEnvironment;
		public IConfiguration Configuration { get; }

		public UploadController(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
		{
			_hostingEnvironment = hostingEnvironment;
			Configuration = configuration;
		}

		/// <summary>
		/// 将文件上传到七牛云
		/// </summary>
		/// <param name="stream">文件流</param>
		/// <param name="fileName">文件名称</param>
		/// <returns></returns>
		[HttpPost]
		public UploadQiNiuResult UploadImgToQiNiu(byte[] stream, string fileName)
		{
			var qiniuConfig = Configuration.GetSection("QiNiuYu");
			var accessKey = qiniuConfig["AccessKey"];
			var secretKey = qiniuConfig["SecretKey"];
			Mac mac = new Mac(accessKey, secretKey);
			// 上传策略，参见 
			// https://developer.qiniu.com/kodo/manual/put-policy
			PutPolicy putPolicy = new PutPolicy();
			// 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
			// putPolicy.Scope = bucket + ":" + saveKey;
			var saveKey = string.Format("images/{0}/", DateTime.Now.ToString("yyyy/MM/dd")) + fileName;
			putPolicy.Scope = "fashion-test:" + saveKey;
			// 上传策略有效期(对应于生成的凭证的有效期)          
			putPolicy.SetExpires(3600);
			// 上传到云端多少天后自动删除该文件，如果不设置（即保持默认默认）则不删除
			// putPolicy.DeleteAfterDays = 1;
			string jstr = putPolicy.ToJsonString();
			//获取上传凭证
			var uploadToken = Qiniu.Util.Auth.CreateUploadToken(mac, jstr);
			UploadManager um = new UploadManager();

			HttpResult result = um.UploadData(stream, saveKey, uploadToken);

			if (result.Code == 200)
			{
				return JsonConvert.DeserializeObject<UploadQiNiuResult>(result.Text);
			}
			return null;
		}

		public class UploadQiNiuResult
		{
			public string Hash { get; set; }
			public string Key { get; set; }
		}

		/// <summary>
		/// 上传图片
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("upload-image")]
		public MessageModel<string> UploadImage(IFormFile file)
		{
			var data = new MessageModel<string>();
			if (file != null)
			{
				string fileName = file.FileName;
				string fileType = fileName.Split('.').ToArray().Last();
				string[] images = new string[] { "png", "jpeg", "jpg", "gif" };
				string newName = Guid.NewGuid().ToString() + "." + fileType;

				if (images.Contains(fileType))
				{
					using (var ms = new MemoryStream())
					{
						file.CopyTo(ms);
						var fileBytes = ms.ToArray();
						var result = UploadImgToQiNiu(fileBytes, newName);

						var qiniuConfig = Configuration.GetSection("QiNiuYu");
						var domain = qiniuConfig["Domain"];
						data.data = domain + "/" + result.Key;
					}

					data.success = true;
				}
				else
				{
					data.success = false;
					data.msg = "文件格式不支持";
				}
			}
			else
			{
				data.success = false;
				data.msg = "上传失败";
			}

			return data;
		}
	}
}
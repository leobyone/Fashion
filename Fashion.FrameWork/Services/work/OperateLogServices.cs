
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// OperateLogServices
	/// </summary>	
	public class OperateLogServices : BaseServices<OperateLog>, IOperateLogServices
    {
	
        IOperateLogRepository repository;
        public OperateLogServices(IOperateLogRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	

    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// OperateLogRepository
	/// </summary>	
	public class OperateLogRepository : BaseRepository<OperateLog>, IOperateLogRepository
    {
		public OperateLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}

	
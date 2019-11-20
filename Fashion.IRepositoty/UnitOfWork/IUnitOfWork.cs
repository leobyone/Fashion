using SqlSugar;

namespace Fashion.IRepositoty.UnitOfWork
{
	public interface IUnitOfWork
	{
		ISqlSugarClient GetDbClient();

		void BeginTran();
		void CommitTran();
		void RollbackTran();
	}
}

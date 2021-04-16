using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Multi_UnitOfWork.Core
{
	public interface IUnitOfWork<T> : IUnitOfWork where T : DbContext
	{
	}
	public interface IUnitOfWork
	{
		DbSet<T> Set<T>() where T : class;
		void ForceBeginTransaction();
		void CommitTransaction();
		void RollbackTransaction();
		int SaveChanges();
		Task<int> AsyncSaveChanges();
		void SetIsolationLevel(IsolationLevel isolationLevel);
		void UpdateWithEntity<T>(T existingEntity, T modifiedEntity) where T : class;
	}
}
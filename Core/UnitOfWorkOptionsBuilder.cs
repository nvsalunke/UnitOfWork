using Microsoft.EntityFrameworkCore;

namespace Multi_UnitOfWork.Core
{
	public class UnitOfWorkOptionsBuilder
	{
		public UnitOfWorkOptions Options { get; } = new UnitOfWorkOptions();

		public void AddUnitOfWork<T>(string key) where T : DbContext
		{
			Options.RegisteredUows.Add(key, typeof(IUnitOfWork<T>));
		}
	}
}
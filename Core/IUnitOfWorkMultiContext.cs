using System.Collections.Generic;

namespace Multi_UnitOfWork.Core
{
	public interface IUnitOfWorkMultiContext
	{
		IEnumerable<string> RegisteredUowKeys { get; }
		IUnitOfWork Get(string key);
		IEnumerable<IUnitOfWork> GetAll();
	}
}
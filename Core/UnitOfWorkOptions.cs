using System;
using System.Collections.Generic;

namespace Multi_UnitOfWork.Core
{
	public class UnitOfWorkOptions
	{
		public Dictionary<string, Type> RegisteredUows { get; set; } = new Dictionary<string, Type>();
	}
}
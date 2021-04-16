using System;
using System.Collections.Generic;

namespace Multi_UnitOfWork.Core
{
	public class UnitOfWorkMultiContext : IUnitOfWorkMultiContext
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly UnitOfWorkOptions _options;

		public IEnumerable<string> RegisteredUowKeys => _options.RegisterUows.Keys;

		public UnitOfWorkMultiContext(IServiceProvider provider, UnitOfWorkOptions options)
		{
			_serviceProvider = provider ?? throw new ArgumentNullException(nameof(provider));
			_options = options ?? throw new ArgumentNullException(nameof(options));
		}
		public IUnitOfWork Get(string key)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException(nameof(key));

			if (!_options.RegisteredUows.ContainsKey(key))
				throw new ArgumentException($"Key is not registered! {nameof(key)}");

			var uowType = _options.RegisteredUows[key];
			return _serviceProvider.GetService(uowType) as IUnitOfWork;
		}

		public IEnumerable<IUnitOfWork> GetAll()
		{
			foreach (var uowType in _options.RegisteredUows)
			{
				yield return _serviceProvider.GetService(uowType.Value) as IUnitOfWork;
			}
		}
	}
}

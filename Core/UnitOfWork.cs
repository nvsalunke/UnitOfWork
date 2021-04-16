using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Multi_UnitOfWork.Core
{
	public class UnitOfWork<T> : IDisposable, IUnitOfWork<T> where T : DbContext
	{
		private readonly DbContext _context;
		private IDbContextTransaction _transaction;
		private IsolationLevel? _isolationLevel;

		public UnitOfWork(T context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public void CommitTransaction()
		{
			_context.SaveChanges();
			if (_transaction != null)
			{
				_transaction.Commit();
				_transaction.Dispose();
				_transaction = null;
			}
		}

		void StartNewTransactionIfNeeded()
		{
			if (_transaction == null)
			{
				if (_isolationLevel.HasValue)
					_transaction = _context.Database.BeginTransaction(_isolationLevel.GetValueOrDefault());
				else
					_transaction = _context.Database.BeginTransaction();
			}
		}
		public void ForceBeginTransaction()
		{
			StartNewTransactionIfNeeded();
		}

		public void RollbackTransaction()
		{
			if (_transaction == null) return;
			_transaction.Rollback();
			_transaction.Dispose();
			_transaction = null;
		}

		public int SaveChanges()
		{
			StartNewTransactionIfNeeded();
			return _context.SaveChanges();
		}

		public DbSet<TEntity> Set<TEntity>() where TEntity : class
		{
			return _context.Set<TEntity>();
		}

		public void SetIsolationLevel(IsolationLevel isolationLevel)
		{
			_isolationLevel = isolationLevel;
		}

		public void Dispose()
		{
			if (_transaction != null)
				_transaction.Dispose();

			_transaction = null;
		}

		public async Task<int> AsyncSaveChanges()
		{
			StartNewTransactionIfNeeded();
			return await _context.SaveChangesAsync();
		}

		public void UpdateWithEntity<T1>(T1 existingEntity, T1 modifiedEntity) where T1 : class
		{
			_context.Entry(existingEntity).State = EntityState.Modified;
			_context.Entry(existingEntity).CurrentValues.SetValues(modifiedEntity);
		}
	}
}
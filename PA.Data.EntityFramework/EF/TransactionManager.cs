using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace PA.Data.Repositories.EntityFramework.EF
{
	public class TransactionManager : ITransactionManager
	{
		private readonly IDbContext _context;
		private bool _readOnly;

		public TransactionManager(IDbContext context)
		{
			_context = context;
		}

		public void Dispose()
		{
			Transaction?.Dispose();
		}

		public IDbConnection Connection => _context.Database.GetDbConnection();
		public IDbTransaction Transaction { get; private set; }
		public bool Started { get; private set; }
		public void Begin(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
		{
			if (Started) return;
			Started = true;
			_context.Database.BeginTransaction(isolationLevel);
		}

		public void Commit()
		{
			if (_readOnly) return;
			_context.Database.CommitTransaction();
			Started = false;
		}

		public void Rollback()
		{
			if (_context.Database.CurrentTransaction == null) return;
			_context.Database.RollbackTransaction();
		}

		public void ReadOnly(bool readOnly) => _readOnly = readOnly;

		public void SetTransaction(IDbTransaction transaction) => 
			_context.Database.UseTransaction((DbTransaction) transaction);

	}
}

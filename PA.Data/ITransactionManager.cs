using System;
using System.Data;

namespace PA.Data
{
    public interface ITransactionManager : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Begin(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
        void ReadOnly(bool readOnly);
        void SetTransaction(IDbTransaction transaction);
		bool Started { get; }
    }
}
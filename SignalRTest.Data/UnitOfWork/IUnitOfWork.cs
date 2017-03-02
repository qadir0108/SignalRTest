using System;
using SignalRTest.Data.Repository;

namespace SignalRTest.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<DevTest> DevTestRepository { get; }

        void Commit();
    }
}

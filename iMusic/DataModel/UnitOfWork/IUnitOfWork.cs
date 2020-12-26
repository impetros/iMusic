using System;
namespace iMusic.DataModel.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        public int Save();
    }
}

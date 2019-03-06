using System;
using Microsoft.EntityFrameworkCore;

namespace champi.Context.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        void Commit();
    }
}
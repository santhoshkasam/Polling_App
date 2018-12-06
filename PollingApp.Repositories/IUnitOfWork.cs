using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PollingApp.Repositories
{
  public interface IUnitOfWork : IDisposable
  {
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

    int SaveChanges();
  }
}

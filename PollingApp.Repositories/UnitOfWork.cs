using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;

namespace PollingApp.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DbContext _context;
    private readonly Dictionary<Type, object> _repos;

    /// <summary>
    ///   Initializes a new instance of the <see cref="UnitOfWork" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public UnitOfWork(DbContext context)
    {
      _context = context;
      _repos = new Dictionary<Type, object>();
    }

    /// <summary>
    ///   Gets the repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <returns>Instance of repository.</returns>
    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
      IRepository<TEntity> repo = null;
      if (!_repos.ContainsKey(typeof (TEntity)))
      {
        repo = new Repository<TEntity>(_context);
        _repos.Add(typeof (TEntity), repo);
      }
      else
      {
        repo = (Repository<TEntity>) _repos[typeof (TEntity)];
      }

      return repo;
    }

    /// <summary>
    ///   Saves the changes to the database.
    /// </summary>
    /// <returns>Number of rows affected.</returns>
    public int SaveChanges()
    {
      return _context.SaveChanges();
    }

    /// <summary>
    ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    #region Private Methods

    private void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (Convert.ToString(ConfigurationManager.AppSettings["DoNotDispose"]) == "true")
          return;
        if (_context != null)
        {
          _context.Dispose();
        }
      }
    }

    #endregion Private Methods
  }
}
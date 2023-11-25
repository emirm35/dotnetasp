using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    // T

    //*  temel sınıflar newlenmicek, abstract olucak bu yüzden. base class'ı devralan sınıflar newlenebilcek, base sınıf newlenemicek

    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    //* kısıtlayıcılar =>
    where T : class, new()

    {

        //* dbye bağlanmak için context Dependency injection =>
        //! devralınan sınıflarda da contextin kullanabilirliği için di fieldi protected
        protected readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges
            ? _context.Set<T>()
            : _context.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
            ? _context.Set<T>().Where(expression).SingleOrDefault()
            : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
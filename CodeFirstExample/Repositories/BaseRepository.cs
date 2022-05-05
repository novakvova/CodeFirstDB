using CodeFirstExample.Entites;
using CodeFirstExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Repositories
{

    public class BaseRepository<TEntity, TIdType> :
        IBaseRepository<TEntity, TIdType> where TEntity : class, IEntity<TIdType>
    {
        private readonly EFDbContext _context;
        public BaseRepository(EFDbContext context)
        {
            _context = context;
        }
        public bool Add(TEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TIdType id)
        {
            try
            {
                var item = _context.Set<TEntity>().Find(id);
                if (item != null)
                {
                    _context.Set<TEntity>().Remove(item);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById(TIdType id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _context.Update<TEntity>(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

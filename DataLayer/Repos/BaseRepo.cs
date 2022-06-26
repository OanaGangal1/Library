using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace DataLayer.Repos
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        T Insert(T record, bool automaticSave = false);
        T Update(T record, bool automaticSave = false);
        void Delete(T record, bool automaticSave = false);
        T GetById(Guid id);
        IList<T> GetAll(bool includeDeleted = false);
    }

    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        private readonly LibraryContext _context;
        protected readonly DbSet<T> dbSet;

        public BaseRepo(LibraryContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public T Insert(T record, bool automaticSave = false)
        {
            var result = dbSet.Add(record);

            if(automaticSave)
                _context.SaveChanges();

            return result.Entity;
        }

        public T Update(T record, bool automaticSave = false)
        {
            var result = dbSet.Update(record);

            if (automaticSave)
                _context.SaveChanges();

            return result.Entity;
        }

        public void Delete(T record, bool automaticSave = false)
        {
            var result = dbSet.Remove(record);

            if (automaticSave)
                _context.SaveChanges();
        }

        public T GetById(Guid id) =>
            dbSet
                .FirstOrDefault(x => x.Id == id);

        public IList<T> GetAll(bool includeDeleted = false) =>
            dbSet
                .Where(x => includeDeleted == (x.DeletedAt != null))
                .ToList();
    }
}

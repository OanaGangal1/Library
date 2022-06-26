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
    }

    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        private readonly LibraryContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepo(LibraryContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Insert(T record, bool automaticSave = false)
        {
            var result = _dbSet.Add(record);

            if(automaticSave)
                _context.SaveChanges();

            return result.Entity;
        }

        public T Update(T record, bool automaticSave = false)
        {
            var result = _dbSet.Update(record);

            if (automaticSave)
                _context.SaveChanges();

            return result.Entity;
        }

        public void Delete(T record, bool automaticSave = false)
        {
            var result = _dbSet.Remove(record);

            if (automaticSave)
                _context.SaveChanges();
        }

        public T GetById(Guid id) =>
            _dbSet
                .FirstOrDefault(x => x.Id == id);

        public ICollection<T> GetAll(bool includeDeleted = false) =>
            _dbSet
                .Where(x => includeDeleted == (x.DeletedAt != null))
                .ToList();
    }
}

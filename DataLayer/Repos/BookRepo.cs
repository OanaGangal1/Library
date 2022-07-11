using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Repos
{
    public interface IBookRepo : IBaseRepo<Book>
    {
        int CountByIsbn(string isbn);
        Book GetByIsbn(string isbn);
        Book GetByNameAndIsbn(string name, string isbn);
        Book GetByName(string name);
    }

    public class BookRepo : BaseRepo<Book>, IBookRepo
    {
        public BookRepo(LibraryContext context) : base(context)
        {
        }

        public int CountByIsbn(string isbn) => dbSet.Count(x => x.Isbn == isbn);
        public Book GetByIsbn(string isbn) => dbSet.FirstOrDefault(x => x.Isbn == isbn);
        public Book GetByNameAndIsbn(string name, string isbn) => dbSet.FirstOrDefault(x => x.Name == name && x.Isbn == isbn);
        public Book GetByName(string name) => dbSet.FirstOrDefault(x => x.Name == name);
    }
}

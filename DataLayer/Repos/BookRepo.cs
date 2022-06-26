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
    }

    public class BookRepo : BaseRepo<Book>, IBookRepo
    {
        public BookRepo(LibraryContext context) : base(context)
        {
        }

        public int CountByIsbn(string isbn) => dbSet.Count(x => x.Isbn == isbn);
    }
}

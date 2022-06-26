using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Repos
{
    public interface IBookRepo
    {
    }

    public class BookRepo : BaseRepo<Book>, IBookRepo
    {
        public BookRepo(LibraryContext context, bool automaticSave) : base(context, automaticSave)
        {
        }
    }
}

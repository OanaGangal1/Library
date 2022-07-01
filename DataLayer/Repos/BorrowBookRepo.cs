using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repos
{
    public interface IBorrowBookRepo : IBaseRepo<BorrowBook>
    {
        BorrowBook GetByBorrowerAndBook(string borrowerIdentityNum, string bookName);
    }

    public class BorrowBookRepo : BaseRepo<BorrowBook>, IBorrowBookRepo
    {
        public BorrowBookRepo(LibraryContext context) : base(context)
        {
        }

        public BorrowBook GetByBorrowerAndBook(string borrowerIdentityNum, string bookName) =>
            dbSet
                .Include(x => x.Borrower)
                .Include(x => x.Book)
                .FirstOrDefault(x => x.Book.Name == bookName && x.Borrower.IdentityNumber == borrowerIdentityNum);
    }
}

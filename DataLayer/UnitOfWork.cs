using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repos;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public interface IUnitOfWork
    {
        IBookRepo Books { get; }
        IBorrowerRepo Borrowers { get; }
        IBorrowBookRepo BorrowBooks { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        public IBookRepo Books { get; }
        public IBorrowerRepo Borrowers { get; }
        public IBorrowBookRepo BorrowBooks { get; }

        public UnitOfWork(IBookRepo books, 
            IBorrowerRepo borrowers, 
            IBorrowBookRepo borrowBookRepo,
            LibraryContext context)
        {
            _context = context;
            Books = books;
            Borrowers = borrowers;
            BorrowBooks = borrowBookRepo;
        }

        public bool SaveChanges() => (_context.SaveChanges() > 0);
    }
}

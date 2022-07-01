using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class BorrowBook : BaseEntity
    {
        public Guid BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowedAt { get; set; }

        public BorrowBook(DateTime? borrowedAt = null)
        {
            BorrowedAt = borrowedAt ?? DateTime.UtcNow;
        }
    }
}

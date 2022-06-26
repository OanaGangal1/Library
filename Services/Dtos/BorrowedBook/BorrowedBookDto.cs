using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.BorrowedBook
{
    public class BorrowedBookDto : BaseBorrowedBookDto
    {
        public string BookName { get; set; }
        public string BorrowerFullName { get; set; }
        public DateTime BorrowedAt { get; set; }
    }
}

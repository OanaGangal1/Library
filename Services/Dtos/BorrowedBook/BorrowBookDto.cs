using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.BorrowedBook
{
    public class BorrowBookDto
    {
        public string ReaderIdentityNum { get; set; }
        public string BookName { get; set; }
    }
}

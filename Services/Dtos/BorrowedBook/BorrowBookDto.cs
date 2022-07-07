using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.BorrowedBook
{
    public class BorrowBookDto
    {
        [Required]
        public string ReaderIdentityNum { get; set; }
        [Required]
        public string BookName { get; set; }
    }
}

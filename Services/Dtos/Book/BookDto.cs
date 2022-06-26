using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Book
{
    public class BookDto : BaseBookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public decimal RentalPrice { get; set; }
    }
}

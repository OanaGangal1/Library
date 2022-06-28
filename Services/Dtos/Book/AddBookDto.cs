using Services.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Book
{
    public class AddBookDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Isbn("Invalid ISBN format!")]
        public string Isbn { get; set; }
        [Required]
        public decimal RentalPrice { get; set; }
    }
}

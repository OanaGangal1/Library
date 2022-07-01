using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utilities
{
    public static class ErrorMessages
    {
        public const string SameIsbnButDifferent = "Books with different characteristics but same ISBN cannot be registered!";
        public const string SameNameButDifferent = "Books with different characteristics but same Name cannot be registered!";
        public const string SameBookDifferentPrice = "Rental price should be consistent!";

        public const string NoReaderWithIdentityNum = "There is no reader registered with this identity number!";
        public const string ReaderAlreadyRegistered = "Reader with this identity number is already registered!";
        public const string BookWithNameNotFound = "There is no book registered with this name!";
        public const string BorrowBookNotFound = "No record found with this book and reader";
    }
}

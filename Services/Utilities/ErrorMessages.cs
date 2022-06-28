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
    }
}

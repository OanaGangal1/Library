using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Repos
{
    public interface IBorrowerRepo
    {
    }

    public class BorrowerRepo : BaseRepo<Borrower>, IBorrowerRepo
    {
        public BorrowerRepo(LibraryContext context, bool automaticSave) : base(context, automaticSave)
        {
        }
    }
}

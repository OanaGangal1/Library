using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Repos
{
    public interface IBorrowerRepo : IBaseRepo<Borrower>
    {
        Borrower GetByIdentityNum(string identityNum);
    }

    public class BorrowerRepo : BaseRepo<Borrower>, IBorrowerRepo
    {
        public BorrowerRepo(LibraryContext context) : base(context)
        {
        }

        public Borrower GetByIdentityNum(string identityNum) =>
            dbSet.FirstOrDefault(x => x.IdentityNumber == identityNum);
    }
}

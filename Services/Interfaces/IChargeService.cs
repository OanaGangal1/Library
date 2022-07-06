using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace Services.Interfaces
{
    public interface IChargeService
    {
        decimal Charge(BorrowBook borrowedBook);
    }
}

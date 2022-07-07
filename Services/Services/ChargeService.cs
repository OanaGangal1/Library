using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using Services.Exceptions;
using Services.Interfaces;

namespace Services.Services
{
    public class ChargeService : IChargeService
    {
        private readonly IAppConfig _appConfig;

        public ChargeService(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }
        public decimal Charge(BorrowBook borrowedBook)
        {
            if (borrowedBook.Book == null)
                throw new Exception("Missing book");

            var passedTime = DateTime.UtcNow - borrowedBook.BorrowedAt;
            if (passedTime <= _appConfig.FreeBorrowTime)
                return 0;

            var timeUnits = _appConfig.GetTotalTimeUnits(_appConfig.FreeBorrowTime, passedTime);

            return _appConfig.ChargeRate * borrowedBook.Book.RentalPrice * (decimal)timeUnits;
        }
    }
}

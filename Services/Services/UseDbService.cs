using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Services.Interfaces;

namespace Services.Services
{
    public class UseDbService : IUseDbService
    {
        protected readonly IUnitOfWork unitOfWork;

        public UseDbService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}

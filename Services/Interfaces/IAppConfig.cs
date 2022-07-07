using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAppConfig
    {
        TimeSpan FreeBorrowTime { get; set; }
        decimal ChargeRate { get; set; }
        double GetTotalTimeUnits(TimeSpan start, TimeSpan end);
    }
}

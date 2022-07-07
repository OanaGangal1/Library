using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;

namespace Services.Utilities
{
    public class AppConfig : IAppConfig
    {
        public TimeSpan FreeBorrowTime { get; set; } = TimeSpan.FromDays(14);
        public decimal ChargeRate { get; set; } = 0.1m;
        public double GetTotalTimeUnits(TimeSpan start, TimeSpan end)
        {
            return (end - start).TotalDays;
        }
    }
}

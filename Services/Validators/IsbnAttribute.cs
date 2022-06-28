using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class IsbnAttribute : ValidationAttribute
    {
        public IsbnAttribute(string msg) : base(msg)
        {

        }

        public override bool IsValid(object value)
        {
            var stringVal = value.ToString().Replace(" ", "").Replace("-", "");
            if(stringVal.Length != 13)
                return false;

            var isbn = new int[5];
            isbn[0] = int.Parse(stringVal[..3]);
            isbn[1] = int.Parse(stringVal.Substring(3, 1));
            isbn[2] = int.Parse(stringVal.Substring(4, 2));
            isbn[3] = int.Parse(stringVal.Substring(6, 6));
            isbn[4] = int.Parse(stringVal.Substring(12, 1));

            var result = isbn[0] == 978 || isbn[0] == 979;
            result &= isbn[1] >= 0 && isbn[1] <= 9;
            result &= isbn[2] >= 10 && isbn[2] <= 99;
            result &= isbn[3] >= 100000 && isbn[3] <= 999999;
            result &= isbn[4] == 0 || isbn[4] == 1;

            return result;
        }
    }
}

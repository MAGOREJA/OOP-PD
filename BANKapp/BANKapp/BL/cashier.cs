using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKapp.BL
{
    class cashier
    {
        public cashier(string cashierName, int cashierHours)
        {
            this.cashierName = cashierName;
            this.cashierHours = cashierHours;
            cashierStatus = "ON DUTY";

        }
        public string cashierName;
        public int cashierHours;
        public string cashierStatus;

    }
}

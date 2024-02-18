using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKapp.BL
{
    class customer
    {
        public customer(string customerName, long cnic, float amount, string job, string gender)
        {
            this.customerName = customerName;
            this.cnic = cnic;
            this.amount = amount;
            this.job = job;
            this.gender = gender;

        }
        public string customerName;
        public long cnic;
        public float amount;
        public string job;
        public string gender;
    }
}

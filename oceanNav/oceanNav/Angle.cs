using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oceanNav
{
    class Angle
    {
        public int degree;
        public float minutes;
        public string direction;

        public Angle(int degree, float minutes, string direction)
        {
            this.degree = degree;
            this.minutes = minutes;
            this.direction = direction;
        }
    }
}

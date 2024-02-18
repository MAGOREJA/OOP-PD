using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oceanAttack
{
    class Stats
    {
        public string skillname;
        public double damage;
        public double penetration;
        public double cost;
        public double heal;
        public string description;

        public Stats(string skillname, double damage, double penetration, double cost, double heal, string description)
        {
            this.skillname = skillname;
            this.damage = damage;
            this.penetration = penetration;
            this.cost = cost;
            this.heal = heal;
            this.description = description;
        }

    }
}

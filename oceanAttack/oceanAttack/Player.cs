using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oceanAttack
{
    class Player
    {
        public string name;
        public double health;
        public double maxhealth;
        public double energy;
        public double maxenergy;
        public double armor;
        public Stats skilllearn;

        public Player(string name, double health, double maxhealth, double energy, double maxenergy, double armor)
        {
            this.name = name;
            this.health = health;
            this.maxhealth = maxhealth;
            this.energy = energy;
            this.maxenergy = maxenergy;
            this.armor = armor;
        }

        public string viewplayer()
        {
            return ($" {name} \t\t\t {health} \t\t\t {energy} \t\t\t {armor}");
        }
        public void learnskill(Stats s)
        {
            skilllearn = s;
            Console.WriteLine($" {name} successfully learned {s.skillname} skill.");
        }
        public string attack(Player p)
        {
            double effectivearmor = 0;
            double damageto = 0;
            if (energy >= skilllearn.cost)
            {
                energy -= skilllearn.cost;
                effectivearmor = p.armor - skilllearn.penetration;
                if (p.armor < 0)
                    p.armor = 0;
                damageto = skilllearn.damage * ((100 - effectivearmor) / 100);
                p.health -= damageto;
                if (health + skilllearn.heal <= maxhealth)
                    health += skilllearn.heal;
                if (p.health > 0)
                    return ($" {name} used {skilllearn.skillname}, {skilllearn.description}, against {p.name}, doing {damageto} damage! {name} healed for {skilllearn.heal} health! {p.name} is at {p.health} health.");
                else
                    return ($" {name} used {skilllearn.skillname}, {skilllearn.description}, against {p.name}, doing {damageto} damage! {name} healed for {skilllearn.heal} health! {p.name} is died.");
            }
            return ($" {name} used {skilllearn.skillname},but did not have enough energy");
        }

    }
}

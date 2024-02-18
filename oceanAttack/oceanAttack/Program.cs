using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oceanAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            int count = 0;
            string playername, targetname, skillname;
            List<Player> players = new List<Player>();
            List<Stats> skills = new List<Stats>();
            while (true)
            {
                Console.WriteLine(" \t\t\t\t Magical Duel Challenge");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Add Skill Statistics");
                Console.WriteLine("3. View Player Info");
                Console.WriteLine("4. Learn a Skill");
                Console.WriteLine("5. Attack");
                Console.WriteLine("6. Exit");
                Console.Write(" Enter Option Number: ");
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    Console.Clear();
                    Console.WriteLine(" \t\t\t\t Add Player\n\n");
                    players.Add(addplayer());
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine(" \t\t\t\t Add Skill Statistics\n\n");
                    skills.Add(addskill());
                }
                else if (option == 3)
                {
                    Console.Clear();
                    Console.WriteLine(" \t\t\t\t View Player Info\n\n");
                    if (players.Count == 0)
                        Console.WriteLine(" No Player Exist.");
                    else
                    {
                        Console.WriteLine("Player Name \t\t Health \t\t Energy \t\t Armor");
                        for (int i = 0; i < players.Count; i++)
                        {
                            Console.WriteLine(players[i].viewplayer());
                        }
                    }
                }
                else if (option == 4)
                {
                    Console.Clear();
                    Console.WriteLine(" \t\t\t\t Learn a Skill\n\n");
                    int skillno = 0;
                    count = 0;
                    Console.Write(" Enter Player Name: ");
                    playername = Console.ReadLine();
                    Console.Write(" Enter Skill Name: ");
                    skillname = Console.ReadLine();
                    for (int i = 0; i < skills.Count; i++)
                    {
                        if (skills[i].skillname == skillname)
                        {
                            skillno = i;
                            count++;
                        }
                    }
                    if (count == 0)
                        Console.WriteLine(" No Such Skill Exist.");
                    else
                    {
                        count = 0;
                        for (int x = 0; x < players.Count; x++)
                        {
                            if (players[x].name == playername)
                            {
                                players[x].learnskill(skills[skillno]);
                                count++;
                            }
                        }
                        if (count == 0)
                            Console.WriteLine(" No Such Player Exist.");
                    }
                }
                else if (option == 5)
                {
                    Console.Clear();
                    int targetno = 0;
                    count = 0;
                    Console.WriteLine(" \t\t\t\t Attack\n\n");
                    Console.Write(" Enter Attacking Player Name: ");
                    playername = Console.ReadLine();
                    Console.Write(" Enter target Player Name: ");
                    targetname = Console.ReadLine();
                    for (int i = 0; i < players.Count; i++)
                    {
                        if (players[i].name == targetname && targetname != playername)
                        {
                            targetno = i;
                            count++;
                        }
                    }
                    if (count == 0)
                        Console.WriteLine(" No Such Player Exist.");
                    else
                    {
                        count = 0;
                        for (int x = 0; x < players.Count; x++)
                        {
                            if (players[x].name == playername)
                            {
                                Console.WriteLine(players[x].attack(players[targetno]));
                                count++;
                            }
                        }
                        if (count == 0)
                            Console.WriteLine(" No Such Player Exist.");
                        if (players[targetno].health <= 0)
                            players.RemoveAt(targetno);
                    }
                }
                else if (option == 6)
                {
                    Console.Clear();
                    break;
                }
                Console.WriteLine(" \n\n\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static Player addplayer()
        {
            string name;
            double health, maxhealth, energy, maxenergy, armor;
            Console.Write(" Enter Player Name: ");
            name = Console.ReadLine();
            Console.Write(" Enter Player Health: ");
            health = double.Parse(Console.ReadLine());
            Console.Write(" Enter Player Maximum Health: ");
            maxhealth = double.Parse(Console.ReadLine());
            Console.Write(" Enter Player Energy: ");
            energy = double.Parse(Console.ReadLine());
            Console.Write(" Enter Player Maximum Energy: ");
            maxenergy = double.Parse(Console.ReadLine());
            Console.Write(" Enter Player Armor: ");
            armor = double.Parse(Console.ReadLine());
            Player p1 = new Player(name, health, maxhealth, energy, maxenergy, armor);
            return p1;
        }
        static Stats addskill()
        {
            string skillname, description;
            double damage, penetration, cost, heal;
            Console.Write(" Enter Skill Name: ");
            skillname = Console.ReadLine();
            Console.Write(" Enter Skill Description: ");
            description = Console.ReadLine();
            Console.Write(" Enter Skill Damage: ");
            damage = double.Parse(Console.ReadLine());
            Console.Write(" Enter Skill Penetration: ");
            penetration = double.Parse(Console.ReadLine());
            Console.Write(" Enter Skill Cost: ");
            cost = double.Parse(Console.ReadLine());
            Console.Write(" Enter Skill Heal: ");
            heal = double.Parse(Console.ReadLine());
            Stats s1 = new Stats(skillname, damage, penetration, cost, heal, description);
            return s1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oceanNav
{
    class Program
    {
        static void Main(string[] args)
        {
            string lati, longi;
            string serial;
            string lon, lat;
            List<Ship> ships = new List<Ship>();
            int option;
            int count = 0;
            while (true)
            {
                Console.WriteLine(" \t\t\t\t OCEAN NAVIGATION");
                Console.WriteLine("1. Add Ship");
                Console.WriteLine("2. View Ship Position");
                Console.WriteLine("3. View Ship Serial Number");
                Console.WriteLine("4. Change Ship Position");
                Console.WriteLine("5. Exit");
                Console.Write(" Enter Option Number: ");
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    ships.Add(addship());
                }
                else if (option == 2)
                {
                    Console.Write(" Enter Ship Serial Number to find its position: ");
                    serial = Console.ReadLine();
                    for (int i = 0; i < ships.Count; i++)
                    {
                        if (serial == ships[i].shipnumber)
                        {
                            lat = ships[i].viewposition("Latitude");
                            lon = ships[i].viewposition("Longitude");
                            Console.WriteLine($" Ship is at {lat} and {lon}");
                            count++;
                        }
                    }
                    if (count == 0)
                        Console.WriteLine(" No such ship found.");
                }
                else if (option == 3)
                {
                    count = 0;
                    Console.Write(" Enter Ship Latitude: ");
                    lat = Console.ReadLine();
                    Console.Write(" Enter Ship Longitude: ");
                    lon = Console.ReadLine();
                    for (int i = 0; i < ships.Count; i++)
                    {
                        lati = lat = ships[i].viewposition("Latitude");
                        longi = ships[i].viewposition("Longitude");
                        if (lati == lat && longi == lon)
                        {
                            Console.WriteLine($" Ships Serial Number is: {ships[i].shipnumber}");
                            count++;
                        }
                    }
                    if (count == 0)
                        Console.WriteLine(" No such ship found.");
                }
                else if (option == 4)
                {
                    count = 0;
                    Console.Write(" Enter Ship's Serial Number:");
                    serial = Console.ReadLine();
                    for (int i = 0; i < ships.Count; i++)
                    {
                        if (serial == ships[i].shipnumber)
                        {
                            ships[i].changeposition();
                            count++;
                        }
                    }
                    if (count == 0)
                        Console.WriteLine(" No such ship found.");
                }
                else if (option == 5)
                {
                    Console.Clear();
                    break;
                }
                Console.WriteLine(" \n\n\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static Ship addship()
        {
            string shipno;
            Console.Write(" Enter Ship Number: ");
            shipno = Console.ReadLine();
            Angle latitude = getangle("Latitude");
            Angle longitude = getangle("Longitude");
            Ship s1 = new Ship(shipno, longitude, latitude);
            return s1;
        }
        static Angle getangle(string direction)
        {
            int degree;
            float minutes = 0F;
            string dir = "";
            Console.WriteLine(" Enter Ship {0}: ", direction);
            Console.Write(" Enter {0}'s Degree: ", direction);
            degree = int.Parse(Console.ReadLine());
            Console.Write(" Enter {0}'s Minutes: ", direction);
            minutes = float.Parse(Console.ReadLine());
            Console.Write(" Enter {0}'s Direction: ", direction);
            dir = Console.ReadLine();
            Angle ang1 = new Angle(degree, minutes, dir);
            return ang1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oceanNav
{
    class Ship
    {
        public string shipnumber;
        public Angle longitude;
        public Angle latitude;

        public Ship(string shipnumber, Angle longitude, Angle latitude)
        {
            this.shipnumber = shipnumber;
            this.longitude = longitude;
            this.latitude = latitude;
        }

        public string viewposition(string direction)
        {
            if (direction == "Longitude")
            {
                return ($"{longitude.degree}°{longitude.minutes}' {longitude.direction}");
            }
            return ($"{latitude.degree}°{latitude.minutes}' {latitude.direction}");
        }
        public void changeposition()
        {
            int latdegree;
            float latminutes = 0F;
            string latdir = "";
            int londegree;
            float lonminutes = 0F;
            string londir = "";
            Console.WriteLine(" Enter Ship Latitude: ");
            Console.Write(" Enter Latitude's Degree: ");
            latdegree = int.Parse(Console.ReadLine());
            Console.Write(" Enter Latitude's Minutes: ");
            latminutes = float.Parse(Console.ReadLine());
            Console.Write(" Enter Latitude's Direction: ");
            latdir = Console.ReadLine();
            Console.WriteLine(" Enter Ship Longitude: ");
            Console.Write(" Enter Longitude's Degree: ");
            londegree = int.Parse(Console.ReadLine());
            Console.Write(" Enter Longitude's Minutes: ");
            lonminutes = float.Parse(Console.ReadLine());
            Console.Write(" Enter Longitude's Direction: ");
            londir = Console.ReadLine();
            latitude.degree = latdegree;
            latitude.minutes = latminutes;
            latitude.direction = latdir;
            longitude.degree = londegree;
            longitude.minutes = lonminutes;
            longitude.direction = londir;
            Console.WriteLine(" The Loaction of ship is successfully changed.");
        }
    }
}

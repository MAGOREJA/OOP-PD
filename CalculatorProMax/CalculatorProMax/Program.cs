using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CalculatorProMax
{
    class Program
    {
        static void Main(string[] args)
        {
            float num1 = 0, num2 = 0;
            CALCULATOR c = new CALCULATOR();
            while (true)
            {
                Console.Clear();
                string option = displayMenu();
                if (option == "1")
                {
                    Console.Clear();
                    takeInput(ref num1, ref num2);
                    c = new CALCULATOR(num1, num2);
                    returnforALL();
                }
                else if (option == "2")
                {
                    Console.Clear();
                    takeInput(ref num1, ref num2);
                    c.changeValue(num1, num2);
                    returnforALL();
                }
                else if (option == "3")
                {
                    Console.Clear();
                    Console.WriteLine("The Sum is : {0}", c.sum());
                    returnforALL();
                }
                else if (option == "4")
                {
                    Console.Clear();
                    Console.WriteLine("The subtraction of the two numbers: {0}", c.subtraction());
                    returnforALL();
                }
                else if (option == "5")
                {
                    Console.Clear();
                    Console.WriteLine("The multiplication of the two numbers is {0}", c.multiplication());
                    returnforALL();
                }
                else if (option == "6")
                {
                    Console.Clear();
                    Console.WriteLine("The division of the two numbers is {0}", c.division());
                    returnforALL();
                }

                else if (option == "7")
                {
                    Console.Clear();
                    Console.WriteLine("The modulus of the two numbers is {0}", c.mod());
                    returnforALL();
                }
                else if (option == "8")
                {
                    Console.Clear();
                    double num = takeNumber();
                    Console.WriteLine("The square root of the number is : {0}", c.squareRoot(num));
                    returnforALL();
                }
                else if (option == "9")
                {
                    Console.Clear();
                    double num = takeNumber();
                    Console.WriteLine("The exponent your number with the first number is : {0}", c.exponent(num));
                    returnforALL();
                }
                else if (option == "10")
                {
                    Console.Clear();
                    double num = takeNumber();
                    Console.WriteLine("The natural logarith of the number is : {0}", c.log(num));
                    returnforALL();
                }
                else if (option == "11")
                {
                    Console.Clear();
                    double num = takeNumber();
                    Console.WriteLine("The sin, cos & tan of angle is : {0}, {1}, {2}", c.sin(num), c.cos(num), c.tan(num));
                    returnforALL();
                }
                else if (option == "12")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Option...");
                    Thread.Sleep(300);
                }
            }



        }

        static string displayMenu()
        {
            string option;
            Console.WriteLine("=======> Calculator <======");
            Console.WriteLine();
            Console.WriteLine("1.Create a Single Object of Calculator");
            Console.WriteLine("2.Change Values of Attributes");
            Console.WriteLine("3.Sum");
            Console.WriteLine("4.Difference");
            Console.WriteLine("5.Product");
            Console.WriteLine("6.Divide");
            Console.WriteLine("7.Modulus");
            Console.WriteLine("8.Square Root");
            Console.WriteLine("9.Exponent");
            Console.WriteLine("10.Natural Logarithm");
            Console.WriteLine("11.Trigonometric Functions(Sin / Cos / Tan)");
            Console.WriteLine("12.Exit");
            Console.Write("Enter Your Choice: ");
            option = Console.ReadLine();
            return option;
        }



        static void takeInput(ref float num1, ref float num2)
        {
            Console.Write("Enter the first number: ");
            num1 = float.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            num2 = float.Parse(Console.ReadLine());
        }

        static double takeNumber()
        {
            double number;
            Console.Write("Enter the Number: ");
            number = double.Parse(Console.ReadLine());
            return number;
        }

        static void returnforALL()
        {
            Console.Write("Press any key to return....");
            Console.Read();
        }

    }
}

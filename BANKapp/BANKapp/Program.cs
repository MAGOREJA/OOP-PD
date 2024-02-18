using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using BANKapp.BL;

namespace BANKapp
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            List<Users> user = new List<Users>();
            List<cashier> cashier = new List<cashier>();
            List<customer> customer = new List<customer>();
            StreamWriter file = new StreamWriter("bankusers.txt");
            loadrecords(user, ref i);

            while (true)
            {

                Console.Clear();
                welcome();
                header();
                subMenuBeforeMainMenu("Login");
                string option = loginMenu();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        welcome();
                        header();
                        subMenuBeforeMainMenu("SignIn");
                        Console.WriteLine("Enter your name: ");
                        string signInName = Console.ReadLine();
                        Console.WriteLine("Enter your password: ");
                        string signInPassword = Console.ReadLine();
                        string role = signIn(user, signInName, signInPassword);
                        if (role == "manager" || role == "Manager" || role == "cashier" || role == "Cashier")
                        {
                            Console.WriteLine($"Welcome {role}");

                            if (role == "Manager" || role == "manager")
                            {
                                Console.WriteLine("You have successfully SignedIn");
                                clearScreen();
                                manager_tasks(cashier);
                            }
                            else if (role == "Cashier" || role == "cashier")
                            {
                                Console.WriteLine("You have successfully SignedIn");
                                clearScreen();
                                cashierTasks(customer);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have Entered wrong Credentials");
                            clearScreen();
                        }
                        break;

                    case "2":
                        Console.Clear();
                        welcome();
                        header();
                        subMenuBeforeMainMenu("SignUp");
                        Console.WriteLine("Enter your name: ");
                        string signUpName = Console.ReadLine();
                        Console.WriteLine("Enter your password: ");
                        string signUpPassword = Console.ReadLine();
                        Console.WriteLine("Enter your role: ");
                        string signUpRole = Console.ReadLine();

                        if (signUpRole == "manager" || signUpRole == "Manager" || signUpRole == "cashier" || signUpRole == "Cashier")
                        {

                            bool signUpResult = signUp(user, signUpName, signUpPassword, signUpRole);
                            if (signUpResult)
                            {
                                Console.WriteLine("Sign-up successful!");
                                clearScreen();
                            }
                            else
                            {
                                Console.WriteLine("Sign-up failed. User already exists or maximum capacity reached.");
                                clearScreen();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Provide valid role.");
                            clearScreen();
                        }
                        break;

                    case "3":  // Add an option for exit (you can choose any unused option)

                        Console.WriteLine("Exiting the application.");
                        clearScreen();
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }


            }
        }

        static string loginMenu()
        {
            Console.WriteLine("=> 1. \tSignIn with your Credentials");
            Console.WriteLine("=> 2. \tSignUp to get your Credentials");
            Console.WriteLine("=> 3. \tExit the Application");
            Console.Write("Enter the Option Number > ");
            string result = Console.ReadLine();
            return result;
        }
        static void welcome()
        {
            Console.WriteLine();
            Console.WriteLine("\t        d8888 888888b.    .d8888b.       888888b.         d8888 888b    888 888    d8P  ");
            Console.WriteLine("\t       d88888 888   88b  d88P  Y88b      888   88b       d88888 8888b   888 888   d8P   ");
            Console.WriteLine("\t      d88P888 888  .88P  888    888      888  .88P      d88P888 88888b  888 888  d8P    ");
            Console.WriteLine("\t     d88P 888 8888888K.  888             8888888K.     d88P 888 888Y88b 888 888d88K     ");
            Console.WriteLine("\t    d88P  888 888   Y88b 888             888   Y88b   d88P  888 888 Y88b888 8888888b    ");
            Console.WriteLine("\t   d88P   888 888    888 888    888      888    888  d88P   888 888  Y88888 888  Y88b   ");
            Console.WriteLine("\t  d8888888888 888   d88P Y88b  d88P      888   d88P d8888888888 888   Y8888 888   Y88b  ");
            Console.WriteLine("\t d88P     888 8888888P     Y8888P        8888888P  d88P     888 888    Y888 888    Y88b ");
        }


        static void header()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t************************************************************");
            Console.WriteLine("\t\t*              EMPLOYEE MANAGEMENT SYSTEM                  *");
            Console.WriteLine("\t\t************************************************************");
            Console.WriteLine("");
        }

        static void subMenuBeforeMainMenu(string submenu)
        {
            string message = "\t\t" + submenu + " Menu";
            Console.WriteLine(message + "");
            Console.WriteLine("------------------------------------------------------------------------------------");
        }

        static void subMenu(string submenu)
        {
            string message = "\tMain Menu > " + submenu;
            Console.WriteLine(message + "");
            Console.WriteLine("------------------------------------------------------------------------------------");
        }

        static void clearScreen()
        {
            Console.WriteLine("Press Any Key to Continue..");
            Console.ReadKey();
            Console.Clear();
        }

        static bool signUp(List<Users> user, string users, string passwords, string roles)
        {
            bool isPresent = false;

            for (int index = 0; index < user.Count; index++)
            {
                if (user[index].userName == users && user[index].passwords == passwords)
                {
                    isPresent = true;
                    break;
                }
            }

            if (isPresent)
            {
                return false;
            }

            Users s = new Users(users, passwords, roles);
            user.Add(s);
            return true;
        }

        static string signIn(List<Users> user, string users, string passwords)
        {
            for (int index = 0; index < user.Count; index++)
            {
                if (user[index].userName == users && user[index].passwords == passwords)
                {
                    return user[index].roles;
                }
            }
            return "undefined";
        }

        static string manager_menu()
        {
            Console.WriteLine();
            Console.WriteLine("Select any one of the following options");
            Console.WriteLine("1.\tList of Cashiers");
            Console.WriteLine("2.\tHire a Cashier");
            Console.WriteLine("3.\tFire a Cashier");
            Console.WriteLine("4.\tUpdate Cashier");
            Console.WriteLine("5.\tExit");
            Console.WriteLine("Choose one option to continue... ");
            string anyNum = Console.ReadLine();
            return anyNum;
        }

        static void manager_tasks(List<cashier> cashier)
        {
            string manager_Option;
            while (true)
            {
                Console.Clear();
                welcome();
                header();
                subMenu("Manager Tasks");
                manager_Option = manager_menu();
                if (manager_Option == "1")
                {
                    Console.Clear();
                    welcome();
                    header();
                    subMenu("Cashier's List");
                    cashierList(cashier);
                }
                else if (manager_Option == "2")
                {
                    Console.Clear();
                    welcome();
                    header();
                    subMenu("Hiring a Cashier");


                    bool hiringResult = cashierHire(cashier);
                    if (hiringResult)
                    {
                        Console.WriteLine("Hiring successful!");
                    }
                    else
                    {
                        Console.WriteLine("Hiring failed. Cashier already exists or maximum capacity reached.");
                    }
                }
                else if (manager_Option == "3")
                {
                    Console.Clear();
                    welcome();
                    header();
                    subMenu("Firing a Cashier");
                    cashierFire(cashier);
                }
                else if (manager_Option == "4")
                {
                    Console.Clear();
                    welcome();
                    header();
                    subMenu("Updating Cashier's Info");
                    updateCashier(cashier);
                }
                else if (manager_Option == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Try another option.");
                }
                clearScreen();
            }


        }
        static bool cashierHire(List<cashier> cashier)
        {
            Console.WriteLine("Enter Cashier's Name: ");
            string cashierName = Console.ReadLine();
            Console.WriteLine("Enter Working Hours for Cashier: ");
            int cashierHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Working Status is set \"ON DUTY\"");

            bool alreadyPresent = false;

            for (int index = 0; index < cashier.Count; index++)
            {
                if (cashier[index].cashierName == cashierName && cashier[index].cashierHours == cashierHours)
                {

                    alreadyPresent = true;
                    break;
                }
            }

            if (alreadyPresent)
            {
                return false;
            }

            cashier a = new cashier(cashierName, cashierHours);
            cashier.Add(a);
            return true;

        }
        static void cashierList(List<cashier> cashier)
        {
            Console.WriteLine("Index\t\tName\t\t\tWorking Hours\t\tWorking Status");
            for (int i = 0; i < cashier.Count; i++)
            {
                Console.WriteLine((i + 1) + "\t\t" + cashier[i].cashierName + "\t\t\t " + cashier[i].cashierHours + "\t\t\t" + cashier[i].cashierStatus);
            }
        }

        static void cashierFire(List<cashier> cashier)
        {
            if (cashier.Count > 0)
            {
                int index = selectCashier(cashier);
                if (index > 0 && index <= cashier.Count)
                {
                    index--;
                    cashier.RemoveAt(index);

                }
                else
                {
                    Console.WriteLine("Incorrect Input...");
                }
            }
            else
            {
                Console.WriteLine("There are no Cashiers Yet...");
            }
            clearScreen();
        }
        static void updateCashier(List<cashier> cashier)
        {
            if (cashier.Count > 0)
            {
                int index = selectCashier(cashier);
                if (index > 0 && index <= cashier.Count)
                {
                    index--;
                    changeDetails(cashier, index);

                }
                else
                {
                    Console.WriteLine("Incorrect Input...");
                }
            }
            else
            {
                Console.WriteLine("There are no Cashiers Yet...");
            }
            clearScreen();

        }
        static void changeDetails(List<cashier> cashier, int index)
        {

            string name, status;
            int work = 0;

            Console.Write("Enter " + (index + 1) + " Name: ");
            name = Console.ReadLine();
            Console.Write("Enter " + (index + 1) + " Working Hours: ");
            work = int.Parse(Console.ReadLine());
            Console.Write("Enter " + (index + 1) + " Working Status: ");
            status = Console.ReadLine();

            cashier[index].cashierName = name;
            cashier[index].cashierHours = work;
            cashier[index].cashierStatus = status;

        }

        static int selectCashier(List<cashier> cashier)
        {
            int index = 0;
            string temp;
            cashierList(cashier);
            Console.WriteLine();
            Console.Write("Enter their Index: ");
            temp = Console.ReadLine();
            index = validateInt(temp, index);
            return index;

        }


        static string cashier_menu()
        {
            Console.WriteLine("Select any one of the following options");
            Console.WriteLine("1.\tList of Customers");
            Console.WriteLine("2.\tOpen a Bank Account");
            Console.WriteLine("3.\tClose a Bank Account");
            Console.WriteLine("4.\tUpdate Customer");
            Console.WriteLine("5.\tExit");
            Console.WriteLine("Choose one option to continue... ");
            string work = Console.ReadLine();
            return work;
        }


        static void cashierTasks(List<customer> customer)
        {
            string cashier_Option;
            while (true)
            {
                Console.Clear();
                welcome();
                header();
                subMenu("Manager Tasks");
                cashier_Option = cashier_menu();
                if (cashier_Option == "1")
                {
                    Console.Clear();
                    welcome();
                    header();
                    subMenu("Today's Customer List");
                    viewCustomer(customer);
                }
                else if (cashier_Option == "2")
                {
                    Console.Clear();
                    welcome();
                    header();
                    subMenu("Open a Bank Account");

                    bool accountResult = openAccount(customer);
                    if (accountResult)
                    {
                        Console.WriteLine("Bank Account successfully Opened!");
                    }
                    else
                    {
                        Console.WriteLine("Process failed. Customer already exists or maximum capacity reached.");
                    }
                }
                else if (cashier_Option == "3")
                {
                    Console.Clear();
                    welcome();
                    header();
                    subMenu("Deleting a Bank Account");
                    deleteAccount(customer);
                }
                else if (cashier_Option == "4")
                {
                    Console.Clear();
                    welcome();
                    header();
                    subMenu("Updating Customer's Info");
                    editCustomer(customer);
                }
                else if (cashier_Option == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Try another option.");
                }
                clearScreen();
            }


        }
        static void viewCustomer(List<customer> customer)
        {
            Console.WriteLine("Index\t\tName\t\t\tCNIC\t\tAMOUNT\t\tGENDER\t\tJOB");
            for (int i = 0; i < customer.Count; i++)
            {
                Console.WriteLine((i + 1) + "\t\t" + customer[i].customerName + "\t\t\t " + customer[i].cnic + "\t\t" + customer[i].amount + "\t\t\t" + customer[i].gender + "\t\t" + customer[i].job);
            }

        }
        static bool openAccount(List<customer> customer)
        {
            Console.WriteLine("Enter Your Good Name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter Your CNIC: ");
            long cnic = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Amount you want to Deposit: ");
            float amount = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Job Description: ");
            string job = Console.ReadLine();
            Console.WriteLine("Enter Your Gender: ");
            string gender = Console.ReadLine();

            bool alreadyPresent = false;

            for (int index = 0; index < customer.Count; index++)
            {
                if (customer[index].customerName == customerName && customer[index].cnic == cnic)
                {

                    alreadyPresent = true;
                    break;
                }
            }

            if (alreadyPresent)
            {
                return false;
            }

            customer z = new customer(customerName, cnic, amount, job, gender);
            customer.Add(z);
            return true;

        }

        static void deleteAccount(List<customer> customer)
        {
            if (customer.Count > 0)
            {
                int index = selectCustomer(customer);
                if (index > 0 && index <= customer.Count)
                {
                    index--;
                    customer.RemoveAt(index);

                }
                else
                {
                    Console.WriteLine("Incorrect Input...");
                }
            }
            else
            {
                Console.WriteLine("There are no Cashiers Yet...");
            }
            clearScreen();
        }
        static void editCustomer(List<customer> customer)
        {
            if (customer.Count > 0)
            {
                int index = selectCustomer(customer);
                if (index > 0 && index <= customer.Count)
                {
                    index--;
                    customCustomer(customer, index);

                }
                else
                {
                    Console.WriteLine("Incorrect Input...");
                }
            }
            else
            {
                Console.WriteLine("There are no Cashiers Yet...");
            }
            clearScreen();

        }

        static int selectCustomer(List<customer> customer)
        {
            int index = 0;
            string temp;
            viewCustomer(customer);
            Console.WriteLine();
            Console.Write("Enter their Index: ");
            temp = Console.ReadLine();
            index = validateInt(temp, index);
            return index;

        }
        static void customCustomer(List<customer> customer, int index)
        {

            string name, job, gender;
            long cnic = 0;
            float amount = 0;

            Console.Write("Enter " + (index + 1) + " Name: ");
            name = Console.ReadLine();
            Console.Write("Enter " + (index + 1) + " CNIC: ");
            cnic = long.Parse(Console.ReadLine());
            Console.Write("Enter " + (index + 1) + " Amount: ");
            amount = float.Parse(Console.ReadLine());
            Console.Write("Enter " + (index + 1) + " Job Description: ");
            job = Console.ReadLine();
            Console.Write("Enter " + (index + 1) + " Gender: ");
            gender = Console.ReadLine();

            customer[index].customerName = name;
            customer[index].cnic = cnic;
            customer[index].amount = amount;
            customer[index].job = job;
            customer[index].gender = gender;

        }


        //This function will store records of my bank in file.

        static void saverecordstofile(List<Users> user, ref int i)
        {
            string filepath = "C:\\Users\\Ayaan Goreja\\source\\repos\\BANKapp\\BANKapp\\bankusers.txt";
            StreamWriter file = new StreamWriter(filepath, false);
            for (int x = 0; x < i; x++)
            {
                if (user[x].userName != " ")
                {
                    file.Write(user[x].userName);
                    file.Write(',');
                    file.Write(user[x].passwords);
                    file.Write(',');
                    file.Write(user[x].roles);
                }
                file.Flush();
            }
            file.Close();
        }
        //This function will load the records stored in file to the arrays of program. 
        static void loadrecords(List<Users> user, ref int i)
        {
            i = 0;
            string record = "";
            string filepath = "C:\\Users\\Ayaan Goreja\\source\\repos\\BANKapp\\BANKapp\\bankusers.txt";
            if (File.Exists(filepath))
            {
                using (StreamReader file = new StreamReader(filepath))
                {
                    while ((record = file.ReadLine()) != null)
                    {
                        user[i].userName = getField(record, 1);
                        user[i].passwords = getField(record, 2);
                        user[i].roles = getField(record, 3);
                        i++;
                    }
                }
            }

        }
        //This function will sense the comma by which data is separated in file and helps loadrecords() function to load data in arrays.
        static string getField(string record, int field)
        {
            int comma = 1;
            string result = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma = comma + 1;
                }
                else if (comma == field)
                {
                    result = result + record[x];
                }
            }
            return result;
        }

        static int validateInt(string temp, int number)
        {
            do
            {

                if (int.TryParse(temp, out number) && number >= 0)
                {
                    return number;
                }
                else
                {
                    Console.Write("Invalid input. Please enter a valid number: ");
                    temp = Console.ReadLine();
                }


            } while (!int.TryParse(temp, out number) && number >= 0);

            return number;
        }

        static float validateFloat(string temp, float number)
        {
            do
            {

                if (float.TryParse(temp, out number) && number >= 0)
                {
                    return number;
                }
                else
                {
                    Console.Write("Invalid input. Please enter a valid number: ");
                    temp = Console.ReadLine();
                }


            } while (!float.TryParse(temp, out number) && number >= 0);

            return number;
        }

    }
}

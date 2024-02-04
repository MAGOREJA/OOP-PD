using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace books
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            while (true)
            {
                Console.Clear();
                string choice = menu();
                if (choice == "1")
                {
                    Book b = GetBookInput();
                    books.Add(b);
                    returnMenu();
                }
                else if (choice == "2")
                {
                    for (int i = 0; i < books.Count; i++)
                    {
                        Console.WriteLine();
                        Console.Write(books[i].bookDetails());
                        Console.WriteLine();
                    }
                    returnMenu();
                }
                else if (choice == "3")
                {
                    string title = takeTitle();
                    int index = findIndex(books, title);
                    Console.WriteLine($"Author of '{books[index].title}': {books[index].author}");
                    returnMenu();
                }
                else if (choice == "4")
                {
                    string title = takeTitle();
                    int index = findIndex(books, title);
                    int quantity = takeQuantity();
                    books[index].sellCopies(quantity);
                    returnMenu();
                }
                else if (choice == "5")
                {
                    string title = takeTitle();
                    int index = findIndex(books, title);
                    int quantity = takeQuantity();
                    books[index].restock(quantity);
                    returnMenu();
                }
                else if (choice == "6")
                {
                    Console.WriteLine("The total Number of Books: {0}", books.Count);
                    returnMenu();
                }
                else if (choice == "7")
                {
                    break;
                }
            }

        }

        static string menu()
        {
            string choice;
            Console.WriteLine("=====> MAIN MENU <=====");
            Console.WriteLine();
            Console.WriteLine("1. ADD BOOK");
            Console.WriteLine("2. VIEW BOOKS");
            Console.WriteLine("3. GET AUTHOR");
            Console.WriteLine("4. SELL COPIES OF A BOOK");
            Console.WriteLine("5. RESTOCK A BOOK");
            Console.WriteLine("6. GET THE NUMBER OF BOOKS");
            Console.WriteLine("7. EXIT");
            Console.Write("ENTER YOUR CHOICE: ");
            choice = Console.ReadLine();
            return choice;
        }

        static Book GetBookInput()
        {
            Console.Write("Enter the title of the book:");
            string title = Console.ReadLine();

            Console.Write("Enter the author of the book:");
            string author = Console.ReadLine();

            Console.Write("Enter the publication year of the book:");
            string publicationYear = Console.ReadLine();

            Console.Write("Enter the price of the book:");
            float price = float.Parse(Console.ReadLine());

            Console.Write("Enter the quantity in stock of the book:");
            int quantityInStock = int.Parse(Console.ReadLine());

            // Create and return a new Book object with the user-provided input
            return new Book(title, author, publicationYear, price, quantityInStock);
        }

        static int findIndex(List<Book> books, string title)
        {
            int index = -1;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].title == title)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        static string takeTitle()
        {
            Console.WriteLine("Enter the title of the book:");
            string title = Console.ReadLine();
            return title;
        }

        static int takeQuantity()
        {
            Console.WriteLine("Enter the number of books: ");
            return int.Parse(Console.ReadLine());
        }

        static void returnMenu()
        {
            Console.WriteLine();
            Console.Write("Enter any key...");
            Console.Read();

        }
        
    }
}

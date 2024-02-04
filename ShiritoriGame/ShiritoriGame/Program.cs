using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiritoriGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool checkBegin = false;
            bool checkIntermediate = false;
            Class gameClass = new Class();
            Console.WriteLine("======= SHIRITORI GAME =======");
            Console.WriteLine("========= HERE WE GO =========");
            Console.WriteLine();
            while (true)
            {
                string word = takeWord();

                if (gameClass.checkPrev(word, checkBegin))
                {
                    gameClass.go(word, checkBegin);
                    gameClass.WordShow();
                }
                else
                {
                    gameClass.gameOver = true;
                }

                if (gameClass.gameOver)
                {
                    Console.WriteLine("The Game is Over.....");
                    string choice = ContinueOrStop();
                    if (choice == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("======= SHIRITORI GAME =======");
                        Console.WriteLine("====== HERE WE GO AGAIN ======");
                        Console.WriteLine();
                        gameClass.reset();
                        checkBegin = false;
                        checkIntermediate = true;
                    }
                    else
                    {
                        break;
                    }
                }

                if (!checkIntermediate)
                {
                    checkBegin = true;
                }
                else
                {
                    checkIntermediate = false;
                }

            }

        }

        static string takeWord()
        {
            Console.Write("Enter your word: ");
            string word = Console.ReadLine();
            return word;
        }

        static string ContinueOrStop()
        {
            Console.Write("Press 1 to Restart the Game else you can Enter any key to Exit the Game: ");
            return Console.ReadLine();
        }

        
    }
}

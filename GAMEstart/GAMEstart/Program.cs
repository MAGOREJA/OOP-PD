using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GAMEstart.BL;

namespace GAMEstart
{
    class Program
    {
        public static string[] boardRows =
            {
            "################################################################################################",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#######################              ###########################################################",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                     ##########",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "################################################################################################",
            "#                                   |  Health  =  100       |                                  #",
            "#                                                                                              #",
            "################################################################################################"
            };
        static void Main(string[] args)
        {
            char enemy1Dir = 'U';
            char enemy2Dir = 'D';
            bool fired = false;

            char[,] Maze = new char[34, 99];
            player Player = new player('M', 17, 17);
            List<enemy> enemies = new List<enemy>();
            enemy enemy1 = new enemy('X', 7, 90, 'x');
            enemies.Add(enemy1);
            enemy enemy2 = new enemy('W', 25, 90, 'w');
            enemies.Add(enemy2);


            for (int i = 0; i < boardRows.Length; i++)
            {
                for (int j = 0; j < boardRows[i].Length; j++)
                {
                    Maze[i, j] = boardRows[i][j];
                }
            }

            Maze[Player.playerx, Player.playery] = Player.symbol;
            Maze[enemies[0].enemyx, enemies[0].enemyy] = enemies[0].symbol;
            Maze[enemies[1].enemyx, enemies[1].enemyy] = enemies[1].symbol;

            while (true)
            {
                printmaze(Maze);

            // Capture keyboard input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Checking which key was pressed
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Player.moveHeroLeft(Maze);
                        Console.WriteLine("Left");
                        break;
                    case ConsoleKey.RightArrow:
                        Player.moveHeroRight(Maze);
                        Console.WriteLine("Right");
                        break;
                    case ConsoleKey.UpArrow:
                        Player.moveHeroUp(Maze);
                        Console.WriteLine("Up");
                        break;
                    case ConsoleKey.DownArrow:
                        Player.moveHeroDown(Maze);
                        Console.WriteLine("Down");
                        break;
                    case ConsoleKey.Spacebar:
                        if (!fired)
                        {
                            Player.createFire(Maze);
                            fired = true;
                        }
                        break;
                    default:
                        break;
                }
                if (fired)
                {
                    moveFire(Maze, ref fired);
                }

                if (!enemies[0].enemyfire)
                {
                    enemies[0].printenemyfire(Maze);
                }
                else
                {
                    enemies[0].moveEnemyFire(Maze);
                }

                if (!enemies[1].enemyfire)
                {
                    enemies[1].printenemyfire(Maze);
                }
                else
                {
                    enemies[1].moveEnemyFire(Maze);
                }


                enemies[0].moveEnemy(Maze, ref enemy1Dir);
                enemies[1].moveEnemy(Maze, ref enemy2Dir);
                Thread.Sleep(75);
            }

        }


        static void printmaze(char[,] Maze)
        {
            string print = "";
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    print += Maze[i, j];
                }
                print += "\n";
            }
            Console.Clear();
            Console.Write(print);
        }


        static void moveFire(char[,] Maze, ref bool fired)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 98; j++)
                {
                    if (Maze[i, j] == 'o')
                    {

                        if (Maze[i, j + 1] != '#')
                        {
                            Maze[i, j + 1] = 'o';
                            Maze[i, j] = ' ';
                            break;
                        }
                        else
                        {
                            Maze[i, j] = ' ';
                            fired = false;
                            break;
                        }
                    }
                }
            }
        }


    }
}

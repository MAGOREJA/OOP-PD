using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMEstart.BL
{
    class player
    {
        public player(char Playersymbol, int px, int py)
        {
            symbol = Playersymbol;
            playerx = px;
            playery = py;
        }

        public char symbol;
        public int playerx;
        public int playery;


        public void moveHeroLeft(char[,] Maze)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Maze[i, j] == symbol)
                    {
                        Maze[i, j] = ' ';
                        if (Maze[i, j - 1] != '#')
                        {
                            Maze[i, j - 1] = symbol;
                        }
                        else
                        {
                            Maze[i, j] = symbol;
                        }

                        break;

                    }
                }
            }
        }

        public void moveHeroRight(char[,] Maze)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Maze[i, j] == symbol)
                    {
                        Maze[i, j] = ' ';

                        if (Maze[i, j + 1] != '#')
                        {
                            Maze[i, j + 1] = symbol;
                        }
                        else
                        {
                            Maze[i, j] = symbol;
                        }

                        break;
                    }
                }
            }
        }

        public void moveHeroUp(char[,] Maze)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Maze[i, j] == symbol)
                    {
                        Maze[i, j] = ' ';

                        if (Maze[i - 1, j] != '#')
                        {
                            Maze[i - 1, j] = symbol;
                        }
                        else
                        {
                            Maze[i, j] = symbol;
                        }

                        break;
                    }
                }
            }
        }

        public void moveHeroDown(char[,] Maze)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Maze[i, j] == symbol)
                    {
                        Maze[i, j] = ' ';

                        if (Maze[i + 1, j] != '#')
                        {
                            Maze[i + 1, j] = symbol;
                        }
                        else
                        {
                            Maze[i, j] = symbol;
                        }

                        break;

                    }
                }
            }
        }

        public void createFire(char[,] Maze)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Maze[i, j] == symbol)
                    {
                        if (Maze[i, j + 1] != '#')
                        {
                            Maze[i, j + 1] = 'o';

                        }

                    }
                }
            }
        }


    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMEstart.BL
{
    class enemy
    {
        public enemy(char Enemysymbol, int ex, int ey, char fireSymbol)
        {
            symbol = Enemysymbol;
            enemyx = ex;
            enemyy = ey;
            this.fireSymbol = fireSymbol;
        }

        public char symbol;
        public int enemyx;
        public int enemyy;
        public char fireSymbol;
        public bool enemyfire = false;


        public void moveEnemy(char[,] Maze, ref char enemyDir)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Maze[i, j] == symbol)
                    {
                        // Clear current position

                        if (enemyDir == 'D')
                        {
                            if (Maze[i + 1, j] != '#') // Check if moving down is valid
                            {
                                Maze[i, j] = ' ';
                                Maze[i + 1, j] = symbol; // Update position
                                break;
                            }
                            else
                            {
                                enemyDir = 'U'; // Change direction to 'U'
                            }
                        }
                        else if (enemyDir == 'U')
                        {
                            if (Maze[i - 1, j] != '#') // Check if moving up is valid
                            {
                                Maze[i, j] = ' ';
                                Maze[i - 1, j] = symbol; // Update position
                                break;
                            }
                            else
                            {
                                enemyDir = 'D'; // Change direction to 'D'
                            }
                        }
                    }
                }
            }
        }

        public void printenemyfire(char[,] Maze)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Maze[i, j] == symbol)
                    {
                        Maze[i, j - 1] = fireSymbol;
                        enemyfire = true;

                    }
                }
            }
        }

        public void moveEnemyFire(char[,] Maze)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Maze[i, j] == fireSymbol)
                    {

                        if (Maze[i, j - 1] != '#')
                        {
                            Maze[i, j - 1] = fireSymbol;
                            Maze[i, j] = ' ';
                            break;
                        }
                        else
                        {
                            Maze[i, j] = ' ';
                            enemyfire = false;
                            break;
                        }
                    }
                }
            }
        }
    }

}

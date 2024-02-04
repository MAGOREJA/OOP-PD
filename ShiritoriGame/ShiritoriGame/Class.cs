using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiritoriGame
{
    class Class
    {
        public List<string> words = new List<string>();
        public bool gameOver = false;

        public void go(string word, bool checkFirst)
        {

            for (int i = 0; i < words.Count; i++)
            {
                if (word == words[i])
                {
                    gameOver = true;
                    break;

                }

            }

            if (!gameOver)
            {
                words.Add(word);
            }
        }

        public bool checkPrev(string word, bool checkBegin)
        {
            if (checkBegin)
            {
                char firstChar = word[0];
                string lastword = words[words.Count - 1];
                char lastChar = lastword[lastword.Length - 1];

                if (firstChar == lastChar)
                {
                    return true;
                }


            }

            if (!checkBegin)
            {
                return true;
            }

            return false;
        }

        public void WordShow()
        {
            Console.Write("[ ");
            for (int i = 0; i < words.Count; i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        public void reset()
        {
            words.Clear();
            gameOver = false;
        }

    }
}

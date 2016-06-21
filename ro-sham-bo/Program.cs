using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoShamBo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Enter (R)ock (P)aper (S)cissors or (Q)uit");
            char player = Console.ReadLine()[0];
            player = Char.ToLower(player);

            if (player != 'r' && player != 'p' && player != 's' && player != 'q')
            {
                Console.WriteLine("Invalid Input: " + player);
                Environment.Exit(0);
            }

            while (player != 'q')
            {
                int ai = rand.Next();
                ai = ai % 3;
                char comp;

                if (ai == 0)
                {
                    comp = 'r';
                }
                else if (ai == 1)
                {
                    comp = 'p';
                }
                else
                {
                    comp = 's';
                }

                if (player == 'r')
                {
                    if (comp == 'r')
                    {
                        Console.WriteLine("Tie: Rock & Rock");
                    }
                    else if (comp == 'p')
                    {
                        Console.WriteLine("Lose: Rock & Paper");
                    }
                    else
                    {
                        Console.WriteLine("Win: Rock & Scissors");
                    }
                }

                if (player == 'p')
                {
                    if (comp == 'r')
                    {
                        Console.WriteLine("Win: Paper & Rock");
                    }
                    else if (comp == 'p')
                    {
                        Console.WriteLine("Tie: Paper & Paper");
                    }
                    else
                    {
                        Console.WriteLine("Lose: Paper & Scissors");
                    }
                }

                if (player == 's')
                {
                    if (comp == 'r')
                    {
                        Console.WriteLine("Lose: Scissors & Rock");
                    }
                    else if (comp == 'p')
                    {
                        Console.WriteLine("Win: Scissors & Paper");
                    }
                    else
                    {
                        Console.WriteLine("Tie: Scissors & Scissors");
                    }
                }

                player = Console.ReadLine()[0];
                player = Char.ToLower(player);
                if (player != 'r' && player != 'p' && player != 's' && player != 'q')
                {
                    Console.WriteLine("Invalid Input: " + player);
                    Environment.Exit(0);
                }
            }

        }
    }
}

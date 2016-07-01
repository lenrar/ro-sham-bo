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
            string PlayerString = "";
            player = Char.ToLower(player);
            switch (player) {
                case 'r':
                    PlayerString = "Rock";
                    Console.WriteLine("Rock");                    
                    break;
                case 'p':
                    PlayerString = "Paper";
                    break;
                case 's':
                    PlayerString = "Scissors";
                    break;
                case 'q':
                    break;
                default:
                    throw new ArgumentException("Invalid input: " + player);
                    break;

            }

            while (player != 'q')
            {
                int ai = rand.Next();
                ai = ai % 3;
                String comp;
                switch (ai) {
                    case 0:
                        comp = "Rock";
                        break;
                    case 1:
                        comp = "Paper";
                        break;
                    case 2:
                        comp = "Scissors";
                        break;
                    default:
                        comp = "Rock";
                        break;
                }

                if (PlayerString.Equals(comp)) {
                    Console.WriteLine(String.Format("Tie: {0} and {1}", PlayerString, comp));          
                } else {
                    string both = PlayerString + comp;
                    string output = "";
                    switch (both) {
                        case "RockScissors":
                        case "PaperRock":
                        case "ScissorsPaper":
                            output = String.Format("You win: {0} beats {1}", PlayerString, comp);
                            break;
                        default:
                            output = String.Format("CPU wins: {0} beats {1}", comp, PlayerString);
                            break;
                    }
                    Console.WriteLine(output);
                }

                player = Console.ReadLine()[0];
                player = Char.ToLower(player);
                switch (player) {
                    case 'r':
                        PlayerString = "Rock";
                        break;
                    case 'p':
                        PlayerString = "Paper";
                        break;
                    case 's':
                        PlayerString = "Scissors";
                        break;
                    case 'q':
                        break;
                    default:
                        throw new ArgumentException("Invalid input: " + player);
                        break;

                }
            }

        }
    }
}

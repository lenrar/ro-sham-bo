using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoShamBo
{
    class Program
    {
        static double playerWins = 0;
        static double cpuWins = 0;
        static double ties = 0;
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Ro-Sham-Bo");
            /*Console.WriteLine("______            _____ _                          ______");
            Console.WriteLine("| ___ \\          / ___ | |                         | ___ \\      ");
            Console.WriteLine("| | _ / / ___ ______\\ `--.| | __   __ _ _ __ ___ ______ | | _ / / ___");
            Console.WriteLine("|    // _ \\______|`--. \\ '_ \\ / _` | '_ ` _ \\______| ___ \\/ _ \\ ");
            Console.WriteLine("| |\\ \\ (_) |     /\\__ / / | | | (_ | | | | | | |     | | _ / / (_) |");
            Console.WriteLine("\\_ | \\_\\___ /      \\____ /| _ | | _ |\\__, _ | _ | | _ | | _ |     \\____ / \\___ /");*/
            //Console.WriteLine("Ro-Sham-Bo");
            Console.WriteLine("Press any key to continue");

            ConsoleKey input = ConsoleKey.NoName;
            Console.ReadKey();
            while(input != ConsoleKey.NumPad3 && input != ConsoleKey.D3) {
                Console.Clear();
                Console.WriteLine("Main Menu:\r\n1:\tNew Game\r\n2:\tStatistics\r\n3:\tQuit");
                
                input = Console.ReadKey().Key;
                switch (input) {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        GameLoop();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Statistics();
                        break;
                    default:
                        Console.WriteLine("Unrecognized Command.");
                        break;
                }

            }
 

        }

        static void GameLoop() {
            Console.Clear();
            Random rand = new Random();
            /*Console.WriteLine("Enter (R)ock (P)aper (S)cissors or (B)ack");
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

            }*/
            ConsoleKey player = ConsoleKey.NoName;
            string PlayerString = "";
            while (player != ConsoleKey.B) {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("Enter (R)ock (P)aper (S)cissors or (B)ack");
                player = Console.ReadKey().Key;
                Console.WriteLine();
                switch (player) {
                    case ConsoleKey.R:
                        PlayerString = "Rock";
                        break;
                    case ConsoleKey.P:
                        PlayerString = "Paper";
                        break;
                    case ConsoleKey.S:
                        PlayerString = "Scissors";
                        break;
                    case ConsoleKey.B:
                        return; 
                    default:
                        Console.WriteLine("Invalid character, press any key to continue");
                        Console.ReadKey();
                        continue;
                        // throw new ArgumentException("Invalid input: " + player);
                }
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
                string output = "";
                if (PlayerString.Equals(comp)) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    output = String.Format("Tie: {0} and {1}", PlayerString, comp);
                    ro_sham_bo.Properties.Settings.Default.Ties++;
                    ro_sham_bo.Properties.Settings.Default.Save();
                    //ties++;
                } else {
                    string both = PlayerString + comp;

                    switch (both) {
                        case "RockScissors":
                        case "PaperRock":
                        case "ScissorsPaper":
                            Console.ForegroundColor = ConsoleColor.Green;
                            output = String.Format("You win: {0} beats {1}", PlayerString, comp);
                            ro_sham_bo.Properties.Settings.Default.Wins++;
                            ro_sham_bo.Properties.Settings.Default.Save();
                            playerWins++;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            output = String.Format("CPU wins: {0} beats {1}", comp, PlayerString);
                            ro_sham_bo.Properties.Settings.Default.Ties++;
                            ro_sham_bo.Properties.Settings.Default.Save();
                            cpuWins++;
                            break;
                    }
                }
                Console.WriteLine(output + "\r\nPress any key to continue");
                Console.ReadKey();

            }
        }

        static void Statistics() {
            double total = ro_sham_bo.Properties.Settings.Default.Wins + ro_sham_bo.Properties.Settings.Default.Losses + ro_sham_bo.Properties.Settings.Default.Ties;
            Console.Clear();
            if (total <= 0) {
                Console.WriteLine("No games played. Check back after you have played somoe games.\r\nPress any key to continue");
            } else {
                double winPercentage = ((ro_sham_bo.Properties.Settings.Default.Wins) / (total)) * 100;
                Console.WriteLine(string.Format("Games Won:\t{0}\r\nGames Lost:\t{1}\r\nGames Tied:\t{2}\r\nWin Percentage:\t{3}%\r\nPress any key to continue", ro_sham_bo.Properties.Settings.Default.Wins, ro_sham_bo.Properties.Settings.Default.Losses, ro_sham_bo.Properties.Settings.Default.Ties, winPercentage));
            }
            Console.ReadKey();
        }

        static void Save(int pos) {

        }
    }
}

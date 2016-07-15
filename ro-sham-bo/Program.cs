using System;
using System.Collections;
using System.IO;


namespace RoShamBo
{
    class Program
    {
        private const int NewGame = 0;
        private const int Stats = 1;
        private const int Reset = 2;
        private const int Quit = 3;

        private static string[] MenuItems = new string[4] { "New Game", "Statistics", "Reset", "Quit" };

        private static double Wins = 0;
        private static double Losses = 0;
        private static double Ties = 0;

        //Differentiates between left and right hands, for printing icons.
        private static int LeftHand = 3;

        private enum Moves { Rock, Paper, Scissors };
        private static ArrayList[] Icons = new ArrayList[6] { new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() };
        private static string IconPath = Directory.GetCurrentDirectory() + @"\..\..\resources\icons.txt";

        static void Main(string[] args)
        {

            Setup();
            Console.WriteLine("Welcome to Ro-Sham-Bo");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            HandleMenu(Menu(MenuItems));

            //bool running = true;
            //while (running)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Main Menu:\r\n1:\tNew Game\r\n2:\tStatistics\r\n3:\tReset\r\n4:\tQuit");

            //    input = Console.ReadKey(true).Key;
            //    switch (input)
            //    {
            //        case ConsoleKey.NumPad1:
            //        case ConsoleKey.D1:
            //            GameLoop();
            //            break;
            //        case ConsoleKey.NumPad2:
            //        case ConsoleKey.D2:
            //            Statistics();
            //            break;
            //        case ConsoleKey.NumPad3:
            //        case ConsoleKey.D3:
            //            ro_sham_bo.Properties.Settings.Default.Reset();
            //            break;
            //        case ConsoleKey.NumPad4:
            //        case ConsoleKey.D4:
            //            running = false;
            //            break;
            //        default:
            //            Console.WriteLine("Unrecognized Command.");
            //            break;
            //    }

            //}


        }
        private static void Setup()
        {
            StreamReader IconReader = new StreamReader(IconPath);
            int i = 0;
            while (!IconReader.EndOfStream)
            {
                string line = IconReader.ReadLine();
                //Start on the next icon when an empty line is reached.
                if (line.Trim().Equals(""))
                {
                    i++;
                    continue;
                }
                Icons[i].Add(line);
            }
        }

        static int Menu(string[] inArray)
        {
            Console.Clear();
            Console.WriteLine("Main Menu: ");
            bool loopComplete = false;
            int topOffset = Console.CursorTop;
            int bottomOffset = 0;
            int selectedItem = 0;
            ConsoleKeyInfo kb;

            Console.CursorVisible = false;

            //this will resise the console if the amount of elements in the list are too big
            if ((inArray.Length) > Console.WindowHeight)
            {
                throw new Exception("Too many items in the array to display");
            }

            /**
             * Drawing phase
             * */
            while (!loopComplete)
            {//This for loop prints the array out
                for (int i = 0; i < inArray.Length; i++)
                {
                    if (i == selectedItem)
                    {//This section is what highlights the selected item
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("-" + inArray[i]);
                        Console.ResetColor();
                    }
                    else
                    {//this section is what prints unselected items
                        Console.WriteLine("-" + inArray[i]);
                    }
                }

                bottomOffset = Console.CursorTop;

                /*
                 * User input phase
                 * */

                kb = Console.ReadKey(true); //read the keyboard

                switch (kb.Key)
                { //react to input
                    case ConsoleKey.UpArrow:
                        if (selectedItem > 0)
                        {
                            selectedItem--;
                        }
                        else
                        {
                            selectedItem = (inArray.Length - 1);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (selectedItem < (inArray.Length - 1))
                        {
                            selectedItem++;
                        }
                        else
                        {
                            selectedItem = 0;
                        }
                        break;

                    case ConsoleKey.Enter:
                        loopComplete = true;
                        break;
                }
                //Reset the cursor to the top of the screen
                Console.SetCursorPosition(0, topOffset);
            }
            //set the cursor just after the menu so that the program can continue after the menu
            Console.SetCursorPosition(0, bottomOffset);

            Console.CursorVisible = true;
            return selectedItem;
        }

        static void HandleMenu(int MenuItem)
        {
            switch (MenuItem)
            {
                case NewGame:
                    GameLoop();
                    HandleMenu(Menu(MenuItems));
                    break;
                case Stats:
                    Statistics();
                    HandleMenu(Menu(MenuItems));
                    break;
                case Reset:
                    ro_sham_bo.Properties.Settings.Default.Reset();
                    HandleMenu(Menu(MenuItems));
                    break;
                case Quit:
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(1);
                    break;
            }
        }

        static void GameLoop()
        {
            Console.Clear();
            Random rand = new Random();
            ConsoleKey player = ConsoleKey.NoName;
            string PlayerString = "";
            while (player != ConsoleKey.B)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("Enter (R)ock (P)aper (S)cissors or (B)ack");
                player = Console.ReadKey(true).Key;
                if (player.Equals(ConsoleKey.NoName))
                    player = Console.ReadKey(true).Key;
                switch (player)
                {
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
                        player = Console.ReadKey(true).Key;
                        continue;
                        // throw new ArgumentException("Invalid input: " + player);
                }
                int ai = rand.Next();
                ai = ai % 3;
                String comp;
                switch (ai)
                {
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
                if (PlayerString.Equals(comp))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    output = String.Format("Tie: {0} and {1}", PlayerString, comp);
                    ro_sham_bo.Properties.Settings.Default.Ties++;
                    ro_sham_bo.Properties.Settings.Default.Save();
                }
                else
                {
                    string both = PlayerString + comp;

                    switch (both)
                    {
                        case "RockScissors":
                        case "PaperRock":
                        case "ScissorsPaper":
                            Console.ForegroundColor = ConsoleColor.Green;
                            output = String.Format("You win: {0} beats {1}", PlayerString, comp);
                            ro_sham_bo.Properties.Settings.Default.Wins++;
                            ro_sham_bo.Properties.Settings.Default.Save();
                            Wins++;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            output = String.Format("CPU wins: {0} beats {1}", comp, PlayerString);
                            ro_sham_bo.Properties.Settings.Default.Losses++;
                            ro_sham_bo.Properties.Settings.Default.Save();
                            Losses++;
                            break;
                    }
                }
                Console.WriteLine(Results(PlayerString, comp));
                Console.WriteLine(output + "\r\nPress any key to continue");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey(true);

            }
        }

        static string Results(string Right, string Left)
        {
            Moves PlayerMove = Moves.Rock;
            Moves CPUMove = Moves.Rock;
            string ret = "";
            switch (Right)
            {
                case "Rock":
                    PlayerMove = Moves.Rock;
                    break;
                case "Paper":
                    PlayerMove = Moves.Paper;
                    break;
                case "Scissors":
                    PlayerMove = Moves.Scissors;
                    break;
            }
            switch (Left)
            {
                case "Rock":
                    CPUMove = Moves.Rock;
                    break;
                case "Paper":
                    CPUMove = Moves.Paper;
                    break;
                case "Scissors":
                    CPUMove = Moves.Scissors;
                    break;
            }
            int RightIndex = (int)PlayerMove;
            int LeftIndex = (int)CPUMove + LeftHand;

            // Not very robust atm, doesn't support different sized icons.
            for (int i = 0; i < Math.Min(Icons[RightIndex].Count, Icons[LeftIndex].Count); i++)
            {
                ret += String.Format("{0,-20}{1,20}\r\n", Icons[RightIndex][i], Icons[LeftIndex][i]);
            }
            return ret;
        }

        static void Statistics()
        {
            double total = ro_sham_bo.Properties.Settings.Default.Wins + ro_sham_bo.Properties.Settings.Default.Losses + ro_sham_bo.Properties.Settings.Default.Ties;
            Console.Clear();
            if (total <= 0)
            {
                Console.WriteLine("No games played. Check back after you have played somoe games.\r\nPress any key to continue");
            }
            else
            {
                double winPercentage = ((ro_sham_bo.Properties.Settings.Default.Wins) / (total)) * 100;
                Console.WriteLine(string.Format("Games Won:\t{0}\r\nGames Lost:\t{1}\r\nGames Tied:\t{2}\r\nWin Percentage:\t{3}%\r\nPress any key to continue", ro_sham_bo.Properties.Settings.Default.Wins, ro_sham_bo.Properties.Settings.Default.Losses, ro_sham_bo.Properties.Settings.Default.Ties, winPercentage));
            }
            Console.ReadKey(true);
        }

        static void Save(int pos)
        {

        }
    }
}

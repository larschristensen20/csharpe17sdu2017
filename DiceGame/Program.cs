using System;
using System.Threading;

namespace DiceGame
{
    class Program
    {
        private Player _player1;
        private Player _player2;
        private Dice dice;
        private int scoreToWin;
        private Boolean isGameActive;

        // displays how to play the game
        public void HowToPlay()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to Dice King, a nonsense game of skillful luck");
            Console.WriteLine("Each player roll a pair of dice per turn");
            Console.WriteLine("If the player rolls a pair (i.e. 2 and 2), the score is multiplied by 2");
            Console.WriteLine("If the player doesn't roll a pair, then the score is simply the value of the dice");
            Console.WriteLine("Each round the player totalscore is calculated");
            Console.WriteLine("The first player to get to a certain score wins");
            Console.WriteLine("Good luck");
            Console.WriteLine("");
        }

        //displays the general game menu
        public void GameMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("1: Start a new game");
            Console.WriteLine("2: Tutorial");
            Console.WriteLine("3: Exit game");
            Console.WriteLine("");

        }

        // selection for the general GameMenu
        public void SelectAGameMenuOption(int selection)
        {
            switch (selection)
            {
                case 1:
                    this.NewGame();
                    break;
                case 2:
                    this.HowToPlay();
                    break;
                case 3:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }


        // displays a specific game menu, only when playing a game
        public void GameMenuWhilePlaying()
        {
            Console.WriteLine("1: Play a round");
            Console.WriteLine("2: Who has the lead?");
            Console.WriteLine("3: Rage quit");
        }

        // selection for the GameMenuWhilePlaying
        public void SelectAGameMenuWhilePlayingOption(int selection)
        {
            switch (selection)
            {
                case 1:
                    this.PlayARound(_player1);
                    this.PlayARound(_player2);
                    break;
                case 2:
                    this.WhoHasTheLead();
                    break;
                case 3:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }


        // plays a round in the game
        public void PlayARound(Player player)
        {
            dice.TossDice();
            if (dice.PairCheck)
            {
                player.TotalScore += dice.DiceScore;
                Console.WriteLine(player.Name + " got a pair of " + dice._die1Score + " 's");
                Console.WriteLine(player.Name + " will get double points: " +"("+ dice._die1Score + " + " + dice._die2Score +")"+" * 2"+ " = " + dice.DiceScore);
                Console.WriteLine(player.Name + " scored: " + dice.DiceScore);
                Console.WriteLine(player.Name + " now has " + player.TotalScore + " in total");
                Console.WriteLine("");
            }
            else
            {
                player.TotalScore += dice.DiceScore;
                Console.WriteLine(player.Name + " rolled a " + dice._die1Score + " and a " + dice._die2Score);
                Console.WriteLine(player.Name + " scored: " + dice.DiceScore);
                Console.WriteLine(player.Name + " now has " + player.TotalScore + " in total");
                Console.WriteLine("");
            }

        }

        // checks who has the lead, and displays it in console
        public void WhoHasTheLead()
        {
            if (_player1.TotalScore == _player2.TotalScore)
            {
                Console.WriteLine("");
                Console.WriteLine("Somehow it's a draw at the moment!");
                Console.WriteLine(_player1.Name + " has " + _player1.TotalScore);
                Console.WriteLine(_player2.Name + " has " + _player2.TotalScore);
                Console.WriteLine("");
            }
            else if (_player1.TotalScore > _player2.TotalScore)
            {
                Console.WriteLine("");
                Console.WriteLine(_player1.Name + " is leading at the moment, with " + _player1.TotalScore + ", what a god!");
                Console.WriteLine(_player2.Name + " is not far behind, with " + _player2.TotalScore + ", good luck with that");
                Console.WriteLine("");
            }
            else if (_player1.TotalScore < _player2.TotalScore)
            {
                Console.WriteLine("");
                Console.WriteLine(_player2.Name + " is leading at the moment, with " + _player2.TotalScore + ", what a champ!");
                Console.WriteLine(_player1.Name + " is not far behind, with " + _player1.TotalScore + ", better get that luck on son");
                Console.WriteLine("");
            }
        }


        // method for checking if anyone has won, and displaying who has won
        public Boolean WhoHasWon()
        {
            if (_player1.TotalScore >= scoreToWin && _player2.TotalScore >= scoreToWin)
            {
                Console.WriteLine("");
                Console.WriteLine("It's a draw!");
                Console.WriteLine("The stars have aligned and both players has won");
                
                if (_player1.TotalScore > _player2.TotalScore)
                {
                    Console.WriteLine("");
                    Console.WriteLine("However, " + _player1.Name + " is still more special, since he" +
                        " / she has more points than " + _player2.Name);
                    

                }
                else if (_player1.TotalScore == _player2.TotalScore)
                {
                    Console.WriteLine("");
                    Console.WriteLine("It's miracle, both players are equally good");
                    Console.WriteLine("They have the exact same score");
                    Console.WriteLine("Their score is " + _player2.TotalScore);
                    
                    
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("However, " + _player2.Name + " is still more special, since he" +
                        " / she has more points than " + _player1.Name);
                    
                    
                }
                return true;
            }
            else if (_player1.TotalScore >= scoreToWin && _player2.TotalScore < scoreToWin)
            {
                Console.WriteLine("");
                Console.WriteLine(_player1.Name + " has the honor of calling him-/herself, Dice King/Queen");
                Console.WriteLine("All hail " + _player1.Name);
                Console.WriteLine(_player2.Name + " is a loser!");
                return true;
                
            }
            else if (_player1.TotalScore < scoreToWin && _player2.TotalScore >= scoreToWin)
            {
                Console.WriteLine("");
                Console.WriteLine(_player2.Name + " has the honor of calling him-/herself, Dice King/Queen");
                Console.WriteLine("All hail " + _player2.Name);
                Console.WriteLine(_player1.Name + " is a loser!");
                return true;
            }
            return false;
        }

        // method for starting a game
        public void NewGame()
        {
            isGameActive = true;
            String player1Name;
            String player2Name;


            Console.WriteLine("Please write a name for player 1: ");
            player1Name = Console.ReadLine();

            Console.WriteLine("Please write a name for player 2: ");
            player2Name = Console.ReadLine();

            Console.WriteLine("Please write the score needed to Win: ");
            // checks if the input is a number
            if (!int.TryParse(Console.ReadLine(), out scoreToWin))
            {
                Console.WriteLine("Please input an actual number, you dummy...");
                scoreToWin = int.Parse(Console.ReadLine());
            }

            _player1 = new Player(player1Name);

            _player2 = new Player(player2Name);
            dice = new Dice();

        }


        // the game loop
        public void Run()
        {
            // before starting a game
            while (!isGameActive)
            {
                GameMenu();
                // checks if the input is a number
                if (!int.TryParse(Console.ReadLine(), out int selection))
                {
                    Console.WriteLine("You must input a valid selection between 1-3");
                }
                else
                {
                    while (selection > 3 || selection < 0)
                    {
                        Console.WriteLine("You must input a valid selection between 1-3");
                        selection = int.Parse(Console.ReadLine());
                    }

                }
                SelectAGameMenuOption(selection);
            }

            // after a game has been started
            while (!WhoHasWon())
            {
                GameMenuWhilePlaying();
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("You must input a valid selection between 1-3");
                }
                else
                { // check
                    while (input > 3 || input < 0)
                    {
                        Console.WriteLine("You must input a valid selection between 1-3");
                        input = int.Parse(Console.ReadLine());
                    }

                }
                SelectAGameMenuWhilePlayingOption(input);

                Boolean hasAnyoneWon = WhoHasWon();
                if(hasAnyoneWon)
                {
                    Console.WriteLine("Game will now exit, thanks for playing.");
                    Thread.Sleep(10000);
                    Console.WriteLine("Game ended");
                }
            }
        }

        static void Main(string[] args)
        {
            new Program().Run();
        }
    }
}

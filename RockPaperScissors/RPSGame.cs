using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    class RPSGame
    {
        public enum Hand { Rock=1,Paper,Scissors};
        public enum Outcome { Win,Lose,Tie};

        public Hand Player0ne { get; set; }
        public Hand PlayerTwo { get; set; }
        public char UserSelection { get; set; }

        
        public Hand GetUserHand()
        {
            while (!validateSelection())
            {
                Console.Clear();
                Console.WriteLine("Invalid Input");
                Screen();
                UserSelection = Convert.ToChar(Console.ReadLine());
            }
            switch (Char.ToUpper(UserSelection))
            {
                case 'R':
                    PlayerTwo = Hand.Rock;
                    break;
                case 'P':
                    PlayerTwo = Hand.Paper;
                    break;
                case 'S':
                    PlayerTwo = Hand.Scissors;
                    break;

                default:
                    throw new Exception("Unexpected Error");
            }

            return PlayerTwo;
        }

        public void PlayGame ()
        {
            bool gameOver = false;
            var rand = new Random();
            char response;

            while(!gameOver)
            {
                Screen();
                UserSelection = Convert.ToChar(Console.ReadLine());
                GetUserHand();
                Player0ne = (Hand)rand.Next(1, 4);
                Console.Clear();
                Console.WriteLine("Computer's Hand : {0}", Player0ne);
                Console.WriteLine("Player's Hand : {0}", PlayerTwo);

                if (DetermineWinner() == Outcome.Win)
                    Console.WriteLine("{0} beats {1}. Player wins", PlayerTwo, Player0ne);
                else if (DetermineWinner() == Outcome.Lose)
                    Console.WriteLine("{0} beats {1}. Computer wins", Player0ne, PlayerTwo);
                else
                    Console.WriteLine("It's a tie");

                Console.WriteLine("\nWould you like to play another game(y or n)");
                response = Convert.ToChar(Console.ReadLine());
                while (validateResponse(response) == false)
                {
                    Console.WriteLine("Invalid input, Please re-enter your selection : ");
                    response = Convert.ToChar(Console.ReadLine());
                }
                if (response == 'N' || response == 'n')
                    gameOver = true;
                Console.Clear();

            }
        }
        public bool validateResponse(char response)
        {
            if (Char.ToUpper(response) != 'Y' && Char.ToUpper(response) != 'N')
                return false;
            return true;
        }
        public Outcome DetermineWinner()
        {
            if (PlayerTwo == Hand.Scissors && Player0ne == Hand.Paper)
                return Outcome.Win;
            else if (PlayerTwo == Hand.Rock && Player0ne == Hand.Scissors)
                return Outcome.Win;
            else if (PlayerTwo == Hand.Paper && Player0ne == Hand.Rock)
                return Outcome.Win;
            else if (PlayerTwo == Hand.Scissors && Player0ne == Hand.Rock)
                return Outcome.Lose;
            else if (PlayerTwo == Hand.Rock && Player0ne == Hand.Paper)
                return Outcome.Lose;
            else if (PlayerTwo == Hand.Paper && Player0ne == Hand.Scissors)
                return Outcome.Lose;

            return Outcome.Tie;
        }
        private bool validateSelection()
        {
            char value = Char.ToUpper(UserSelection);
            if (value != 'R' && value != 'P' && value != 'S')
                return false;
            return true;
        }
        private void Screen()
        {
            Console.WriteLine("R - Rock");
            Console.WriteLine("P - Paper");
            Console.WriteLine("S - Scissors");
            Console.WriteLine("Please make your selection : ");

        }
    }
}

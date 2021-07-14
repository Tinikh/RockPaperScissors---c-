using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new RPSGame();
            char response;
            Console.WriteLine("Would you like to play a game of rock, paper,scissors(y or n) ?");
            response = Convert.ToChar(Console.ReadLine());

            while(player.validateResponse(response)==false)
            {
                Console.WriteLine("Invalid Input , Plasce re-enter your selection ");
                response = Convert.ToChar(Console.ReadLine());
            }
            if(response=='Y'||response=='y')
            {
                Console.Clear();
                player.PlayGame();
            }
            Console.WriteLine("Good bye");
            Console.ReadLine();
        }
    }
}

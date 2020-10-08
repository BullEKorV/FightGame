using System;
using System.Linq;

namespace Fight
{
    class Program
    {
        static Random rnd = new Random();
        static int p1Health;
        static int p2Health;
        static bool endApp = false;
        static bool gameActive = true;

        public static void Main(string[] args)
        {
            while (!endApp)
            {
                p1Health = 50;
                p2Health = 50;
                while (gameActive)
                {
                    //player 1
                    int damage = attack();
                    p1Health -= damage;
                    Console.WriteLine($"Player 1 lost {damage} health");
                    Console.WriteLine($"Player 1 health: {p1Health}");
                    checkLose();
                    Console.ReadKey();

                    //player 2
                    damage = attack();
                    p2Health -= damage;
                    Console.WriteLine($"Player 2 lost {damage} health");
                    Console.WriteLine($"Player 2 health: {p2Health}");
                    checkLose();
                    Console.ReadKey();
                }
            }
        }
        static int attack()
        {
            int damage = rnd.Next(1, 10);
            return damage;
        }

        static bool checkHealth(int x)
        {
            if (x <= 0)
            {
                return true;
            }
            else return false;
        }
        static void checkLose()
        {
            if (checkHealth(p1Health) || checkHealth(p2Health))
            {
                if (checkHealth(p1Health) && checkHealth(p2Health)) Console.WriteLine("Both lost");
                else if (checkHealth(p1Health)) Console.WriteLine("Player 1 lost");
                else if (checkHealth(p2Health)) Console.WriteLine("Player 2 lost");
                Console.WriteLine("Do you want to play again? Y/N?");
                string response = Console.ReadLine().ToLower();
                while (!(response == "y" && response == "n"))
                {
                    Console.WriteLine("Please enter Y/N");
                    response = Console.ReadLine().ToLower();
                }
                if (response == "n") endApp = true;
            }
        }
    }
}
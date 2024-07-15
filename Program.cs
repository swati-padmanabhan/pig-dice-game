using System;

namespace PigDiceGame
{
    internal class Program
    {
        const int WinningScore = 20; // Score needed to win the game
        const int MinDiceValue = 1;  // Minimum value of dice
        const int MaxDiceValue = 6;  // Maximum value of dice

        int overallScore = 0;        // Initial score of the player
        int currentTurn = 1;         // Current turn
        Random dice = new Random();  // Random number generator for dice

        public static void Main(string[] args)
        {
            Program game = new Program();  // Create an instance of the program
            game.PlayGame();  // Call the PlayGame method on the instance to start the game

            Console.ReadLine();
        }

        public void PlayGame()
        {
            Console.WriteLine("\nWelcome to the Pig Dice Game!");

            // This loop continues until the user reaches the Winning Score
            while (overallScore < WinningScore)
            {
                HandlePlayerTurn();
                currentTurn++; // Increment the turn value after each turn
            }

            // This line will now execute after the loop exits
            Console.WriteLine($"You Win! You finished in {currentTurn - 1} turns!");
            Console.WriteLine("Game ends!");
        }

        public void HandlePlayerTurn()
        {
            int turnPoints = 0;     // Initially the accumulated points would be set to zero
            bool isTurnOver = false;

            Console.WriteLine("\n===============================================================");
            Console.WriteLine($"\nTurn No. {currentTurn}:");

            while (!isTurnOver)
            {
                Console.WriteLine("Enter 'r' to roll again, 'h' to hold.");
                string inputChoice = Console.ReadLine();

                if (inputChoice == "r")
                {
                    int diceRoll = RollDice();
                    Console.WriteLine($"You rolled: {diceRoll}");

                    if (diceRoll == MinDiceValue)
                    {
                        // If the player rolls a 1, end the turn with no score
                        Console.WriteLine("Turn over. No Score");
                        isTurnOver = true;
                    }
                    else
                    {
                        // Add the dice roll to the turn score
                        turnPoints += diceRoll;
                        Console.WriteLine($"Your turn score is {turnPoints} and your total score is {overallScore}");
                        Console.WriteLine($"If you hold, you will have {overallScore + turnPoints} points.");
                    }
                }
                else if (inputChoice == "h")
                {
                    // If the player chooses h, add the turn score to the overall score
                    overallScore += turnPoints;
                    Console.WriteLine($"Your turn score is {turnPoints} and your total score is {overallScore}");
                    isTurnOver = true;
                }
                else
                {
                    Console.WriteLine("Wrong input. Please enter 'r' to roll or 'h' to hold.");
                }
            }
        }

        public int RollDice()
        {
            // Generate a random number
            return dice.Next(MinDiceValue, MaxDiceValue + 1);
        }
    }
}

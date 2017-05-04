using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        public static void Main(string[] args)
        {
            string passwrdChar1 = "";//For replacing the secret number with special character-Player1
            string passwrdChar2 = "";//For replacing the secret number with special character-Player2
            int playerOneSecretNumber;//For storing the secret number -Player1
            int playerTwoSecretNumber;//For storing the secret number -Player2
            int playerOneGuess;//For storing the guess number -Player1
            int playerTwoGuess;//For storing the guess number -Player2
            int playerOneAmt;//For storing the bet amount -Player1
            int playerTwoAmt;//For storing the bet amount -Player2
            int p1 = 0;//Flagging the total guess for player1
            int p2 = 0;//Flagging the total guess for player2
            int guessRemain = 5;//Counting down the remaining guesses for players
            double totalAmt;//For calculating the total amount
            double houseAmt = 0;//For calculating the house amount

            Console.WriteLine("\n\t\t\tWELCOME TO GUESSINO");
            Console.ReadKey();
            Console.WriteLine("\n\bRules of the game\n------------------\n1. Both players input their secret number which can be from (0-9)" +
                "\n2. Both players should enter individual bet money." +
                "\n3. Players get alternate chances with maximum 5 attempts to guess opponent's secret number." +
                "\n4. The first player to guess the opponents secret number wins!!!." +
                "\n5. 10% of total bet money will be deducted on each attempt." +
                "\n6. The company will get the bet money if both players fail\n");
            Console.ReadKey();
            Console.WriteLine("\t\t\tLet's start the game!!\n");
            Console.ReadKey();
            Console.WriteLine("Player One - Enter your secret number (0-9)");
            ConsoleKeyInfo playerOneKey = Console.ReadKey(true);
            //Encode the secret number
            passwrdChar1 += playerOneKey.KeyChar;
            Console.Write("*");

            playerOneSecretNumber = Convert.ToInt32(passwrdChar1.ToString());
            Console.WriteLine("\nPlayer One - Place your bet money:");
            playerOneAmt = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nPlayer Two - Enter your secret number (0-9)");
            ConsoleKeyInfo playerTwoKey = Console.ReadKey(true);
            //Encode the secret number
            passwrdChar2 += playerTwoKey.KeyChar;
            Console.Write("*");

            playerTwoSecretNumber = Convert.ToInt32(passwrdChar2.ToString());
            Console.WriteLine("\nPlayer Two - Place your bet money:");
            playerTwoAmt = Convert.ToInt32(Console.ReadLine());
            totalAmt = playerTwoAmt + playerOneAmt;
            Console.WriteLine("\n\n\t\t\tGet into your intuition mode!!!");
            //Only 5 attempts
            for (int count = 0; count < 5; count++)
            {
                guessRemain = guessRemain - 1;//counting down the remaining guesses
                Console.WriteLine("\nPlayer One Guess: ");
                playerOneKey = Console.ReadKey(true);
                playerOneGuess = Convert.ToInt32(playerOneKey.KeyChar.ToString());
                //if player one guess and player two's secret number matches
                if (playerOneGuess == playerTwoSecretNumber)
                {
                    switch (count)
                    {
                        case 1://if the guess is correct in the 2nd attempt, he will get 90% of the amount
                            totalAmt = Math.Round(((totalAmt * 90) / 100));//calculation
                            houseAmt = Math.Round(((totalAmt * 10) / 100));
                            break;
                        case 2://if the guess is correct in the 3rd attempt, he will get 80% of the amount
                            totalAmt = Math.Round(((totalAmt * 80) / 100));
                            houseAmt = Math.Round(((totalAmt * 20) / 100));
                            break;
                        case 3://if the guess is correct in the 4thd attempt, he will get 70% of the amount
                            totalAmt = Math.Round(((totalAmt * 70) / 100));
                            houseAmt = Math.Round(((totalAmt * 30) / 100));
                            break;
                        case 4://if the guess is correct in the 5th attempt, he will get 60% of the amount
                            totalAmt = Math.Round(((totalAmt * 60) / 100));
                            houseAmt = Math.Round(((totalAmt * 40) / 100));
                            break;
                    }
                    Console.WriteLine("\nNumber " + playerTwoSecretNumber + " is the Correct Guess!!! Player 1 WINS!!! And will get $" + totalAmt
                                                   + "\nHouse gets $" + houseAmt);
                    break;
                }
                else
                {
                    Console.WriteLine("\n\t" + playerOneGuess + " is the Wrong Guess!!! Better luck next time.\n\tAttempts remaining: " + guessRemain);
                    if (count == 4)//if it is a last guess , then flag
                        p1 = 1;
                }

                Console.WriteLine("\nPlayer Two Guess: ");
                playerTwoKey = Console.ReadKey(true);
                playerTwoGuess = Convert.ToInt32(playerTwoKey.KeyChar.ToString());
                if (playerTwoGuess == playerOneSecretNumber)
                {
                    switch (count)
                    {
                        case 1://if the guess is correct in the 2nd attempt, he will get 90% of the amount
                            totalAmt = Math.Round(((totalAmt * 90) / 100));//calculation
                            houseAmt = Math.Round(((totalAmt * 10) / 100));
                            break;
                        case 2://if the guess is correct in the 3rd attempt, he will get 80% of the amount
                            totalAmt = Math.Round(((totalAmt * 80) / 100));
                            houseAmt = Math.Round(((totalAmt * 20) / 100));
                            break;
                        case 3://if the guess is correct in the 4thd attempt, he will get 70% of the amount
                            totalAmt = Math.Round(((totalAmt * 70) / 100));
                            houseAmt = Math.Round(((totalAmt * 30) / 100));
                            break;
                        case 4://if the guess is correct in the 5th attempt, he will get 60% of the amount
                            totalAmt = Math.Round(((totalAmt * 60) / 100));
                            houseAmt = Math.Round(((totalAmt * 40) / 100));
                            break;
                    }
                    Console.WriteLine("\nNumber " + playerOneSecretNumber + " is the Correct Guess!!! Player 2 WINS!!! And will get $" + totalAmt
                                                   + "\nHouse gets $" + houseAmt);
                    break;
                }
                else
                {
                    Console.WriteLine("\n\t" + playerTwoGuess + " is the Wrong Guess!!! Better luck next time.\n\tAttempts remaining: " + guessRemain);
                    if (count == 4)//if it is a last guess , then flag
                        p2 = 1;
                }
            }
            if (p1 == 1 && p2 == 1)
            {
                Console.WriteLine("\n Both players lose, So bet money of $" + totalAmt + " goes to the house.");
                Console.WriteLine("\n Player One Secret Number was " + playerOneSecretNumber);
                Console.WriteLine("\n Player Two Secret Number was " + playerTwoSecretNumber);
            }

            Console.ReadKey();
        }
    }
}

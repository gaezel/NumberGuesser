﻿using System;

namespace NumberGuesser {
    class Program {
        static void Main(string[] args) {
            //string myString = string.Format("Phone: {0:(###) ###-####}", 1234567890);
            GetAppInfo();
            GreetUser();
            int score = 0; ;
            while (true) {
                Random random = new Random();
                int correctNumber = random.Next(1, 10);
                int guess = 0;
                int life = 3;

                PrintColorMessage(ConsoleColor.Yellow, "Score: " + score);

                while (guess != correctNumber) {
                    Console.WriteLine("Guess a number: 1 - 10");
                    string inputNum = Console.ReadLine();

                    if (!int.TryParse(inputNum, out guess)) {
                        PrintColorMessage(ConsoleColor.Red, "Wrong answer! Make sure you have a valid number (Hint: 1 - 10) ");
                        life--;
                        continue;
                    }
                    guess = Int32.Parse(inputNum);

                    if (guess != correctNumber) {
                        life--;
                        if(life == 0) {
                            PrintColorMessage(ConsoleColor.Red, "Sorry, you lose this round.");
                            break;
                        }
                        PrintColorMessage(ConsoleColor.Red, "Wrong number. Try again.");                    
                    }
                }
                if(guess == correctNumber) {
                    PrintColorMessage(ConsoleColor.Yellow, "Congratulations. You are correct!");
                    score++;
                }
                

                Console.WriteLine("Play again? [Y/N]");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y") {
                    continue;
                }
                else if(answer == "N") {
                    PrintColorMessage(ConsoleColor.Yellow, String.Format("Score: {0} \nThanks for playing.", score));
                    Console.ReadLine();
                    return;
                }
                
            }
            
        }
        static void GetAppInfo() {
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Gaezel";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);
            Console.ResetColor();
        }
        static void GreetUser() {
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello {0}, let's play a game", userName);
        }

        static void PrintColorMessage(ConsoleColor color, string message) {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

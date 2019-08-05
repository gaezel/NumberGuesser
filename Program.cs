using System;

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
                PrintColorMessage(ConsoleColor.Yellow, "Score: " + score);

                while (guess != correctNumber) {
                    Console.WriteLine("Guess a number between 1 and 10");
                    string inputNum = Console.ReadLine();

                    if (!int.TryParse(inputNum, out guess)) {
                        PrintColorMessage(ConsoleColor.Red, "This is not a number...");
                        continue;
                    }
                    guess = Int32.Parse(inputNum);

                    if (guess != correctNumber) {
                        PrintColorMessage(ConsoleColor.Red, "Wrong number. Try again.");                    
                    }
                }
                PrintColorMessage(ConsoleColor.Yellow, "Congratulations. You are correct!");
                score++;

                Console.WriteLine("Play again? [Y/N]");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y") {
                    continue;
                }
                else if(answer == "N") {
                    PrintColorMessage(ConsoleColor.Yellow, String.Format("Score: {0} \n Thanks for playing.", score));              
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

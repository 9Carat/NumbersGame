// Christoffer Ottestig
// NET22

namespace NumbersGame
{
    internal class Program
    {
        static int GetRandNum(int difficulty)
        {
            // Generates a random number in different intervals depending on the difficulty chosen by the user
            int number = 0;

            if (difficulty == 1)
            {
                Random random = new Random();
                number = random.Next(1, 26);
            }
            else if (difficulty == 2)
            {
                Random random = new Random();
                number = random.Next(1, 51);
            }
            else if (difficulty == 3)
            {
                Random random = new Random();
                number = random.Next(1, 151);
            }
            return number;
        }

        static void Main(string[] args)
        {
            bool keepGoing = true;

            do
            {
                // Asks the user for a number and the desired difficulty
                Console.WriteLine("Välkommen till Gissa Numret!");
                Console.WriteLine("Börja med att välja svårighetsgrad. Välj mellan 1-3. 1 = 25 tal, 2 = 50 tal, 3 = 150 tal");
                int difficulty = Int32.Parse(Console.ReadLine());

                int attempts = 1;
                int number = GetRandNum(difficulty);

                while(true)
                {
                    // Asks the user to guess the number 
                    Console.WriteLine("Jag tänker på ett nummer. Kan du gissa vilket? Du får 5 försök.");
                    int guess = Int32.Parse(Console.ReadLine());

                    // Checks whether the guess is correct, too low, too high or if the user is out of attempts
                    if (guess < number && attempts < 5)
                    {
                        // Randomizes the reply to the user if the guess is too low
                        int reply;
                        Random random = new Random();
                        reply = random.Next(1, 4);

                        switch(reply)
                        {
                            case 1:
                                Console.WriteLine("Tyvärr, du gissade för lågt!");
                                attempts++;
                                break;
                            case 2:
                                Console.WriteLine("Den gissningen var för låg!");
                                attempts++;
                                break;
                            case 3:
                                Console.WriteLine("Bra gissat men det var för lågt!");
                                attempts++;
                                break;
                        }

                        // Checks if the guess is no more than 5 numbers above the correct number
                        if (guess >= number - 5)
                        {
                            Console.WriteLine("Det börjar brännas!");
                        }
                    }
                    else if (guess > number && attempts < 5)
                    {
                        // Randomizes the reply to the user if the guess is too high
                        int reply;
                        Random random = new Random();
                        reply = random.Next(1, 4);

                        switch (reply)
                        {
                            case 1:
                                Console.WriteLine("Tyvärr, du gissade för högt!");
                                attempts++;
                                break;
                            case 2:
                                Console.WriteLine("Nej, den gissningen var för hög!");
                                attempts++;
                                break;
                            case 3:
                                Console.WriteLine("Haha bra gissat men det var för högt!");
                                attempts++;
                                break;
                        }

                        // Checks if the guess is no more than 5 numbers below the correct number
                        if (guess <= number + 5)
                        {
                            Console.WriteLine("Det börjar brännas!");
                        }
                    }
                    else if (guess != number && attempts == 5)
                    {
                        Console.WriteLine("Tyvärr du lyckades inte gissa talet på fem försök!");
                        Console.WriteLine("Talet jag tänkte på var: " + number);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Woho! Du gjorde det!");
                        break;
                    }
                }

                // Asks the user if they would like to play again and breaks the loop if they chooose not to
                Console.WriteLine("Vill du spela igen? (ja/nej)");
                string answer = Console.ReadLine();

                if (answer == "nej")
                {
                    keepGoing = false;
                }

            } while (keepGoing == true);

            // Says goodbye to the user 
            Console.WriteLine("Välkommen åter!");
        }
    }
}
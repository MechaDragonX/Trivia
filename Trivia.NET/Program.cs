using System;
using System.Collections.Generic;

namespace Trivia.NET
{
    class Program
    {
        private static readonly Dictionary<string, List<string>> questions = new Dictionary<string, List<string>>()
        {
            {
                "What is the meaning of life?",
                new List<string>(new string[]{ "to live", "live", "living", "to keep living" })
            },
            {
                "Which number in the national Pokédex is Pikachu?",
                new List<string>(new string[]{ "25" })
            },
            {
                "True or False: Is \"Dragon Ball\" considered a \"shoujo\" (girl's) manga?",
                new List<string>(new string[]{ "false", "f" })
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the quiz program! Press any \"enter\" to continue!");
            Console.ReadLine();

            int count = 0;
            int score = 0;
            string input;
            foreach(KeyValuePair<string, List<string>> item in questions)
            {
                count++;
                Console.WriteLine($"Question { count }:\n{ item.Key }");

                Console.ForegroundColor = ConsoleColor.Cyan;
                input = Console.ReadLine();
                Console.ResetColor();

                if(item.Value.Contains(input))
                {
                    score++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nice job! That's the right answer!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oh no! That was the wrong answer!");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.WriteLine($"The game is over! You got { score }/{ count } questions right!");

            if(score == questions.Count)
                Console.WriteLine("You got a perfect score!");
            else if(score > (questions.Count / 2))
                Console.WriteLine("You did very well!");
            else if(score == (questions.Count / 2))
                Console.WriteLine("You got half the questions right!");
            else if(score < (questions.Count / 2) && score != 0)
                Console.WriteLine("You got less than half the questions right...try again next time!");
            else
                Console.WriteLine("Try again next time!");
        }
    }
}

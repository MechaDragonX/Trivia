using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trivia.NET.GameEnvironment;
using Trivia.NET.QuizQuestion;

namespace Trivia.NET
{
    class Program
    {
        private static readonly Dictionary<string, string[]> questions = new Dictionary<string, string[]>()
        {
            {
                "What is the meaning of life?",
                new string[]{ "to live", "live", "living", "to keep living" }
            },
            {
                "Which number in the national Pokédex is Pikachu?",
                new string[]{ "25" }
            },
            {
                "True or False: Is \"Dragon Ball\" considered a \"shoujo\" (girl's) manga?",
                new string[]{ "false", "f" }
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the quiz program! Press any \"enter\" to continue!");
            Console.ReadLine();

            string input;
            Task<Question[]> questionsTask;
            Game game;
            Console.WriteLine("Please write the path to your question/answer \"*.txt\" file");
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                input = Console.ReadLine();
                try
                {
                    questionsTask = QuestionImporter.ImportFromFile(input);
                    Task.WaitAll(questionsTask);
                    break;
                }
                catch(Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: { e.InnerException.Message }");
                    Console.ResetColor();
                }
            }
            Console.ResetColor();
            Console.WriteLine();

            game = new Game(questionsTask.Result);
            game.Execute();
            Console.WriteLine("Thanks for playing!\nPress any key to exit.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using Trivia.NET.GameEnvironment;

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

            //Game game = new Game(QuestionImporter.ImportAllShortAnswer(questions));
            //game.Execute();

            Game game = new Game(QuestionImporter.ImportFromConsole());
            game.Execute();
        }
    }
}

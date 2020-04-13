using System;
using System.Collections.Generic;
using System.IO;
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

            DirectoryInfo currentDir = Directory.CreateDirectory(Environment.CurrentDirectory);
            Question[] questions = null;
            foreach (FileInfo file in currentDir.GetFiles())
            {
                if(file.Extension == ".txt")
                {
                    questions = QuestionImporter.ImportFromFile(file.FullName).Result;
                    break;
                }
            }
            if(questions == null)
                questions = ManualStart();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File successfully read!");
            Console.ResetColor();
            Console.WriteLine();

            Game game = new Game(questions);
            game.Execute();
            Console.WriteLine("Thanks for playing!\nPress any key to exit.");
            Console.ResetColor();
            Console.ReadKey();
        }

        private static Question[] ManualStart()
        {
            string input;
            Task<Question[]> task;
            Console.WriteLine("Please write the path to your question/answer \"*.txt\" file");
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                input = Console.ReadLine();
                task = TryReadFile(input);
                if(task.Status != TaskStatus.Faulted)
                    return task.Result;
            }
        }
        private static Task<Question[]> TryReadFile(string path)
        {
            Task<Question[]> questionsTask = null;
            try
            {
                questionsTask = QuestionImporter.ImportFromFile(path);
                Task.WaitAll(questionsTask);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: { e.InnerException.Message }");
                Console.ResetColor();
            }
            return questionsTask;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Trivia.NET.QuizQuestion;

namespace Trivia.NET.GameEnvironment
{
    public class Game
    {
        public Question[] Questions { get; set; }
        public int Score { get; set; }

        public Game(Question[] questions)
        {
            Questions = questions;
        }

        private void DisplayQuestion(Question current)
        {
            Console.WriteLine($"Question { Array.IndexOf(Questions, current) + 1 }:\n{ current.DisplayQuestion() }");
            if (current.Type == QuestionType.MultipleChoice)
                current.DisplayAnswers();
        }
        private void CheckAnswer(Question current, string input)
        {
            if(current.CheckAnswer(input))
            {
                Score++;
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
        private void Scoring()
        {
            Console.WriteLine($"The game is over! You got { Score }/{ Questions.Length } questions right!");

            if (Score == Questions.Length)
                Console.WriteLine("You got a perfect score!");
            else if (Score > (Questions.Length / 2))
                Console.WriteLine("You did very well!");
            else if (Score == (Questions.Length / 2))
                Console.WriteLine("You got half the questions right!");
            else if (Score < (Questions.Length / 2) && Score != 0)
                Console.WriteLine("You got less than half the questions right...try again next time!");
            else
                Console.WriteLine("Try again next time!");
        }
        private string GetInput(string input)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }
        
        public void Execute()
        {
            string input = "";
            foreach(Question item in Questions)
            {
                DisplayQuestion(item);
                input = GetInput(input);
                CheckAnswer(item, input);
            }
            Scoring();
        }
    }
}

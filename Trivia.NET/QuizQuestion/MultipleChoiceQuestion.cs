using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.NET.QuizQuestion
{
    public class MultipleChoiceQuestion : Question
    {
        public MultipleChoiceQuestion(string query)
        {
            Type = QuestionType.MultipleChoice;
            Query = query;
            Answer = "";
        }
        public MultipleChoiceQuestion(string query, string[] answers) : this(query)
        {
            Answers = answers;
        }

        public override void DisplayAnswers()
        {
            int letter = 64; // ASCI @
            foreach(string item in Answers)
            {
                letter++;
                Console.WriteLine($"{ (char)letter }: { item }");
            }
            Console.WriteLine();
        }
    }
}

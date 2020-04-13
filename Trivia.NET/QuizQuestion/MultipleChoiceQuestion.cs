using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia.NET.QuizQuestion
{
    public class MultipleChoiceQuestion : Question
    {
        public string Correct { get; set; }

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
        }
        public void GetCorrectAnswer(string input)
        {
            List<string> newAnswers = Answers.ToList();
            newAnswers.RemoveAt(Answers.Length - 1);
            Answers = newAnswers.ToArray();

            Correct = Answers[input.ToUpper()[0] - '@' - 1];
        }
        public override bool CheckAnswer(string input)
        {
            return base.CheckAnswer(Answers[input.ToUpper()[0] - '@' - 1]);
        }
    }
}

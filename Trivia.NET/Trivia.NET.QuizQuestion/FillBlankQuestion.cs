using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.NET.QuizQuestion
{
    public class FillBlankQuestion : Question
    {
        public FillBlankQuestion(string query)
        {
            Type = QuestionType.FillBlank;
            Query = query;
        }
        public FillBlankQuestion(string query, string answer) : this(query)
        {
            Answer = answer;
        }
        public FillBlankQuestion(string query, string[] answers, string answer = "") : this(query, answer)
        {
            Answers = answers;
        }
    }
}

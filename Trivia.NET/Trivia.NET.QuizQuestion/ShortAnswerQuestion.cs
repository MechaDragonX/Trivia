using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.NET.QuizQuestion
{
    public class ShortAnswerQuestion : Question
    {
        public ShortAnswerQuestion(string query)
        {
            Type = QuestionType.ShortAnswer;
            Query = query;
        }
        public ShortAnswerQuestion(string query, string answer) : this(query)
        {
            Answer = answer;
        }
        public ShortAnswerQuestion(string query, string[] answers, string answer = "") : this(query, answer)
        {
            Answers = answers;
        }
    }
}

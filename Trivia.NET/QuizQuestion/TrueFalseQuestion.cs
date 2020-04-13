using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.NET.QuizQuestion
{
    public class TrueFalseQuestion : Question
    {
        public new bool Answer { get; set; }

        public TrueFalseQuestion(string query)
        {
            Type = QuestionType.TrueFalse;
            Query = query;
        }
        public TrueFalseQuestion(string query, bool answer) : this(query)
        {
            Answer = answer;
        }

        public override string DisplayQuestion()
        {
            return string.Format($"True or False: { Query }");
        }
        public override bool CheckAnswer(string input)
        {
            if ((input == "true" || input == "t") && Answer)
                return true;
            else if ((input == "false" || input == "f") && !Answer)
                return true;
            
            return false;
        }
    }
}

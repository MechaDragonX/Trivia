using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.NET.QuizQuestion
{
    public class Question
    {
        public QuestionType Type { get; set; }
        public string Query { get; set; }
        public string Answer { get; set; }
        public string[] Answers { get; set; }

        public Question() { }
        public Question(QuestionType type, string query)
        {
            Type = type;
            Query = query;
        }
        public Question(QuestionType type, string query, string answer) : this(type, query)
        {
            Answer = answer;
        }
        public Question(QuestionType type, string query, string[] answers, string answer = "") : this(type, query, answer)
        {
            Answers = answers;
        }

        public virtual string DisplayQuestion()
        {
            return Query;
        }
        public virtual void DisplayAnswers() { }
        public bool CheckAnswer(string input)
        {
            if(Answer != "")
                return input == Answer;

            foreach(string item in Answers)
            {
                if(input == item)
                    return true;
            }
            return false;
        }
    }
}

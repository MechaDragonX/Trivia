using System;
using System.Collections.Generic;
using System.Text;
using Trivia.NET.QuizQuestion;

namespace Trivia.NET.GameEnvironment
{
    public class QuestionImporter
    {
        public static ShortAnswerQuestion[] ImportShortAnswer(Dictionary<string, string[]> questions)
        {
            List<ShortAnswerQuestion> imported = new List<ShortAnswerQuestion>();
            foreach(KeyValuePair<string, string[]> item in questions)
            {
                if(item.Value.Length == 1)
                    imported.Add(new ShortAnswerQuestion(item.Key, item.Value[0]));
                else
                    imported.Add(new ShortAnswerQuestion(item.Key, item.Value));
            }
            return imported.ToArray();
        }
        public static MultipleChoiceQuestion[] ImportMultipleChoice(Dictionary<string, string[]> questions)
        {
            List<MultipleChoiceQuestion> imported = new List<MultipleChoiceQuestion>();
            foreach (KeyValuePair<string, string[]> item in questions)
                imported.Add(new MultipleChoiceQuestion(item.Key, item.Value));
            return imported.ToArray();
        }
        public static TrueFalseQuestion[] ImportTrueFalse(Dictionary<string, string> questions)
        {
            List<TrueFalseQuestion> imported = new List<TrueFalseQuestion>();
            foreach(KeyValuePair<string, string> item in questions)
            {
                if(item.Value.ToLower() == "true" || item.Value.ToLower() == "t")
                    imported.Add(new TrueFalseQuestion(item.Key, true));
                else if(item.Value.ToLower() == "false" || item.Value.ToLower() == "f")
                    imported.Add(new TrueFalseQuestion(item.Key, false));
            }
            return imported.ToArray();
        }
        public static FillBlankQuestion[] ImportFillBlank(Dictionary<string, string[]> questions)
        {
            List<FillBlankQuestion> imported = new List<FillBlankQuestion>();
            foreach (KeyValuePair<string, string[]> item in questions)
            {
                if (item.Value.Length == 1)
                    imported.Add(new FillBlankQuestion(item.Key, item.Value[0]));
                else
                    imported.Add(new FillBlankQuestion(item.Key, item.Value));
            }
            return imported.ToArray();
        }
    }
}

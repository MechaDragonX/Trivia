using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Trivia.NET.QuizQuestion;

namespace Trivia.NET.GameEnvironment
{
    public class QuestionImporter
    {
        private static readonly List<string> types = new List<string>()
        {
            QuestionType.ShortAnswer.ToString().ToLower(),
            QuestionType.MultipleChoice.ToString().ToLower(),
            QuestionType.TrueFalse.ToString().ToLower(),
            QuestionType.FillBlank.ToString().ToLower()
        };

        public static async Task<Question[]> ImportFromFile(string path)
        {
            if(!File.Exists(path))
                throw new FileNotFoundException("The file was not found!");
            if(Path.GetExtension(path) != ".txt")
                throw new NotSupportedException("Only \"*.txt\" files are supported!");

            string[] data = await File.ReadAllLinesAsync(path);

            List<Question> questions = new List<Question>();
            QuestionType type = 0;
            string query = "";
            List<string> answers = new List<string>();
            bool parsing = false;
            foreach(string line in data)
            {
                if(line == "")
                {
                    parsing = false;
                    questions.Add(CreateSingleQuestion(type, query, answers.ToArray()));
                    type = 0;
                    query = "";
                    answers = new List<string>();
                }

                if(!parsing)
                {
                    if(types.Contains(Regex.Replace(line, "\\s", "").ToLower()))
                    {
                        parsing = true;
                        type = (QuestionType)types.IndexOf(Regex.Replace(line, "\\s", "").ToLower());
                    }
                }
                else
                {
                    if(query == "")
                        query = line;
                    else
                        answers.Add(line);
                }
            }

            questions.Add(CreateSingleQuestion(type, query, answers.ToArray()));
            return questions.ToArray();
        }

        public static Question CreateSingleQuestion(QuestionType type, string query, string[] answers)
        {
            switch(type)
            {
                case QuestionType.ShortAnswer:
                    if(answers.Length == 1)
                        return new ShortAnswerQuestion(query, answers[0]);
                    return new ShortAnswerQuestion(query, answers);
                case QuestionType.MultipleChoice:
                    MultipleChoiceQuestion multiple = new MultipleChoiceQuestion(query, answers);
                    multiple.GetCorrectAnswer(answers[answers.Length - 1]);
                    return multiple;
                case QuestionType.TrueFalse:
                    if(answers[0].ToLower() == "true" || answers[0].ToLower() == "t")
                        return new TrueFalseQuestion(query, true);
                    return new TrueFalseQuestion(query, false);
                case QuestionType.FillBlank:
                    if(answers.Length == 1)
                        return new FillBlankQuestion(query, answers[0]);
                    return new FillBlankQuestion(query, answers);
            }
            return null;
        }

        public static ShortAnswerQuestion[] ImportAllShortAnswer(Dictionary<string, string[]> questions)
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
        public static MultipleChoiceQuestion[] ImportAllMultipleChoice(Dictionary<string, string[]> questions)
        {
            List<MultipleChoiceQuestion> imported = new List<MultipleChoiceQuestion>();
            foreach (KeyValuePair<string, string[]> item in questions)
                imported.Add(new MultipleChoiceQuestion(item.Key, item.Value));
            return imported.ToArray();
        }
        public static TrueFalseQuestion[] ImportAllTrueFalse(Dictionary<string, string> questions)
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
        public static FillBlankQuestion[] ImportAllFillBlank(Dictionary<string, string[]> questions)
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

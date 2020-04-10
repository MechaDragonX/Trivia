using System;
using System.Collections.Generic;
using System.Text;
using Trivia.NET.QuizQuestion;

namespace Trivia.NET.GameEnvironment
{
    public class QuestionImporter
    {
        public static Question[] ImportFromConsole()
        {
            List<Question> questions = new List<Question>();
            string typeString;
            QuestionType type = 0;
            string query;
            List<string> answers;
            string currentLine;

            while(true)
            {
                Console.WriteLine("Please the type of your question");
                typeString = Console.ReadLine();
                if(typeString.ToLower() == QuestionType.ShortAnswer.ToString().ToLower())
                    type = QuestionType.ShortAnswer;
                else if(typeString.ToLower() == QuestionType.MultipleChoice.ToString().ToLower())
                    type = QuestionType.MultipleChoice;
                else if(typeString.ToLower() == QuestionType.TrueFalse.ToString().ToLower())
                    type = QuestionType.TrueFalse;
                else if(typeString.ToLower() == QuestionType.FillBlank.ToString().ToLower())
                    type = QuestionType.FillBlank;

                Console.WriteLine("Please the type the name of your question:");
                query = Console.ReadLine();
                if(query.ToLower() == "exit")
                    break;

                Console.WriteLine("Please the type your answers. Press \"enter\" to move onto the next question.");
                if (type == QuestionType.MultipleChoice)
                    Console.WriteLine("There\'s no need to put letters.");
                answers = new List<string>();
                while(true)
                {
                    currentLine = Console.ReadLine();

                    if(currentLine.ToLower() == "" && answers.Count == 0)
                        Console.WriteLine("You have to have at least one answer!");
                    else if(currentLine.ToLower() == "" && answers.Count != 0)
                    {
                        questions.Add(CreateSingleQuestion(type, query, answers.ToArray()));
                        break;
                    }

                    answers.Add(currentLine);
                }

            }

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
                    return new MultipleChoiceQuestion(query, answers);
                case QuestionType.TrueFalse:
                    if(answers[0].ToLower() == "true" || answers[0].ToLower() == "t")
                        return new TrueFalseQuestion(query, true);
                    return new TrueFalseQuestion(query, false);
                case QuestionType.FillBlank:
                    if (answers.Length == 1)
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

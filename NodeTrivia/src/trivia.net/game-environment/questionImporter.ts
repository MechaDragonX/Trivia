namespace GameEnvironment {
    export class QuestionImporter {
        types: string[] = [
            QuizQuestion.QuestionType.ShortAnswer.toString().toLowerCase(),
            QuizQuestion.QuestionType.MultipleChoice.toString().toLowerCase(),
            QuizQuestion.QuestionType.TrueFalse.toString().toLowerCase(),
            QuizQuestion.QuestionType.FillBlank.toString().toLowerCase()
        ];

        createSingleQuestion(type: QuizQuestion.QuestionType, query: string, answers: string[]): QuizQuestion.Question {
            switch(type)
            {
                case QuizQuestion.QuestionType.ShortAnswer:
                    if(answers.length == 1)
                        return new QuizQuestion.ShortAnswerQuestion(query, [ answers[0] ]);
                    return new QuizQuestion.ShortAnswerQuestion(query, answers);
                case QuizQuestion.QuestionType.MultipleChoice:
                    let multiple: QuizQuestion.MultipleChoiceQuestion = new QuizQuestion.MultipleChoiceQuestion(query, answers);
                    multiple.getCorrectAnswer(answers[answers.length - 1]);
                    return multiple;
                case QuizQuestion.QuestionType.TrueFalse:
                    if(answers[0].toLowerCase() == "true" || answers[0].toLowerCase() == "t")
                        return new QuizQuestion.TrueFalseQuestion(query, true);
                    return new QuizQuestion.TrueFalseQuestion(query, false);
                case QuizQuestion.QuestionType.FillBlank:
                    if(answers.length == 1)
                        return new QuizQuestion.FillBlankQuestion(query, [ answers[0] ]);
                    return new QuizQuestion.FillBlankQuestion(query, answers);
            }
        }
    }
}

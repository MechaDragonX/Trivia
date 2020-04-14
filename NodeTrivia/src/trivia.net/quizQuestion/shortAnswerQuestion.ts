namespace QuizQuestion {
    export class ShortAnswerQuestion extends Question {
        constructor(query: string, answers: string[]) {
            super(QuestionType.ShortAnswer, query, answers);
        }
    }
}

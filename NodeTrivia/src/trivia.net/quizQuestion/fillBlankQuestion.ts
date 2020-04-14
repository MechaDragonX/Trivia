namespace QuizQuestion {
    export class FillBlankQuestion extends Question {
        constructor(query: string, answers: string[]) {
            super(QuestionType.FillBlank, query, answers);
        }
    }
}

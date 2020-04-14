namespace QuizQuestion {
    export class FillBlankQuestion extends Question {
        super(query: string, answers: string[]) {
            this.type = QuestionType.FillBlank;
            this.query = query;
            this.answers = answers;
        }
    }
}

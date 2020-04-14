namespace QuizQuestion {
    export class ShortAnswerQuestion extends Question {
        super(query: string, answers: string[]) {
            this.type = QuestionType.ShortAnswer;
            this.query = query;
            this.answers = answers;
        }
    }
}

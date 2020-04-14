namespace QuizQuestion {
    export class TrueFalseQuestion extends Question {
        super(query: string, answers: string[]) {
            this.type = QuestionType.TrueFalse;
            this.query = query;
            this.answers = answers;
        }

        displayQuestion(): string
        {
            return `True or False: ${ this.query }`;
        }
        checkAnswer(input: string): boolean
        {
            if((input == "true" || input == "t") && this.answer)
                return true;
            else if((input == "false" || input == "f") && !this.answer)
                return true;
            
            return false;
        }
    }
}

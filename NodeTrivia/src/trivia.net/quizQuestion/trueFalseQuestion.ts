namespace QuizQuestion {
    export class TrueFalseQuestion extends Question {
        constructor(query: string, answer: boolean) {
            super(QuestionType.TrueFalse, query, null);
            this.answer = answer;
        }

        displayQuestion(): string
        {
            return `True or False: ${ this.query }`;
        }
        checkAnswer(input: string): boolean
        {
            if((input === "true" || input === "t") && this.answer)
                return true;
            else if((input === "false" || input === "f") && !this.answer)
                return true;
            
            return false;
        }
    }
}

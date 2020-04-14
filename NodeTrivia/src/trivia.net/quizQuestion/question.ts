namespace QuizQuestion {
    export class Question {
        type: QuestionType;
        query: string;
        answer: any;
        answers: string[];

        constructor(type: QuestionType, query: string, answers: string[]) {
            this.type = type;
            this.query = query;
            this.answers = answers;
        }

        displayQuestion(): string {
            return this.query;
        }
        displayAnswers(): any { }
        checkAnswer(input: string): boolean
        {
            if(this.answer != "")
                return input === this.answer;

            this.answers.forEach(function(item: string) {
                if(input === item)
	                return true;
            });
            return false;
        }
    }
}

namespace QuizQuestion {
    export class MultipleChoiceQuestion extends Question {
        correct: string;

        constructor(query: string, answers: string[]) {
            super(QuestionType.MultipleChoice, query, answers);
        }

        displayAnswers(): any {
            let letter: number = 64; // @ in ASCII
            let display: string;
            this.answers.forEach(function(item: string) {
                letter++;
                display = `${ String.fromCharCode(letter) }: ${ item }`;
            });
            return display;
        }

        getCorrectAnswer(input: string): void
        {
            let newAnswers: string[] = this.answers;
            newAnswers.splice(this.answers.length - 1);
            this.answers = newAnswers;

            this.correct = this.answers[input.toUpperCase().charAt(0).charCodeAt(0) - 93];
        }
        checkAnswer(input: string): boolean
        {
            return super.checkAnswer(this.answers[input.toUpperCase().charAt(0).charCodeAt(0) - 93]);
        }
    }
}

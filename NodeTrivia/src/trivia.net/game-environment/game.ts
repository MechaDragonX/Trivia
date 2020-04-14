

namespace GameEnvironment {
    export class Game {
        questions: QuizQuestion.Question[];
        score: number;

        construct(questions: QuizQuestion.Question[])
        {
            this.questions = questions;
        }

        displayQuestion(current: QuizQuestion.Question): string
        {
            let display: string = "";

            display.concat(`Question ${ this.questions.indexOf(current) + 1 }:\n${ current.displayQuestion() }\n`);
            if(current.type == QuizQuestion.QuestionType.MultipleChoice)
                display.concat(current.displayAnswers());
            
            return display;
        }
        checkAnswer(current: QuizQuestion.Question, input: string): boolean
        {
            if(current.checkAnswer(input))
            {
                this.score++;
                return true;
            }
            else
                return false;
        }
        scoring(): string
        {
            let results: string;
            results.concat(`The game is over! You got ${ this.score }/${ this.questions.length } questions right!\n`);

            if(this.score == this.questions.length)
                results.concat("You got a perfect score!");
            else if(this.score > (this.questions.length / 2))
                results.concat("You did very well!");
            else if(this.score == (this.questions.length / 2))
                results.concat("You got half the questions right!");
            else if(this.score < (this.questions.length / 2) && this.score != 0)
                results.concat("You got less than half the questions right...try again next time!");
            else
                results.concat("Try again next time!");

            return results;
        }
    }
}

import { QuestionType } from './questionType';
import { Question } from './question';

export class ShortAnswerQuestion extends Question {
    constructor(query: string, answers: string[]) {
        super(QuestionType.ShortAnswer, query, answers);
    }
}

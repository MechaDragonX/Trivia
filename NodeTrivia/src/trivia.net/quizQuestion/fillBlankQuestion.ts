import { QuestionType } from './questionType';
import { Question } from './question';

export class FillBlankQuestion extends Question {
    constructor(query: string, answers: string[]) {
        super(QuestionType.FillBlank, query, answers);
    }
}

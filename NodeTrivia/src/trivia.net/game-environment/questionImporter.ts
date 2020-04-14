import { QuestionType } from './../quizQuestion/questionType';
import { Question } from './../quizQuestion/question';
import { ShortAnswerQuestion } from './../quizQuestion/shortAnswerQuestion';
import { MultipleChoiceQuestion } from './../quizQuestion/multipleChoiceQuestion';
import { TrueFalseQuestion } from './../quizQuestion/trueFalseQuestion';
import { FillBlankQuestion } from './../quizQuestion/fillBlankQuestion';

export class QuestionImporter {
    types: string[] = [
        QuestionType.ShortAnswer.toString().toLowerCase(),
        QuestionType.MultipleChoice.toString().toLowerCase(),
        QuestionType.TrueFalse.toString().toLowerCase(),
        QuestionType.FillBlank.toString().toLowerCase()
    ];

    async listLine(reader: any, file: any): Promise<any> {
        let imported: any = null;
        reader.loadFile(file)
        .then(function(res) {
            imported = res.result;
        })
        .catch(function(res) {
            throw new Error('File load failed!');
        });

        let data: any = new Array<string>();
        reader.getLines(1, 100000)
        .then(function(res) {
            data = res.result;
        })
        .catch(function(res) {
            throw new Error('Obtaining lines from file failed!');
        });

        return data;
    }
    async importFromFile(reader: any, file: any): Promise<Question[]> {
        let imported: any = null;
        reader.loadFile(file)
        .then(function(res) {
            imported = res.result;
        })
        .catch(function(res) {
            throw new Error('File load failed!');
        });

        let data: any = new Array<string>();
        reader.getLines(1, 100000)
        .then(function(res) {
            data = res.result;
        })
        .catch(function(res) {
            throw new Error('Obtaining lines from file failed!');
        });

        return this.createQuestions(data);
    }
    createSingleQuestion(type: QuestionType, query: string, answers: string[]): Question {
        switch(type)
        {
            case QuestionType.ShortAnswer:
                if(answers.length === 1)
                    return new ShortAnswerQuestion(query, [ answers[0] ]);
                return new ShortAnswerQuestion(query, answers);
            case QuestionType.MultipleChoice:
                let multiple: MultipleChoiceQuestion = new MultipleChoiceQuestion(query, answers);
                multiple.getCorrectAnswer(answers[answers.length - 1]);
                return multiple;
            case QuestionType.TrueFalse:
                if(answers[0].toLowerCase() === 'true' || answers[0].toLowerCase() === 't')
                    return new TrueFalseQuestion(query, true);
                return new TrueFalseQuestion(query, false);
            case QuestionType.FillBlank:
                if(answers.length === 1)
                    return new FillBlankQuestion(query, [ answers[0] ]);
                return new FillBlankQuestion(query, answers);
        }
    }
    createQuestions(data: any): Question[] {
        let questions: Question[] = new Array<Question>();
        let type: QuestionType = 0;
        let query: string = '';
        let answers: string[] = new Array<string>();
        let parsing: boolean = false;
        
        data.forEach(function(line: string) {
            if(line === '')
            {
                parsing = false;
                questions.push(this.createSingleQuestion(type, query, answers));
                type = 0;
                query = '';
                answers = new Array<string>();
            }

            if(!parsing)
            {
                if(this.types.includes(line.replace('\\s', '')))
                {
                    parsing = true;
                    type = this.types.indexOf(line.replace('\\s', '').toLowerCase());
                }
            }
            else
            {
                if(query === '')
                    query = line;
                else
                    answers.push(line);
            }
        });

        if(query != "" && answers != null)
            questions.push(this.createSingleQuestion(type, query, answers));
        
        return questions;
    }
}
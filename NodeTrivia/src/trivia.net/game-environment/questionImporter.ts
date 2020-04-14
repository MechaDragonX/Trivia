import { TxtReader } from 'txt-reader';

namespace GameEnvironment {
    export class QuestionImporter {
        types: string[] = [
            QuizQuestion.QuestionType.ShortAnswer.toString().toLowerCase(),
            QuizQuestion.QuestionType.MultipleChoice.toString().toLowerCase(),
            QuizQuestion.QuestionType.TrueFalse.toString().toLowerCase(),
            QuizQuestion.QuestionType.FillBlank.toString().toLowerCase()
        ];

        async importFromFile(file: any): Promise<QuizQuestion.Question[]> {
            let reader: TxtReader = new TxtReader();
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
        createSingleQuestion(type: QuizQuestion.QuestionType, query: string, answers: string[]): QuizQuestion.Question {
            switch(type)
            {
                case QuizQuestion.QuestionType.ShortAnswer:
                    if(answers.length == 1)
                        return new QuizQuestion.ShortAnswerQuestion(query, [ answers[0] ]);
                    return new QuizQuestion.ShortAnswerQuestion(query, answers);
                case QuizQuestion.QuestionType.MultipleChoice:
                    let multiple: QuizQuestion.MultipleChoiceQuestion = new QuizQuestion.MultipleChoiceQuestion(query, answers);
                    multiple.getCorrectAnswer(answers[answers.length - 1]);
                    return multiple;
                case QuizQuestion.QuestionType.TrueFalse:
                    if(answers[0].toLowerCase() == 'true' || answers[0].toLowerCase() == 't')
                        return new QuizQuestion.TrueFalseQuestion(query, true);
                    return new QuizQuestion.TrueFalseQuestion(query, false);
                case QuizQuestion.QuestionType.FillBlank:
                    if(answers.length == 1)
                        return new QuizQuestion.FillBlankQuestion(query, [ answers[0] ]);
                    return new QuizQuestion.FillBlankQuestion(query, answers);
            }
        }
        createQuestions(data: any): QuizQuestion.Question[] {
            let questions: QuizQuestion.Question[] = new Array<QuizQuestion.Question>();
            let type: QuizQuestion.QuestionType = 0;
            let query: string = '';
            let answers: string[] = new Array<string>();
            let parsing: boolean = false;
            data.forEach(function(line: string) {
                if(line == '')
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
                    if(query == '')
                        query = line;
                    else
                        answers.push(line);
                }
            });

            questions.push(this.createSingleQuestion(type, query, answers));
            return questions;
        }
    }
}

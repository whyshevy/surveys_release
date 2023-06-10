import { QuestionType } from 'models/surveys';

export interface QuestionProps {
  optionsFieldName: string;
  type?: QuestionType;
}

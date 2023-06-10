import { useField } from 'formik';

import { Question } from 'models/surveys';


const useQuestionsInput = (questionsFieldName: string) => {
  const [field] = useField(questionsFieldName);
  const questions = field.value as Question[];

  const getQuestionFieldName = (order: number) => `${questionsFieldName}.${order}`;

  return { questions, getQuestionFieldName }
}

export { useQuestionsInput };

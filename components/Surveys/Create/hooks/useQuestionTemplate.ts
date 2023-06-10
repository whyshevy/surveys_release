import { optionsField, titleField, typeField } from '../fields';


const useQuestionTemplate = (questionFieldName: string) => {
  const questionTitleFieldName = `${questionFieldName}.${titleField}`;
  const questionTypeFieldName = `${questionFieldName}.${typeField}`;
  const questionOptionsFieldName = `${questionFieldName}.${optionsField}`;

  return { questionTitleFieldName, questionTypeFieldName, questionOptionsFieldName }
}

export { useQuestionTemplate }

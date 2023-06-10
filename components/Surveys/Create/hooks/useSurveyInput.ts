import { questionsField, surveyField, titleField } from '../fields';


const useSurveyInput = () => {
  const surveyTitleFieldName = `${surveyField}.${titleField}`;
  const questionsFieldName = `${surveyField}.${questionsField}`;

  return { surveyTitleFieldName, questionsFieldName }
}

export { useSurveyInput };

import { createEmptySurvey } from 'models/factories/survey';

import { surveyField } from '../fields';


const useCreateSurvey = () => {
  const initialSurveyValues = {
    [surveyField]: createEmptySurvey(),
  };

  return { initialSurveyValues };
};

export { useCreateSurvey };

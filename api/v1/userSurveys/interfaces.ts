import { Survey } from 'models/surveys/Survey';

export interface IUserSurveysApi {
  createSurvey: (userId: string, survey: Survey) => Promise<Response>;
}

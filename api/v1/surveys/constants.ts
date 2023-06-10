import { ApiRoutes } from '../constants';

export class SurveysApiRoutes extends ApiRoutes {
  private static surveysEndpoint = `${ApiRoutes.V1}/surveys`;

  public static SurveyById = (surveyId: string) => `${SurveysApiRoutes.surveysEndpoint}/${surveyId}`;

  public static SurveyResults = (surveyId: string) => `${SurveysApiRoutes.surveysEndpoint}/${surveyId}/results`;

  public static get Home() {
    return SurveysApiRoutes.surveysEndpoint;
  }
}

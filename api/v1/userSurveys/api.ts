import { IUserSurveysApi } from './interfaces';
import { Survey } from '../../../models/surveys/Survey';
import { UsersApiRoutes } from '../users/constants';
import HttpMethod from '../../../common/http/HttpMethod';

export class UserSurveysApi implements  IUserSurveysApi {
  public async createSurvey(userId: string, survey: Survey): Promise<Response> {
    return await fetch(UsersApiRoutes.SurveysByUserId(userId), {
      method: HttpMethod.Post,
      body: JSON.stringify(survey),
      headers: {
        "Content-Type": "application/json",
      },
    });
  }
}

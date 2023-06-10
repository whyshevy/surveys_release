import HttpMethod from 'common/http/HttpMethod';
import { ContentType, ContentTypeField } from 'common/http/ContentType';

import { UsersApiRoutes } from './constants';
import { IUsersApi } from './interfaces';


export class UsersApi implements IUsersApi {
  public async signUp(name: string, email: string, password: string) {
    return await fetch(UsersApiRoutes.SignUp, {
      method: HttpMethod.Post,
      body: JSON.stringify({
        name: name,
        email: email,
        password: password
      }),
      headers: {
        [ContentTypeField]: ContentType.ApplicationJson
      }
    });
  }

  public async signIn(email: string, password: string, shouldRemember: boolean) {
    return await fetch(UsersApiRoutes.SignIn, {
      method: HttpMethod.Post,
      body: JSON.stringify({
        email,
        password,
        shouldRemember
      }),
      headers: {
        [ContentTypeField]: ContentType.ApplicationJson
      }
    });
  }

  public async getSurveys(userId: string) {
    return await fetch(UsersApiRoutes.SurveysByUserId(userId), {
      method: HttpMethod.Get,
      headers: {
        'Content-Type': 'application/json'
      }
    });
  }
}

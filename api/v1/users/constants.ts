import { ApiRoutes } from "../constants";

export class UsersApiRoutes extends ApiRoutes {
  private static usersEndpoint = `${ApiRoutes.V1}/users`;

  public static SignUp = `${UsersApiRoutes.usersEndpoint}/sign-up`;
  public static SignIn = `${UsersApiRoutes.usersEndpoint}/sign-in`;
  public static SurveysByUserId = (userId: string) => `${UsersApiRoutes.usersEndpoint}/${userId}/surveys`;
}

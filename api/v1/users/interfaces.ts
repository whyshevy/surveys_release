export interface IUsersApi {
  signUp: (name: string, email: string, password: string) => Promise<Response>;

  signIn: (email: string, password: string, shouldRemember: boolean) => Promise<Response>;

  getSurveys: (userId: string) => Promise<Response>;
}

namespace Surveys.Backend.WebApp.Contracts.V1;

public static class Routes
{
    private const string Base = "api";
    private const string Version = "v1";
    private const string RootUrl = $"{Base}/{Version}";


    public static class Users
    {
        private const string EndpointBase = $"{RootUrl}/users";


        public const string SignUp = $"{EndpointBase}/sign-up";
        public const string SignIn = $"{EndpointBase}/sign-in";
    }

    public static class UserSurveys
    {
        private const string EndpointBase = $"{RootUrl}/users";


        public const string Home = EndpointBase + "/{userId:guid}/surveys";
        public const string Create = $"{Home}";
        public const string GetById = Home + "/{surveyId:guid}";
    }

    public static class Surveys
    {
        private const string EndpointBase = $"{RootUrl}/surveys";


        public const string GetById = EndpointBase + "/{surveyId:guid}";
        public const string Home = EndpointBase;
    }

    public static class SurveyResults
    {
        private const string EndpointBase = $"{RootUrl}/surveys";


        public const string Home = EndpointBase + "/{surveyId:guid}/results";
    }
}
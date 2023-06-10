using MediatR;
using Surveys.Backend.Common.OperationResult;
using Surveys.Backend.DomainModel;
using Surveys.Backend.Foundation.UserSurveys.CreateSurvey.Errors;
using Surveys.Backend.Foundation.UserSurveys.CreateSurvey.Models;
using Surveys.Backend.Repositories.Surveys;

namespace Surveys.Backend.Foundation.UserSurveys.CreateSurvey;

public class CreateSurveyHandler : IRequestHandler<CreateSurveyCommand, OperationResult<CreateSurveyResult?, CreateSurveyError>>
{
    private readonly SurveysRepository _surveysRepository;


    public CreateSurveyHandler(SurveysRepository surveysRepository)
    {
        _surveysRepository = surveysRepository;
    }


    public async Task<OperationResult<CreateSurveyResult?, CreateSurveyError>> Handle(
        CreateSurveyCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var questionnaireResult = CreateFrom(request);
        if (!questionnaireResult.IsSuccessful)
        {
            return questionnaireResult.Errors.FirstOrDefault();
        }

        if (questionnaireResult.Result is null)
        {
            return CreateSurveyError.Unknown;
        }

        try
        {
            var createdQuestionnaire = await _surveysRepository.AddAsync(questionnaireResult.Result, cancellationToken);

            return CreateFrom(createdQuestionnaire);
        }
        catch (Exception)
        {
            return CreateSurveyError.Unknown;
        }
    }


    private static OperationResult<Questionnaire?, CreateSurveyError> CreateFrom(CreateSurveyCommand questionnaire)
    {
        if (string.IsNullOrEmpty(questionnaire.Title))
        {
            return CreateSurveyError.TitleRequired;
        }

        if (questionnaire.Title.Length > Questionnaire.TitleMaxLength)
        {
            return CreateSurveyError.TitleTooLong;
        }

        if (questionnaire.Description is not null && questionnaire.Description.Length > Questionnaire.DescriptionMaxLength)
        {
            return CreateSurveyError.DescriptionTooLong;
        }

        return new Questionnaire
        {
            Title = questionnaire.Title,
            CreatedById = questionnaire.CreatedById,
            UpdatedById = questionnaire.CreatedById,
            Questions = CreateFrom(questionnaire.Questions).ToList(),
            RegisteredOnly = questionnaire.IsRegisteredOnly
        };
    }

    private static IReadOnlyCollection<Question> CreateFrom(IReadOnlyCollection<CreateQuestion> questions)
        => questions.Select(CreateFrom).ToList();

    private static Question CreateFrom(CreateQuestion question)
    {
        IReadOnlyCollection<Option> options = Array.Empty<Option>();
        if (question.Options is not null)
        {
            options = CreateFrom(question.Options);
        }

        return new()
        {
            Title = question.Title,
            Type = question.Type,
            Options = options.ToList()
        };
    }

    private static IReadOnlyCollection<Option> CreateFrom(IReadOnlyCollection<CreateOption> options)
        => options.Select(CreateFrom).ToList();

    private static Option CreateFrom(CreateOption option)
    {
        return new()
        {
            Content = option.Content,
            Order = option.Order ?? 0,
        };
    }

    private static CreateSurveyResult CreateFrom(Questionnaire questionnaire)
    {
        return new()
        {
            Id = questionnaire.Id
        };
    }
}
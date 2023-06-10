using MediatR;
using Surveys.Backend.DomainModel;
using Surveys.Backend.Foundation.Options.Models;
using Surveys.Backend.Foundation.Questions.Models;
using Surveys.Backend.Foundation.Roles.Models;
using Surveys.Backend.Foundation.SurveyResults.Models;
using Surveys.Backend.Foundation.Surveys.Models;
using Surveys.Backend.Foundation.Users.Models;
using Surveys.Backend.Repositories.SurveyResults;

namespace Surveys.Backend.Foundation.SurveyResults.CreateSurveyResult;

public class CreateSurveyResultHandler : IRequestHandler<CreateSurveyResultCommand, SurveyResult>
{
    private readonly SurveyResultsRepository _surveyResultsRepository;


    public CreateSurveyResultHandler(SurveyResultsRepository surveyResultsRepository)
    {
        _surveyResultsRepository = surveyResultsRepository;
    }


    public async Task<SurveyResult> Handle(CreateSurveyResultCommand command, CancellationToken cancellationToken)
    {
        var surveyResult = new QuestionnaireResult
        {
            PassedById = command.PassedById,
            Answers = CreateFrom(command.Answers).ToList(),
            QuestionnaireId = command.SurveyId,
        };

        var createdSurveyResult = await _surveyResultsRepository.AddAsync(surveyResult, cancellationToken);

        return CreateFrom(createdSurveyResult);
    }


    private static IReadOnlyCollection<Answer> CreateFrom(IReadOnlyCollection<AnswerDto> answers)
    {
        return answers.Select(CreateFrom).ToList();
    }

    private static Answer CreateFrom(AnswerDto answer)
    {
        return new()
        {
            QuestionId = answer.QuestionId,
            Rating = answer.Rating,
            Text = answer.Text,
            SelectedOptionsIds = answer.SelectedOptionsIds,
        };
    }

    private static SurveyResult CreateFrom(QuestionnaireResult createdSurveyResult)
    {
        return new()
        {
            Id = createdSurveyResult.Id,
            Answers = CreateFrom(createdSurveyResult.Answers.ToList()),
            PassedBy = CreateFrom(createdSurveyResult.PassedBy),
            QuestionnaireId = createdSurveyResult.QuestionnaireId,
            PassedById = createdSurveyResult.PassedById
        };
    }

    private static UserDto? CreateFrom(User? createdSurveyResult)
    {
        if (createdSurveyResult is null)
        {
            return null;
        }

        return new()
        {
            Email = createdSurveyResult.Email,
            Id = createdSurveyResult.Id,
            Name = createdSurveyResult.Name,
            Roles = CreateFrom(createdSurveyResult.Roles).ToList()
        };
    }

    private static IReadOnlyCollection<RoleDto> CreateFrom(ICollection<Role> createdSurveyResult)
    {
        return createdSurveyResult.Select(CreateFrom).ToList();
    }

    private static RoleDto CreateFrom(Role createdSurveyResult)
    {
        return new()
        {
            Id = createdSurveyResult.Id,
            Name = createdSurveyResult.Name,
        };
    }

    private static IReadOnlyCollection<AnswerDto> CreateFrom(IReadOnlyCollection<Answer> createdSurveyResult)
    {
        return createdSurveyResult.Select(CreateFrom).ToList();
    }

    private static AnswerDto CreateFrom(Answer createdSurveyResult)
    {
        return new()
        {
            Id = createdSurveyResult.Id,
            Question = CreateFrom(createdSurveyResult.Question),
            Rating = createdSurveyResult.Rating,
            Text = createdSurveyResult.Text,
            QuestionId = createdSurveyResult.QuestionId,
            SelectedOptionsIds = createdSurveyResult.SelectedOptionsIds
        };
    }

    private static QuestionDto? CreateFrom(Question? createdSurveyResult)
    {
        if (createdSurveyResult is null)
        {
            return null;
        }

        return new()
        {
            Description = createdSurveyResult.Description,
            Id = createdSurveyResult.Id,
            Options = CreateFrom(createdSurveyResult.Options).ToList(),
            Order = createdSurveyResult.Order,
            Questionnaire = CreateFrom(createdSurveyResult.Questionnaire),
            Title = createdSurveyResult.Title,
            Type = createdSurveyResult.Type,
            IsRequired = createdSurveyResult.IsRequired,
            QuestionnaireId = createdSurveyResult.QuestionnaireId
        };
    }

    private static ICollection<OptionDto> CreateFrom(ICollection<Option> createdSurveyResult)
    {
        return createdSurveyResult.Select(CreateFrom).ToList();
    }

    private static OptionDto CreateFrom(Option createdSurveyResult)
    {
        return new()
        {
            Id = createdSurveyResult.Id,
            Content = createdSurveyResult.Content,
            Order = createdSurveyResult.Order,
            Question = CreateFrom(createdSurveyResult.Question),
            QuestionId = createdSurveyResult.QuestionId
        };
    }

    private static SurveyDto? CreateFrom(Questionnaire? createdSurveyResult)
    {
        if (createdSurveyResult is null)
        {
            return null;
        }

        return new()
        {
            Description = createdSurveyResult.Description,
            Id = createdSurveyResult.Id,
            Questions = CreateFrom(createdSurveyResult.Questions).ToList(),
            Title = createdSurveyResult.Title,
            CreatedBy = CreateFrom(createdSurveyResult.CreatedBy),
            RegisteredOnly = createdSurveyResult.RegisteredOnly,
            UpdatedBy = CreateFrom(createdSurveyResult.UpdatedBy),
            CreatedById = createdSurveyResult.CreatedById,
            UpdatedById = createdSurveyResult.UpdatedById,
        };
    }

    private static IReadOnlyCollection<QuestionDto?> CreateFrom(ICollection<Question> createdSurveyResult)
    {
        return createdSurveyResult.Select(CreateFrom).ToList();
    }
}
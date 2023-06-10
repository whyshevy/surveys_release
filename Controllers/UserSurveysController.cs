using MediatR;
using Microsoft.AspNetCore.Mvc;
using Surveys.Backend.Common.Extensions;
using Surveys.Backend.Foundation.UserSurveys.CreateSurvey;
using Surveys.Backend.Foundation.UserSurveys.CreateSurvey.Models;
using Surveys.Backend.Foundation.UserSurveys.GetAllUserSurveys;
using Surveys.Backend.Foundation.UserSurveys.GetAllUserSurveys.Models;
using Surveys.Backend.WebApp.Contracts.V1;
using Surveys.Backend.WebApp.Contracts.V1.Users.Surveys;

namespace Surveys.Backend.WebApp.Controllers;


public class UserSurveysController : ApiController
{
    private readonly IMediator _mediator;


    public UserSurveysController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route(Routes.UserSurveys.Home)]
    [ProducesResponseType(typeof(IReadOnlyCollection<SurveyResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IReadOnlyCollection<SurveyResponse>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll(Guid userId)
    {
        var surveysCommand = new GetAllUserSurveysCommand
        {
            UserId = userId
        };
        
        var surveysResult = await _mediator.Send(surveysCommand);
        if (surveysResult.UserSurveys.IsNullOrEmpty())
        {
            return Ok(surveysResult.UserSurveys);
        }

        var surveysResponse = CreateFrom(surveysResult);

        return Ok(surveysResponse);
    }

    [HttpGet]
    [Route(Routes.UserSurveys.GetById)]
    [ProducesResponseType(typeof(IReadOnlyCollection<SurveyResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IReadOnlyCollection<SurveyResponse>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBySurveyId(Guid userId, Guid surveyId)
    {
        var surveysCommand = new GetAllUserSurveysCommand
        {
            UserId = userId
        };
        
        var surveysResult = await _mediator.Send(surveysCommand);
        if (surveysResult.UserSurveys.IsNullOrEmpty())
        {
            return Ok(surveysResult.UserSurveys);
        }

        var surveysResponse = CreateFrom(surveysResult);

        return Ok(surveysResponse);
    }

    [HttpPost]
    [Route(Routes.UserSurveys.Create)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CreateSurveyResult), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(Guid userId, [FromBody] CreateSurveyRequest request)
    {
        var createQuestionnaireCommand = new CreateSurveyCommand
        {
            Title = request.Title,
            Description = request.Description,
            CreatedById = userId,
            Questions = CreateFrom(request.Questions)
        };

        var createSurveyResult = await _mediator.Send(createQuestionnaireCommand);
        if (!createSurveyResult.IsSuccessful)
        {
            return BadRequest(createSurveyResult.CreateSingleStringError());
        }

        return CreatedAtAction(
            nameof(GetBySurveyId),
            new { userId, surveyId = createSurveyResult.Result!.Id },
            createSurveyResult.Result);
    }


    private static IReadOnlyCollection<SurveyResponse> CreateFrom(UserSurveysResult surveysResult)
    {
        ArgumentNullException.ThrowIfNull(surveysResult);

        var surveys = surveysResult.UserSurveys
            .Select(us => new SurveyResponse(us.Id, us.Title, us.UpdatedAt, us.ResponsesCount))
            .ToList();

        return surveys;
    }

    private static IReadOnlyCollection<CreateQuestion> CreateFrom(IReadOnlyCollection<CreateSurveyQuestion> questions)
    {
        ArgumentNullException.ThrowIfNull(questions);

        if (questions.IsEmpty())
        {
            return Array.Empty<CreateQuestion>();
        }

        return questions.Select(CreateFrom).ToList();
    }

    private static CreateQuestion CreateFrom(CreateSurveyQuestion question)
    {
        ArgumentNullException.ThrowIfNull(question);

        return new()
        {
            Title = question.Title,
            Description = question.Description,
            Options = CreateFrom(question.Options),
            Type = question.Type,
            Order = question.Order,
        };
    }

    private static IReadOnlyCollection<CreateOption> CreateFrom(IReadOnlyCollection<CreateSurveyOption>? options)
    {
        if (options.IsNullOrEmpty())
        {
            return Array.Empty<CreateOption>();
        }

        return options!.Select(CreateFrom).ToList();
    }

    private static CreateOption CreateFrom(CreateSurveyOption option)
    {
        ArgumentNullException.ThrowIfNull(option);

        return new()
        {
            Content = option.Content,
            Order = option.Order
        };
    }
}
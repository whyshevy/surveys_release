using MediatR;
using Microsoft.AspNetCore.Mvc;
using Surveys.Backend.Foundation.SurveyResults.CreateSurveyResult;
using Surveys.Backend.Foundation.SurveyResults.Models;
using Surveys.Backend.WebApp.Contracts.V1;
using Surveys.Backend.WebApp.Contracts.V1.SurveyResults.Create;

namespace Surveys.Backend.WebApp.Controllers;

public class SurveyResultsController : ApiController
{
    private readonly IMediator _mediator;


    public SurveyResultsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route(Routes.SurveyResults.Home)]
    public async Task<IActionResult> Get(Guid surveyId, [FromBody] CreateSurveyResultRequest request)
    {
        var command = new CreateSurveyResultCommand
        {
            SurveyId = surveyId,
            Answers = CreateFrom(request.Answers),
            PassedById = request.PassedById,
        };

        var createSurveyResultResult = await _mediator.Send(command);

        return Ok(createSurveyResultResult.Id);
    }

    [HttpPost]
    [Route(Routes.SurveyResults.Home)]
    public async Task<IActionResult> Create(Guid surveyId, [FromBody] CreateSurveyResultRequest request)
    {
        var command = new CreateSurveyResultCommand
        {
            SurveyId = surveyId,
            Answers = CreateFrom(request.Answers),
            PassedById = request.PassedById,
        };

        var createSurveyResultResult = await _mediator.Send(command);

        return Ok(createSurveyResultResult.Id);
    }

    
    private IReadOnlyCollection<AnswerDto> CreateFrom(IReadOnlyCollection<CreateSurveyResultAnswer> answers)
    {
        return answers.Select(CreateFrom).ToList();
    }

    private AnswerDto CreateFrom(CreateSurveyResultAnswer answer)
    {
        return new()
        {
            Rating = answer.Rating,
            Text = answer.Text,
            QuestionId = answer.QuestionId,
            SelectedOptionsIds = answer.SelectedOptionsIds
        };
    }
}
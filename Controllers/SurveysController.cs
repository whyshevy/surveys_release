using MediatR;
using Microsoft.AspNetCore.Mvc;
using Surveys.Backend.Foundation.Surveys.DeleteById;
using Surveys.Backend.Foundation.Surveys.GetById;
using Surveys.Backend.Foundation.Surveys.Models;
using Surveys.Backend.WebApp.Contracts.V1;
using Surveys.Backend.WebApp.Contracts.V1.Surveys.GetById;

namespace Surveys.Backend.WebApp.Controllers;


public class SurveysController : ApiController
{
    private readonly IMediator _mediator;


    public SurveysController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route(Routes.Surveys.GetById)]
    [ProducesResponseType(typeof(GetByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid surveyId)
    {
        var command = new GetByIdCommand
        {
            Id = surveyId
        };

        var survey = await _mediator.Send(command);
        if (survey is null)
        {
            return NotFound();
        }

        var response = CreateFrom(survey.Survey);

        return Ok(response);
    }

    [HttpDelete]
    [Route(Routes.Surveys.GetById)]
    [ProducesResponseType(typeof(GetByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid surveyId)
    {
        var command = new DeleteByIdCommand
        {
            SurveyId = surveyId
        };

        var survey = await _mediator.Send(command);
        if (survey is null)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete]
    [Route(Routes.Surveys.Home)]
    [ProducesResponseType(typeof(GetByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteRange([FromQuery] IReadOnlyCollection<Guid> surveyIds)
    {
        bool? survey = false;

        foreach (var surveyId in surveyIds)
        {
            var command = new DeleteByIdCommand
            {
                SurveyId = surveyId
            };

            survey = await _mediator.Send(command);
        }

        if (survey is null)
        {
            return NotFound();
        }

        return Ok();
    }


    private static GetByIdResponse CreateFrom(SurveyDto surveyDto)
    {
        return new()
        {
            Id = surveyDto.Id,
            Title = surveyDto.Title,
            Description = surveyDto.Description,
            Questions = surveyDto.Questions,
            CreatedBy = surveyDto.CreatedBy,
            RegisteredOnly = surveyDto.RegisteredOnly,
            UpdatedBy = surveyDto.UpdatedBy,
            CreatedById = surveyDto.CreatedById,
            UpdatedById = surveyDto.UpdatedById
        };
    }
}
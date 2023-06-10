using MediatR;
using Surveys.Backend.Foundation.Surveys.GetById.Models;

namespace Surveys.Backend.Foundation.Surveys.GetById;

public class GetByIdCommand : IRequest<GetByIdResult?>
{
    public Guid Id { get; set; }
}
using FluentValidation.Results;
using MediatR;

namespace DesafioFWK_Core.Commands
{
    public abstract class Command : IRequest<ValidationResult>, IBaseRequest
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}

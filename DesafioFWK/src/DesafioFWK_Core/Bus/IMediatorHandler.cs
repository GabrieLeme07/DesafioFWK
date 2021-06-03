using DesafioFWK_Core.Commands;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace DesafioFWK_Core.Bus
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> SendCommand<TCommand>(TCommand command) where TCommand : Command;
    }
}

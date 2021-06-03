using DesafioFWK_Domain.Commands.Fruits;
using DesafioFWK_Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioFWK_Domain.CommandHandlers.Fruits
{
    public class FruitDeleteCommandHandler : CommandHandler,
        IRequestHandler<FruitDeleteCommand, ValidationResult>
    {
        private readonly IFruitRepository _fruitRepository;

        public FruitDeleteCommandHandler(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
        }

        public async Task<ValidationResult> Handle(FruitDeleteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var fruitDomain = await _fruitRepository.GetById(request.Id);

            if (fruitDomain == null)
                return AddError(404, "Fruta não encontrada para edição.");

             await _fruitRepository.Delete(request.Id);

            cancellationToken.ThrowIfCancellationRequested();
            return await Commit(_fruitRepository.UnitOfWork);
        }
    }
}

using DesafioFWK_Domain.Interfaces;
using DesafioFWK_Domain.Validation.Fruits;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioFWK_Domain.CommandHandlers.Fruits
{
    public class FruitSellCommandHandler : CommandHandler,
        IRequestHandler<FruitSellCommand, ValidationResult>
    {
        private readonly IFruitRepository _fruitRepository;

        public FruitSellCommandHandler(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
        }

        public async Task<ValidationResult> Handle(FruitSellCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var fruitDomain = await _fruitRepository.GetById(request.Id);
            var amount = fruitDomain.Estoque;
            if (fruitDomain == null)
                return AddError(404, "Fruta não encontrada para edição.");

            fruitDomain.Estoque = amount - 1;

            _fruitRepository.Update(fruitDomain);

            cancellationToken.ThrowIfCancellationRequested();
            return await Commit(_fruitRepository.UnitOfWork);
        }
    }
}

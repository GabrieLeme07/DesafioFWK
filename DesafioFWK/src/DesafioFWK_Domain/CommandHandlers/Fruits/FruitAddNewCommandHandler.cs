using AutoMapper;
using DesafioFWK_Domain.Commands.Fruits;
using DesafioFWK_Domain.Interfaces;
using DesafioFWK_Domain.Model;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioFWK_Domain.CommandHandlers.Fruits
{
    public class FruitAddNewCommandHandler : CommandHandler,
        IRequestHandler<FruitAddCommand, ValidationResult>
    {
        private readonly IMapper Mapper;
        private readonly IFruitRepository _fruitRepository;

        public FruitAddNewCommandHandler(IFruitRepository fruitRepository, IMapper mapper)
        {
            _fruitRepository = fruitRepository;
            Mapper = mapper;
        }

        public async Task<ValidationResult> Handle(FruitAddCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var fruit = Mapper.Map<FruitAddCommand, Fruit>(request);

            await _fruitRepository.Add(fruit);

            cancellationToken.ThrowIfCancellationRequested();
            return await Commit(_fruitRepository.UnitOfWork);
        }
    }
}

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
    public class FruitUpdateCommandHandler : CommandHandler,
        IRequestHandler<FruitUpdateCommand, ValidationResult>
    {
        private readonly IMapper Mapper;
        private readonly IFruitRepository _fruitRepository;

        public FruitUpdateCommandHandler(IFruitRepository fruitRepository, IMapper mapper)
        {
            _fruitRepository = fruitRepository;
            Mapper = mapper;
        }

        public async Task<ValidationResult> Handle(FruitUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var fruitRequest = Mapper.Map<FruitUpdateCommand, Fruit>(request);

            var fruitDomain = await _fruitRepository.GetById(request.Id);

            if (fruitDomain == null)
                return AddError(404, "Fruta não encontrada para edição.");

            fruitDomain.Nome = fruitRequest.Nome;
            fruitDomain.Valor = fruitRequest.Valor;
            fruitDomain.Imagem = fruitRequest.Imagem;
            fruitDomain.Descricao = fruitRequest.Descricao;

            _fruitRepository.Update(fruitDomain);

            cancellationToken.ThrowIfCancellationRequested();
            return await Commit(_fruitRepository.UnitOfWork);
        }
    }
}

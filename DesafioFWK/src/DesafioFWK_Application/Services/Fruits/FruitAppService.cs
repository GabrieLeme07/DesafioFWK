using AutoMapper;
using DesafioFWK_Application.AutoMapper;
using DesafioFWK_Application.Interfaces;
using DesafioFWK_Application.ViewModel;
using DesafioFWK_Application.ViewModel.Fruits;
using DesafioFWK_Core.Bus;
using DesafioFWK_Domain.Commands.Fruits;
using DesafioFWK_Domain.Interfaces;
using DesafioFWK_Domain.Model;
using DesafioFWK_Domain.Validation.Fruits;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioFWK_Application.Services.Fruits
{
    public class FruitAppService : IFruitAppService
    {
        private readonly IMapper Mapper;
        private readonly IMediatorHandler Bus;
        private readonly IFruitRepository _fruitRepository;
        public FruitAppService(
            IMapper mapper,
            IMediatorHandler bus,
            IFruitRepository fruitRepository)
        {
            Bus = bus;
            Mapper = mapper;
            _fruitRepository = fruitRepository;
        }

        public async Task<List<FruitViewModel>> GetAll()
        {
            var result = await _fruitRepository.GetAll();
            return result.Map<Fruit, FruitViewModel>(Mapper);
        }

        public async Task<FruitViewModel> GetById(Guid id)
        {
            var result = await _fruitRepository.GetById(id);
            return Mapper.Map<Fruit, FruitViewModel>(result);
        }

        public async Task<AddResultViewModel> Add(FruitAddViewModel fruit)
        {
            var commandAdd = Mapper.Map<FruitAddViewModel, FruitAddCommand>(fruit);
            var result = await Bus.SendCommand(commandAdd);

            return (result.IsValid)
                ? new AddResultViewModel(commandAdd.Id)
                : new AddResultViewModel(result);
        }

        public async Task<ValidationResult> Update(FruitUpdateViewModel fruit)
        {
            var commandUpdate = Mapper.Map<FruitUpdateViewModel, FruitUpdateCommand>(fruit);
            return await Bus.SendCommand(commandUpdate);
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            var commandDelete = new FruitDeleteCommand(id);
            return await Bus.SendCommand(commandDelete);
        }

        public async Task<ValidationResult> SellFruit(Guid id)
        {
            var commandSell = new FruitSellCommand(id);
            return await Bus.SendCommand(commandSell);
        }

        public void Dispose()
            => GC.SuppressFinalize(this);
    }
}

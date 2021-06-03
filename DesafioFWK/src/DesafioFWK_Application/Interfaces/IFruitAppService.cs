using DesafioFWK_Application.ViewModel;
using DesafioFWK_Application.ViewModel.Fruits;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioFWK_Application.Interfaces
{
    public interface IFruitAppService : IDisposable
    {
        Task<FruitViewModel> GetById(Guid id);

        Task<List<FruitViewModel>> GetAll();

        Task<AddResultViewModel> Add(FruitAddViewModel fruit);

        Task<ValidationResult> Update(FruitUpdateViewModel fruit);

        Task<ValidationResult> Delete(Guid id);

        Task<ValidationResult> SellFruit(Guid id);
    }
}

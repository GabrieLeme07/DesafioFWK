using AutoMapper;
using DesafioFWK_Application.ViewModel.Fruits;
using DesafioFWK_Domain.Commands.Fruits;
using DesafioFWK_Domain.Model;
using System.Collections.Generic;

namespace DesafioFWK_Application.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Fruit, FruitViewModel>();
            CreateMap<FruitAddViewModel, FruitAddCommand>();
            CreateMap<FruitUpdateViewModel, FruitUpdateCommand>();
            CreateMap<FruitUpdateCommand, Fruit>();
            CreateMap<FruitAddCommand, Fruit>();
        }
    }
}

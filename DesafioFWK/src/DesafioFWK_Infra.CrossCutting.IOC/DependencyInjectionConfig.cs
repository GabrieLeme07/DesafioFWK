using DesafioFWK_Application.AutoMapper;
using DesafioFWK_Application.Interfaces;
using DesafioFWK_Application.Services.Fruits;
using DesafioFWK_Application.Services.Users;
using DesafioFWK_Core.Bus;
using DesafioFWK_Domain.Interfaces;
using DesafioFWK_Infra.Configuration;
using DesafioFWK_Infra.Context;
using DesafioFWK_Infra.Repository.Fruits;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DesafioFWK_Infra.CrossCutting.IOC
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .RegisterMediator()
                .RegisterAppServices()
                .RegisterRepositories()
                .RegisterAutoMapper()

                .AddScoped<MeuDataContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>();

        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IFruitRepository, FruitRepository>();
        }

        private static IServiceCollection RegisterMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("DesafioFWK_Domain");
            return services
                .AddScoped<IMediatorHandler, InMemoryBus>()
                .AddMediatR(assembly);

        }

        private static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IFruitAppService, FruitAppService>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddScoped<IUser, AspNetUser>();
        }

        private static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = AutoMapperConfig.RegisterMappings();
            var mapper = mapperConfig.CreateMapper();
            return services
                .AddSingleton(mapper);
        }
    }
}

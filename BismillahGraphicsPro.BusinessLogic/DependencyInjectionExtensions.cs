﻿using Microsoft.Extensions.DependencyInjection;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.BusinessLogic.Registration;

namespace BismillahGraphicsPro.BusinessLogic
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRegistrationCore, RegistrationCore>();

            return services;
        }
    }
}
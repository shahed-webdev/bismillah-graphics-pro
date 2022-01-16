using Microsoft.Extensions.DependencyInjection;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.BusinessLogic.Registration;

namespace BismillahGraphicsPro.BusinessLogic
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAccountCore, AccountCore>();
            services.AddTransient<IRegistrationCore, RegistrationCore>();
            services.AddTransient<IMeasurementUnitCore, MeasurementUnitCore>();

            return services;
        }
    }
}
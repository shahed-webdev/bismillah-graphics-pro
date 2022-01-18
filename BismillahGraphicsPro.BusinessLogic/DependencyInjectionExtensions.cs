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
            services.AddTransient<IExpenseCore, ExpenseCore>();
            services.AddTransient<IProductCore, ProductCore>();
            services.AddTransient<IRegistrationCore, RegistrationCore>();
            services.AddTransient<IMeasurementUnitCore, MeasurementUnitCore>();
            services.AddTransient<ISupplierCore, SupplierCore>();

            return services;
        }
    }
}
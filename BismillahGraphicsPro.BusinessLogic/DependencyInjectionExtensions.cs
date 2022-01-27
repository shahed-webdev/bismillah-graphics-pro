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
            services.AddTransient<IDashboardCore, DashboardCore>();
            services.AddTransient<IExpenseCore, ExpenseCore>();
            services.AddTransient<IProductCore, ProductCore>();
            services.AddTransient<IPurchaseCore, PurchaseCore>();
            services.AddTransient<IRegistrationCore, RegistrationCore>();
            services.AddTransient<IMeasurementUnitCore, MeasurementUnitCore>();
            services.AddTransient<ISupplierCore, SupplierCore>();
            services.AddTransient<IVendorCore, VendorCore>();
            services.AddTransient<ISellingCore, SellingCore>();

            return services;
        }
    }
}
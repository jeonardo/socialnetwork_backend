using FinalWebApp_Backend_DAL.Entities;
using FinalWebApp_Backend_DAL.UnitOfWork;
using FinalWebApp_Backend_DAL.UnitOfWork.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FinalWebApp_Backend_DAL
{
    public static class DIExtentionDAL
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddIdentityCore<User>()
                    .AddEntityFrameworkStores<ApplicationContext>()
                    .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationContext>();
            services.AddTransient<IUnitOfWork, UnitOfWok>();

        }
    }
}

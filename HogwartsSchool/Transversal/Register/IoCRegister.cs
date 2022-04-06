using DataAccess;
using DataAccess.Contracts;
using DataAccess.Contracts.Repositories;
using DataAccess.Repositories;
using HogwartsSchool.Api.Services.Contracts.Services;
using HogwartsSchool.Api.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transversal.Register
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services, string conectionString = "")
        {
            AddRegisterDBContext(services, conectionString);
            AddRegisterRepositories(services);
            AddRegisterServices(services);

            return services;
        }

        private static void AddRegisterDBContext(this IServiceCollection services, string conectionString)
        {

            services.AddDbContext<HowartsSchoolRequestDBContext>(cfg =>
            {
                cfg.UseSqlServer(conectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddTransient<IHowartsSchoolRequestDBContext, HowartsSchoolRequestDBContext>();
        }

        public static void AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISolicitudIngresocsRepository, SolicitudIngresocsRepository>();            
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<ISolicitudIngresocsService, SolicitudIngresocsService>();            

            return services;
        }

    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using PeopleManagement.Infrastructure.Repositories;
using PeopleManagement.Domain.Interfaces;
using PeopleManagement.Application.Services.Interfaces;
using PeopleManagement.Application;
using PeopleManagement.Infrastructure;
using System.Configuration;

namespace PeopleManagement.ConsolTest.App_Start
{


    public static class DependencyInjectionConfig {
        public static IServiceProvider ConfigureServices() {
            var services = new ServiceCollection();

            // Registrar AutoMapper
          //  services.AddAutoMapper(typeof(MappingProfileInfra));

            // Registrar repositorios, servicios y dependencias
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<PeopleDBContext>(provider =>
            {
                var connectionString = ConfigurationManager.ConnectionStrings["PeopleDBConnection"].ConnectionString;
                return new PeopleDBContext(connectionString);
            });

            // Construir el contenedor
            return services.BuildServiceProvider();
        }
    }

}

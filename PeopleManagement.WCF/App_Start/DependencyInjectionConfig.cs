using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PeopleManagement.Infrastructure.Mappings;
using System;
using PeopleManagement.Infrastructure.Repositories;
using PeopleManagement.Domain.Interfaces;

namespace PeopleManagement.ConsolTest.App_Start
{


    public static class DependencyInjectionConfig {
        public static IServiceProvider ConfigureServices() {
            var services = new ServiceCollection();

            // Registrar AutoMapper
           // services.AddAutoMapper(typeof(MappingProfileInfra));

            // Registrar repositorios, servicios y dependencias
            services.AddScoped<IPersonRepository, PersonRepository>();

            // Construir el contenedor
            return services.BuildServiceProvider();
        }
    }

}

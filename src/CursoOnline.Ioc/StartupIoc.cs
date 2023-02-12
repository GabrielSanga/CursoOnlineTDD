using CursoOnline.Dados.Contextos;
using CursoOnline.Dados.Repositorios;
using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Cursos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CursoOnline.Ioc
{

    /// <summary>
    /// Esse projeto é responsável por fazer as configurações da nossa camada de apresentação com a camada de infra
    /// Dessa forma conseguimos injetar nas controller e isso de forma automatica possa ser injetada pelo .net core, com isso não precisa ficar instanciando (Injeção de dependencia)
    /// </summary>
    public static class StartupIoc
    {

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //Configurando o serviço do Entity Framework
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration["ConnectionString"]));

            //Configurando o repostitório, para que toda vez que chamar a interface IRepositorio sempre tenha o RepositorioBase
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped(typeof(iCursoRepositorio), typeof(CursoRepositorio));

            //Configurando o armazenador
            services.AddScoped<ArmazenadorCursoService>();
        }

    }

}

using AcademiaMagento.Application.AppServices;
using AcademiaMagento.Application.Interfaces;
using AcademiaMagento.Domain.Interfaces.Repository;
using AcademiaMagento.Domain.Interfaces.Repository._Base;
using AcademiaMagento.Domain.Interfaces.Service;
using AcademiaMagento.Domain.Services;
using AcademiaMagento.Infra.Data.EntityFramework.Context;
using AcademiaMagento.Infra.Data.EntityFramework.Repository;
using AcademiaMagento.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaMagento.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<AcademiaContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                )
            );

            // Repositories
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IAvaliacaoFisicaRepository, AvaliacaoFisicaRepository>();
            services.AddScoped<IRegistroAcessoRepository, RegistroAcessoRepository>();

            // Domain Services
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<IMatriculaService, MatriculaService>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IAvaliacaoFisicaService, AvaliacaoFisicaService>();
            services.AddScoped<IRegistroAcessoService, RegistroAcessoService>();

            // Application Services
            services.AddScoped<IAlunoAppService, AlunoAppService>();
            services.AddScoped<IServicoAppService, ServicoAppService>();
            services.AddScoped<IMatriculaAppService, MatriculaAppService>();
            services.AddScoped<IPagamentoAppService, PagamentoAppService>();
            services.AddScoped<IAvaliacaoFisicaAppService, AvaliacaoFisicaAppService>();
            services.AddScoped<IRegistroAcessoAppService, RegistroAcessoAppService>();

            return services;
        }
    }
}
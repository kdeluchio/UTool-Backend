using Microsoft.Extensions.DependencyInjection;
using UTools.Application.AppServices;
using UTools.Application.Interfaces;
using UTools.Domain.Commands;
using UTools.Domain.Interfaces.Commands;
using UTools.Domain.Interfaces.Repositories;
using UTools.Domain.Interfaces.Validators;
using UTools.Domain.Validators;
using UTools.Infra.Data.Repositories;

namespace UTools.Infra.CrossCutting
{
    public static class Ioc
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICriarEmpresaAppService, CriarEmpresaAppService>();
            services.AddScoped<IExcluirEmpresaAppService, ExcluirEmpresaAppService>();
            services.AddScoped<ICnpjValidator, CnpjValidator>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        }

        public static void AddCommands(this IServiceCollection services)
        {
            services.AddScoped<ICriarEmpresaCommand, CriarEmpresaCommand>();
            services.AddScoped<IExcluirEmpresaCommand, ExcluirEmpresaCommand>();

        }

    }
}

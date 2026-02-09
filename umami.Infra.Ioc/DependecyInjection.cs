using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Application.Interfaces;
using umami.Application.Mappings;
using umami.Application.Mappings;
using umami.Application.Services;
using umami.Domain.Account;
using umami.Domain.Interfaces;
using umami.Infra.Data.Context;
using umami.Infra.Data.Identity;
using umami.Infra.Data.Repositories;

namespace umami.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["jwt:issuer"],
                    ValidAudience = configuration["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["jwt:secretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //Repositories
            services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<ITipoPagamentoRepository, TipoPagamentoRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();

            //Services
            services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<ITipoPagamentoService, TipoPagamentoService>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            return services;
        }

    }
}

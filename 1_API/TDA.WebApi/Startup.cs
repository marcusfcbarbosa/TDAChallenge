using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Infra.Context;
using TDA.Infra.Repositorys;
using TDA.WebApi.InfraEstructure;

namespace TDA.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ChallengeContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            registrandoDependencias(services);
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            DocumentacaoApi(services);
        }


        public void registrandoDependencias(IServiceCollection services)
        {

            #region"Contexto"
            services.AddScoped<ChallengeContext, ChallengeContext>();
            #endregion

            #region"Handlers"
            // services.AddScoped<MedicoHandler, MedicoHandler>();
            // services.AddScoped<EspecialidadeHandler, EspecialidadeHandler>();
            #endregion

            #region"Repositórios"
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            #endregion
        }
        public void DocumentacaoApi(IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllParametersInCamelCase();
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Docs", Version = "v1" });

            });
            services.AddSwaggerDocumentation();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "swagger");
            });
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

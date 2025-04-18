using CreditosApi.Entities;
using CreditosApi.Services;

namespace CreditosApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            // configure DI for application services
            services.AddScoped<ICM_Credito_materialesServices, CM_Credito_materialesServices>();
            services.AddScoped<ICM_Detalle_deuda_credito_materialesServices, CM_Detalle_deuda_credito_materialesServices>();
            services.AddScoped<ICM_Ctasctes_credito_materialesServices, CM_ctasctes_credito_materialesService>();
            services.AddScoped<ICM_Cate_deuda_creditoServices, CM_Cate_deuda_creditoServices>();
            services.AddScoped<IBadecServices, BadecServices>();
            services.AddScoped<ICM_UVAServices, CM_UVAServices>();




            //
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseStaticFiles();
                app.UseStaticFiles(new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers
                           .Add("X-Copyright", "Copyright 2016 - JMA");
                    }
                });
            }

            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taskman API V1"); });

            app.UseRouting();
            // if (env.EnvironmentName == "Development")
            // {

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            Console.WriteLine(env.EnvironmentName);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VersionWebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            DependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void DependencyInjection(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddMvcCore().AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            #region Swagger

            services.AddSwaggerDocument(config =>
            {
                config.DocumentName = "v1";
                config.ApiGroupNames = new[] { "1" };
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Version WebAPI Sample";
                    document.Info.Description = "バージョン管理のサンプル画面";
                };
            });

            #endregion
            #region Versioning Sample

            services.AddSwaggerDocument(config =>
            {
                config.DocumentName = "v0";
                config.ApiGroupNames = new[] { "0" };
                config.PostProcess = document =>
                {
                    document.Info.Version = "v0";
                    document.Info.Title = "Version WebAPI Sample";
                    document.Info.Description = "バージョン管理のサンプル画面";
                };
            });

            #endregion

        }
    }
}

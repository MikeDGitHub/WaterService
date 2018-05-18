using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WaterService.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddCors(options => options.AddPolicy("AllowCors",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
            services.AddMvc();
            services.AddAuthorization();
            services
                .AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", (option) =>
                {
                    option.Authority = "http://127.0.0.1:5000";//identityserver4地址
                    option.RequireHttpsMetadata = false;//使用https
                    option.ApiName = "socialnetwork";//api scope
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCors("AllowCors");
            app.UseMvc();
        }
    }

}

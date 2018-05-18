using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OauthService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowCors",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
            services.AddMvc();
            //add identity server 4
            services
               .AddIdentityServer(options =>
               {
                   options.IssuerUri = "http://baidu.com";
               })
               .AddDeveloperSigningCredential()
                .AddInMemoryClients(InMemoryConfiguration.Clients())
                .AddInMemoryApiResources(InMemoryConfiguration.ApiResources())
                .AddInMemoryIdentityResources(InMemoryConfiguration.IdentityResources()); //check below
            //Inject the classes we just created
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();


            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.Authority = "http://127.0.0.1:5000";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "socialnetwork";
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseIdentityServer();
            app.UseAuthentication();
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowCors");
            app.Use((context, next) =>
            {
                var user = context.User;

                context.Response.StatusCode = user.Identity.IsAuthenticated ? 200 : 401;

                return next.Invoke();
            });
            app.UseMvc();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wishlist.Model;

namespace WebAPIApplication
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddAuthorization();
            services.AddMvc();
            
            //Add my own services
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddInstance<IDbConnectionFactory>(new PostgresConnectionFactory());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

			app.UseCookieAuthentication(options => 
			{
				options.AuthenticationScheme = "Cookie";
				options.LoginPath = new PathString("/account/login");
				options.LogoutPath = new PathString("/account/logout");
				options.AccessDeniedPath = new PathString("/account/login");
				options.AutomaticAuthenticate = true;
				options.AutomaticChallenge = true;
			});
			
			app.UseStaticFiles();
			
            app.UseMvc();
			
			
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}

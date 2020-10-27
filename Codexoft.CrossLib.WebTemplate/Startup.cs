using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Codexoft.CrossLib.WebTemplate.Data;
using VueCliMiddleware;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using Codexoft.CrossLib.WebTemplate.Middlewares;
using Codexoft.CrossLib.Architecture.Database;
using Codexoft.CrossLib.Architecture.Services.Containers;

namespace Codexoft.CrossLib.WebTemplate
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
            //auto mapper
            services.AddAutoMapper(typeof(Startup));

            //dbContext
            services.AddScoped<IAppDbContext, AppDbContext>();

            //dbServices
            services.AddScoped<WebServiceContainer>();

            //authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var secretKey = new SymmetricSecurityKey(Convert.FromBase64String(Configuration["Jwt:Key"]));
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = secretKey
                    };
                });

            services.AddHttpContextAccessor();
            services.AddTransient(x => x.GetService<IHttpContextAccessor>().HttpContext.User);

            //aspnet core default services
            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UserMyExceptionHandler(env);

            app.UseRouting();
            app.UseSpaStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = env.IsDevelopment() ? "ClientApp" : "dist";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }
            });
        }
    }
}

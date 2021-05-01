using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessDemo.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AWSServerlessDemo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            //var connString = GetRDSConnectionString();
            //var userRepo = new UserRepository(connString);
            //services.Add(new ServiceDescriptor(typeof(UserRepository), userRepo));
            //  var connString = GetPostgresConnectionString();


            var connString = Environment.GetEnvironmentVariable("DefaultConnection");
            var productRepo = new ProductsRepository(connString);
            services.Add(new ServiceDescriptor(typeof(ProductsRepository), productRepo));

            services.AddCors();
            services.AddControllers();


            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => {
                    options.IncludeErrorDetails = true;
                    options.Authority = Environment.GetEnvironmentVariable("Authority");
                    options.RequireHttpsMetadata = false;
                    options.Audience = "api1";
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidIssuer = Environment.GetEnvironmentVariable("Authority"),
                        //NameClaimType = JwtClaimTypes.Name,
                        //RoleClaimType = JwtClaimTypes.Role,
                    };
                });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome ServerlessDemo App");
                });
            });
        }

        public static string GetPostgresConnectionString()
        {

            var dbname = "productsdb";

            if (string.IsNullOrEmpty(dbname)) return null;

            var username = "postgres";
            var password = "sasa";
            var hostname = "10.0.2.8";
            var port = "5432";


            return $"User ID={username};Password={password};Host={hostname};Port={port};Database={dbname};";
        }

        public static string GetRDSConnectionString()
        {

            var dbname = "registration";

            if (string.IsNullOrEmpty(dbname)) return null;

            var username = "postgres";
            var password = "sasasasa";
            var hostname = "hexquotedb.cmb1qrijkowb.eu-central-1.rds.amazonaws.com";
            var port = "5432";


            return $"User ID={username};Password={password};Host={hostname};Port={port};Database={dbname};";
        }
    }
}

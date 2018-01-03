using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Semkovo.Api.Infrastructure.Extensions;
using AutoMapper;
using Semkovo.Data;
using Microsoft.EntityFrameworkCore;
using Semkovo.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Semkovo.Api
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
            services.AddDbContext<SemkovoDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddAuthentication(sharedOptions =>
            //{
            //    sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddAzureAdB2CBearer(options => Configuration.Bind("AzureAdB2C", options));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<SemkovoDbContext>()
            .AddDefaultTokenProviders();

            services.AddAutoMapper();

            services.AddDomainServices();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}

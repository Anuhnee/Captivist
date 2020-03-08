using System.Text;
using Captivist.Core.Models;
using Captivist.Core.Services;
using Captivist.Infrastructure;
using Captivist.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CaptivistApp
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

            services.AddHttpContextAccessor();

            // adding DbContext
            services.AddDbContext<AppDbContext>();

            // adding identity services
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            // add JWT support
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = false,
            //            ValidateAudience = false,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //        };
            //    });

            services.AddScoped<IUserService, UserService>();

            // add the DbInitializer service
            services.AddScoped<DbInitializer>();

            // add your repositories and services
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ICommentService, CommentService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            dbInitializer.Initialize();
        }
    }
}

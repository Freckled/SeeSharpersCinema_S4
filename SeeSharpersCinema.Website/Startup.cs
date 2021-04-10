using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeeSharpersCinema.Data.Models.Repository;
using SeeSharpersCinema.Models.Database;
using SeeSharpersCinema.Models.Repository;

namespace SeeSharpersCinema.Website
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
            services.AddControllersWithViews();
            services.AddDbContext<CinemaDbContext>(opts =>
            {
                opts.UseSqlServer(
                    Configuration["ConnectionStrings:CinemaConnection"]);
            });
            services.AddScoped<IMovieRepository, EFMovieRepository>();
            services.AddTransient<IPlayListRepository, EFPlayListRepository>();
            services.AddTransient<IReservedSeatRepository, EFReservedSeatRepository>();
            services.AddTransient<INoticeRepository, EFNoticeRepository>();
            services.AddTransient<IReviewRepository, EFReviewRepository>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CinemaDbContext>();

            services.Configure<IdentityOptions>(
                options =>
                {
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredUniqueChars = 5;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 8;
                });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            UserAndRoleDataInitializer.SeedRoles(roleManager);
            UserAndRoleDataInitializer.SeedUsers(userManager);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

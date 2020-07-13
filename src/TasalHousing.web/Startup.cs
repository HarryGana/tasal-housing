using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasalHousing.Data.DatabaseContexts.ApplicationDbContext;
using TasalHousing.Data.DatabaseContexts.AuthenticationDbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UserManager;
using TasalHousing.Data.Entities;
//using TasalHousing.Data.Entities.ApplicationUser;


namespace TasalHousing.Web
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

            services.AddDbContextPool<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection"),

               sqlServerOptions => {
                  sqlServerOptions.MigrationsAssembly("TasalHousing.Data");
                }
            ));

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthenticationDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
            // services.AddDbContextPool<ApplicationDbContext>(options => options.)

            services.AddDbContextPool<AuthenticationDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("AuthenticationConnection"),

                 sqlServerOptions => {
                   sqlServerOptions.MigrationsAssembly("TasalHousing.Data");
                 } 
            ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider iservice)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            MigrateDatabaseContext(iservice);
            CreateDefaultRolesAndUsers(iservice).GetAwaiter().GetResult();

        }
//This one is to make sure any migration you do after hosting the application on cloud would automatically migrate..he wil show you this in the next video i thnk
        public void MigrateDatabaseContext(IServiceProvider iservice)
        {
            var authenticationdbcontext = iservice.GetRequiredService<AuthenticationDbContext>();
            authenticationdbcontext.Database.Migrate();

            var applicationdbcontext = iservice.GetRequiredService<ApplicationDbContext>();
            applicationdbcontext.Database.Migrate();
        }
        
        public async Task CreateDefaultRolesAndUsers(IServiceProvider iservice)
        {
            string[] roles = new string[] {"SystemAdminstrator", "Agent", "User"};
            var userEmail = "admin@tasalhousing.com";
            var userPassword = "TassallahGana@2020";

            var roleManager = iservice.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (var role in roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole{ Name = role});
                }
            }

            var userManager = iservice.GetRequiredService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByEmailAsync(userEmail);
            if (user is null)
            {
                user = new ApplicationUser
                {
                    Email = userEmail,
                    UserName = userEmail,
                    EmailConfirmed = true,
                    PhoneNumber = "+2348032158734",
                    PhoneNumberConfirmed = true,
                };

                await userManager.CreateAsync(user, userPassword);
                await userManager.AddToRolesAsync(user, roles);
            }

        
        }

    }
}

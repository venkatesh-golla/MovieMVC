using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieMVC.Data_Access.Data;
using MovieMVC.Data_Access.Repository;
using MovieMVC.Data_Access.Repository.IRepository;
using Microsoft.AspNetCore.Identity.UI.Services;
using MovieMVC.Utilities;
using Microsoft.Extensions.Options;
using System;
using Stripe;

namespace MovieMVC
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<EmailOptions>(Configuration);
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            services.AddAuthentication().AddFacebook(Options =>
            {
                Options.AppId = "333683497633384";
                Options.AppSecret = "c00935c7339aafd997d4e48baf68cb42";
            });
            services.AddAuthentication().AddGoogle(Options =>
            {
                Options.ClientId = "751195025717-5adnb8in7lnt2j7u8s3m4kfhvmcrk3or.apps.googleusercontent.com";
                Options.ClientSecret = "JuKo-M7cTXXbf_rcW9pExeqP";
            });
            services.AddSession(Options =>
            {
                Options.IdleTimeout = TimeSpan.FromMinutes(30);
                Options.Cookie.HttpOnly = true;
                Options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["Secretkey"];
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

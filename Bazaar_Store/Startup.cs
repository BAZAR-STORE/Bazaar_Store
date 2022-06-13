
using Bazaar_Store.Data;
using Bazaar_Store.Models;
using Bazaar_Store.Models.Interface;
using Bazaar_Store.Models.Service;
using Bazaar_Store.Models.Serviece;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bazaar_Store
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddControllers();



            services.AddDbContext<BazaarDbcontext>(options =>
            {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
            services.AddTransient<ICompany, CompanyServieces>();
            services.AddTransient<IProduct, ProductServieces>();
            services.AddTransient<ICategory, CategoryServieces>();
            services.AddTransient<IUserService, IdentityuserServices>();
            services.AddTransient<IUser, UsersService>();


            services.AddIdentity<Admin, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                // There are other options like this
            })
             .AddEntityFrameworkStores<BazaarDbcontext>();
            services.ConfigureApplicationCookie(option =>
            {
                option.AccessDeniedPath = "/Auth/Index";
            });
            services.AddAuthentication();
            services.AddAuthorization();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute("default", "{controller=Accounts}/{action=Index}");
                endpoints.MapControllerRoute("default", "{controller=Company}/{action=Index}");
                endpoints.MapControllerRoute("default", "{controller=Category}/{action=Index}");

            });
            app.UseStaticFiles();
        }
    }
}

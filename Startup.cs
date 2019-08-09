using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ormawa.Models;
using Ormawa.Services;
using Ormawa.BusinessModel;
using IPB.Ldap;

namespace Ormawa
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        private static readonly LoggerFactory DbLoggerFactory =
            new LoggerFactory(new[] {
                new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
            });

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookieAuthenticationOptions>(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddMvc();
            services.AddMvcJQueryDataTables();

            var ldapSettings = Configuration.GetSection("Ldap");
            services.AddTransient<ILdapServer>(s => new LdapServer(ldapSettings["Host"], int.Parse(ldapSettings["Port"]), ldapSettings["BaseDn"], ldapSettings["Filter"]));


            var connectionString = Configuration.GetSection("ConnectionStrings");
            services.AddDbContext<DBINTEGRASI_MASTER_BAYUPPKU2Context>(options => options.UseSqlServer(connectionString["DefaultConnection"]).UseLoggerFactory(DbLoggerFactory));

            services.AddTransient<Combobox>();
            services.AddTransient<UploadRepo>();
            services.AddTransient<OrganisasiOrmawaRepo>();
            services.AddTransient<DaftarAnggotaRepo>();
            services.AddTransient<DaftarPrestasiRepo>();
            services.AddTransient<PublikasiRepo>();
            services.AddTransient<IFileService, FileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Default/Error");
            }

            app.UseStaticFiles();
            app.UseMvcJQueryDataTables();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Default}/{action=Index}/{id?}");
            });

        }
    }
}

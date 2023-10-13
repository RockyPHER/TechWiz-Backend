using Microsoft.EntityFrameworkCore;
using TechWiz.Database;
using TechWiz.Middleware;
using TechWiz.Repositories;
using TechWiz.Services;

namespace TechWiz 
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(
                    connectionString: Configuration.GetConnectionString("DefaultConnection"),
                    serverVersion: new MySqlServerVersion(new Version(8, 1, 0)),
                    builder =>
                    {
                        builder.MigrationsAssembly("Techwiz");
                        builder.EnableRetryOnFailure();
                    }
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
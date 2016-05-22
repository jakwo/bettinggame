using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using bettinggame.data;
using bettinggame.data.Repositories;
using bettinggame.api.Properties;
using System.Security.Claims;

namespace bettinggame.api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");

            builder.AddEnvironmentVariables();
            Configuration = builder.Build().ReloadOnChanged("appsettings.json");
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Run dnx ef migrations add MyFirstMigration to scaffold a migration to create the initial set of tables for your model.
            //Run dnx ef database update to apply the new migration to the database.Because your database doesn’t exist yet, it will be created for you before the migration is applied.

            //http://stackoverflow.com/questions/31097933/setting-the-sql-connection-string-for-asp-net-5-web-app-in-azure
            services.AddEntityFramework()
                 .AddDbContext<BettingGameContext>(
                     options =>
                     {
                         options.UseSqlServer(Configuration["Data:tourneytips_db:ConnectionString"],
                                b => b.MigrationsAssembly("bettinggame.api"));
                     });

            services.AddScoped<IMatchesRepository, MatchesRepository>();
            services.AddScoped<ITipsRepository, TipsRepository>();

            services.Configure<Auth0Settings>(options =>
            {
                options.Domain = Configuration["Auth0:Domain"];
                options.ClientId = Configuration["Auth0:ClientId"];
            });

            services.AddCors();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            BettingGameDataInitializer.Seed(app.ApplicationServices.GetService<BettingGameContext>());

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            var settings = app.ApplicationServices.GetService<IOptions<Auth0Settings>>();

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                Audience = settings.Value.ClientId,
                Authority = $"https://{settings.Value.Domain}",
                Events =
                                      new JwtBearerEvents
                                      {
                                          OnAuthenticationFailed =
                                                  context => Task.FromResult(0),
                                          OnTokenValidated = context =>
                                          {
                                              var claimsIdentity = context.Ticket.Principal.Identity as ClaimsIdentity;
                                              claimsIdentity?.AddClaim(new Claim("id_token",
                                                  context.Request.Headers["Authorization"][0].Substring(context.Ticket.AuthenticationScheme.Length + 1)));

                                              // OPTIONAL: you can read/modify the claims that are populated based on the JWT
                                              // claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, claimsIdentity.FindFirst("name").Value));
                                              return Task.FromResult(0);
                                          }
                                      }
            });

            app.UseMvc();
        }
    }
}

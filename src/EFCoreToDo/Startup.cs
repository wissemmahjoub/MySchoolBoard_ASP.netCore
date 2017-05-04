
using System;
using EFCoreToDo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading.Tasks;
using EFCoreToDo.Repository;

namespace EFCoreToDo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("vcap-local.json", optional: true)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            string vcapServices = Environment.GetEnvironmentVariable("VCAP_SERVICES");
            if (vcapServices != null)
            {
                dynamic json = JsonConvert.DeserializeObject(vcapServices);
                if (json.elephantsql != null)
                {
                    try
                    {
                        Configuration["elephantsql:0:credentials:uri"] = json.elephantsql[0].credentials.uri;
                    }
                    catch (Exception ex)
                    {
                        // Failed to read postgres uri, invalid credentials?
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }

            // parse the uri into relevant parts
            string uri = Configuration.GetSection("elephantsql:0:credentials:uri").Value;
            if (!string.IsNullOrEmpty(uri))
            {
                try
                {
                    string username = (uri.Split('/')[2]).Split(':')[0];
                    string password = (uri.Split(':')[2]).Split('@')[0];
                    string hostname = (uri.Split('@')[1]).Split(':')[0];
                    string portnum = (uri.Split(':')[3]).Split('/')[0];
                    string database = (uri.Split('/')[3]);
                    Configuration["elephantsql:0:credentials:username"] = username;
                    Configuration["elephantsql:0:credentials:password"] = password;
                    Configuration["elephantsql:0:credentials:hostname"] = hostname;
                    Configuration["elephantsql:0:credentials:portnum"] = portnum;
                    Configuration["elephantsql:0:credentials:database"] = database;
                }
                catch (Exception ex)
                {
                    // Failed to parse postgres uri, invalid credentials
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime.. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });


            ElephantSQLCredentials creds = new ElephantSQLCredentials()
            {
                Database = Configuration.GetSection("elephantsql:0:credentials:database").Value,
                Password = Configuration.GetSection("elephantsql:0:credentials:password").Value,
                Port = Configuration.GetSection("elephantsql:0:credentials:portnum").Value,
                Server = Configuration.GetSection("elephantsql:0:credentials:hostname").Value,
                Username = Configuration.GetSection("elephantsql:0:credentials:username").Value
            };
            var appName = "ASP.NET Core RC2 ToDo Sample";

            var connection = string.Format(@"Server={0};Port={1};User Id={2};Password={3};Database={4};"
                + "SSL Mode=Require;Application Name={5}",
                creds.Server, creds.Port, creds.Username, creds.Password, creds.Database, appName);

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ToDoDbContext>(options => options.UseNpgsql(connection));

            // Add framework services.
            services.AddMvc();
            services.AddScoped <IMarkRepository, IMarkRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
          
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var context = ((ToDoDbContext)app.ApplicationServices.GetService(typeof(ToDoDbContext)));
            // ******************************************
            //******************************************
            context.Database.Migrate();
            context.PopulateDatabase();

            app.UseStaticFiles();
            app.UseCors("CorsPolicy");

            app.UseMvc(routes =>
            {   // routes.MaphttpRoute(
            //name: "Default Api Route",
            //        template: "api/{controller}/{id}",new {id =RouteParameter.Optional }
            //    );


            routes.MapRoute(
                    name: "api",
                    template: "api/{controller=Db}/{action=Index}/{id?}"
                );


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }

        // Entry point for the application 
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}

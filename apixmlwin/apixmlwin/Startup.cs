using Microsoft.EntityFrameworkCore;
using apixmlwin.Context;
using Microsoft.AspNetCore.Builder;
using apixmlwin.Services;
using apixmlwin.Repository;

namespace apixmlwin;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container


    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = Environment.GetEnvironmentVariable("AWS_WIN");
        string conectioncrm = Environment.GetEnvironmentVariable("CRM");

        //string coneccion = Environment.GetEnvironmentVariable("CRM")!;
        //var connectionString = Configuration.GetConnectionString("awsWin");
        //var conectioncrm = Configuration.GetConnectionString("CRM");

        services.AddDbContext<awsEquifaxContext>(options =>
        options.UseNpgsql(connectionString));

        services.AddDbContext<crmwinContext>(options =>
       options.UseSqlServer(conectioncrm));

        services.AddControllers();
        //services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddTransient<ISeguimiento, segServicio>();
        
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}
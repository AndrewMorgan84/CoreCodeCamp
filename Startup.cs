using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace CoreCodeCamp
{
    public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<CampContext>();
      services.AddScoped<ICampRepository, CampRepository>();
      services.AddAutoMapper(Assembly.GetExecutingAssembly());

      services.AddApiVersioning(opt => {
          opt.AssumeDefaultVersionWhenUnspecified = true;
          opt.DefaultApiVersion = new ApiVersion(3, 0);
          opt.ReportApiVersions = true;
      });

      services.AddMvc(opt => opt.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(cfg =>
      {
        cfg.MapControllers();
      });
    }
  }
}

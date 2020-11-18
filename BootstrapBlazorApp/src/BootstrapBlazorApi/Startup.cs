using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DataLibrary
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
            services.AddControllers();
            //services.AddAutoMapper();
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            var infos = myAssembly.DefinedTypes.Where(x => x.FullName.StartsWith("BootstrapBlazorApi.Adapter"));
            //var infos2 = myAssembly.DefinedTypes.Where(x => x.FullName.StartsWith("LineClass.Models.BusinessDBAccess.Interface"));
            foreach (TypeInfo item in infos)
            {
                if (item.IsClass)
                {
                    var IsInterFace = infos.Where(x => x.Name == "I" + item.Name).FirstOrDefault();
                    if (IsInterFace != null)
                    {
                        services.AddScoped(IsInterFace, item);
                    }
                }

            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

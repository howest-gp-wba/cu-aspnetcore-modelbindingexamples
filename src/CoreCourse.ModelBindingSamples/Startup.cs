using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreCourse.ModelBindingSamples
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app
                .UseStaticFiles()
                .UseMvc(routes =>
                    {
                        routes
                        .MapRoute(
                            name: "Home-actionWithRoute",
                            template: "Home/ActionWithPrimitives/{firstName}/{surName}/{nickName}/{legs:int}/{isCaptain:bool}/{age:int?}",
                            defaults: new { controller = "Home", action = "ActionWithPrimitives" }
                        )
                        .MapRoute(
                            name: "default",
                            template: "{controller}/{action}/{id?}",
                            defaults: new { controller = "Home", action = "Index" }
                        );
                    })
                ;
        }
    }
}

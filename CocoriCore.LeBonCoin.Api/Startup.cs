using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Ninject;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ninject;
using Ninject.Extensions.ContextPreservation;
using Ninject.Extensions.NamedScope;

namespace CocoriCore.LeBonCoin.Api
{
    public class Startup
    {
        //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });*/
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var kernel = CreateKernel();
            var unitOfWorkFactory = kernel.Get<IUnitOfWorkFactory>();

            app.Use(async (ctx, next) =>
            {
                if (!ctx.Request.Path.Value.StartsWith("/api"))
                {
                    ctx.Response.ContentType = "text/html";
                    await ctx.Response.WriteAsync(File.ReadAllText("CocoriCore.LeBonCoin.Api/page2.html"));
                }
                else
                    await next();
            });

            app.Use(async (ctx, next) =>
            {
                using (var unitOfWork = unitOfWorkFactory.NewUnitOfWork())
                {
                    await unitOfWork.Resolve<ApplicationMiddleware>().InvokeAsync(ctx, next);
                }
            });

            // TODO restreindre CORS à l'environnement de développement
            // app.UseCors(MyAllowSpecificOrigins);

            // else
            // {
            //     app.UseExceptionHandler("/Error");
            //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //     //app.UseHsts();
            // }

            // //app.UseHttpsRedirection();
            // //app.UseStaticFiles();
            // //app.UseCookiePolicy();
        }



        public static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(new NamedScopeModule());
            kernel.Load(new ContextPreservationModule());

            kernel.Load(new CocoricoreNinjectModule());
            kernel.Load(new WebApiModule());

            return kernel;
        }
    }
}
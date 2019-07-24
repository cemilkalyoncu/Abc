using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Busines.Abstract;
using Abc.Northwind.Busines.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.MvcWebUI.Middlewares;
using Abc.Northwind.MvcWebUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Abc.Northwind.MvcWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                /*Hata yönetimi middleveyir*/
                app.UseDeveloperExceptionPage();
            }
            /*Statik dosya ulaşımı için örn: Bootsrap,Jquery*/
            // app.UseStaticFiles(); -->direct wwroot altına bakıyor.
            // statick dosya tutar ve ek olarak directory wwrot dısında da dosyaya ulaşır.
            app.UseFileServer();
            /*Custom middleveyir yazdım*/
            app.UseNodeModules(env.ContentRootPath);
            /*MVC Route için*/
            app.UseSession();
            app.UseMvcWithDefaultRoute();
        }
    }
}

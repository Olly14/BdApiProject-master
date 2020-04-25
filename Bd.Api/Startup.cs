using AutoMapper;
using Bank.Data.Infrastructure.Repository;
using Bd.Api.Data;
using Bd.Api.Data.Infrastructure.Persistence;
using Bd.Api.Data.Infrastructure.Persistence.DropDownListsRepository;
using Bd.Api.Data.Infrastructure.Persistence.OrderItemsRepo;
using Bd.Api.Data.Infrastructure.Persistence.OrdersRepo;
using Bd.Api.Data.Infrastructure.Persistence.ProductsRepo;
using Bd.Api.Data.Infrastructure.Repository.AppUserRepositiry;
using Bd.Api.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bd.Api.Data.Infrastructure.Repository.OrderItemRepository;
using Bd.Api.Data.Infrastructure.Repository.OrderRepository;
using Bd.Api.Data.Infrastructure.Repository.ProductRepository;
using Bd.Api.Domain;
using Bd.Api.ModelMappers.AppUserMappers;
using Bd.Api.ModelMappers.DropDownListsMappers;
using Bd.Api.ModelMappers.OrderMappers;
using Bd.Api.ModelMappers.ProductMappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bd.Api
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

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OrderDtoAutoMapperProfile());
                mc.AddProfile(new AppUserDtoAutoMapperProfile());
                mc.AddProfile(new ProductDtoAutoMapperProfile());
                mc.AddProfile(new DropDownListsDtoAutoMapperProfile());
                
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);



            services.AddDbContext<BdContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BdConnectionString"), b => b.MigrationsAssembly("Bd.Api"));
            });



            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IUnitOfWork<AppUser>, UnitOfWorkAppUserRepo>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork<Product>, UnitOfWorkProductRepo>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>()

;        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

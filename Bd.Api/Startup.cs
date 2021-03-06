using AutoMapper;
using Bank.Data.Infrastructure.Repository;
using Bd.Api.Data;
using Bd.Api.Data.Infrastructure.Persistence;
using Bd.Api.Data.Infrastructure.Persistence.AdministrationRepo;
using Bd.Api.Data.Infrastructure.Persistence.AppUsersRepo;
using Bd.Api.Data.Infrastructure.Persistence.DropDownListsRepo;
using Bd.Api.Data.Infrastructure.Persistence.DropDownListsRepository;
using Bd.Api.Data.Infrastructure.Persistence.OrderHistoryRepo;
using Bd.Api.Data.Infrastructure.Persistence.OrderItemsRepo;
using Bd.Api.Data.Infrastructure.Persistence.OrdersRepo;
using Bd.Api.Data.Infrastructure.Persistence.PricesRepo;
using Bd.Api.Data.Infrastructure.Persistence.ProductsRepo;
using Bd.Api.Data.Infrastructure.Repository.Administrations;
using Bd.Api.Data.Infrastructure.Repository.AppUserRepositiry;
using Bd.Api.Data.Infrastructure.Repository.AppUserRepository;
using Bd.Api.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bd.Api.Data.Infrastructure.Repository.OrderHistoryRepository;
using Bd.Api.Data.Infrastructure.Repository.OrderItemRepository;
using Bd.Api.Data.Infrastructure.Repository.OrderRepository;
using Bd.Api.Data.Infrastructure.Repository.PricesRepository;
using Bd.Api.Data.Infrastructure.Repository.ProductRepository;
using Bd.Api.DbConfigurations;
using Bd.Api.Domain;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;



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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {   
                        // base-address of your identityserver
                        //options.Authority = "https://localhost:44316/";
                        //options.Authority = "https://localhost:44314/";

                        options.Authority = "https://myidp.azurewebsites.net";


                        options.RequireHttpsMetadata = true;

                        // name of the API resource
                        options.ApiName = "Bd.Web.Api";
                    });



            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new OrderDtoAutoMapperProfile());
            //    mc.AddProfile(new OrderHistoryDtoAutoMapperProfile());
            //    mc.AddProfile(new AppUserDtoAutoMapperProfile());
            //    mc.AddProfile(new ProductDtoAutoMapperProfile());
            //    mc.AddProfile(new DropDownListsDtoAutoMapperProfile());

            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddHttpContextAccessor();

            services.AddApplicationInsightsTelemetry();

            //services.AddDbContextPool<BdContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("BdConnectionString"),
            //        b => b.MigrationsAssembly("Bd.Api.Data"));
            //});

            //services.AddDbContextPool<UserIdentityDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("UserIdentityDbConnectionString"),
            //        b => b.MigrationsAssembly("Bd.Api.Data"));
            //});


            services.AddDbContext<BdContext>(options =>
            {
                options.UseSqlServer(Configuration[DbConfig.ConnectionStringKeyAppUser.Replace("__", ":")]);
            });

            services.AddDbContext<UserIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration[DbConfig.ConnectionStringKeyIdp.Replace("__", ":")]);
            });



            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IUnitOfWork<AppUser>, UnitOfWorkAppUserRepo>();
            services.AddScoped<IUserRepository, UserIdentityRepository>();
            services.AddScoped<IUnitOfWork<User>, UnitOfWorkUserRepo>();

            services.AddScoped<IUserClaimRepository, UserClaimRepository>();
            services.AddScoped<IUnitOfWork<UserClaim>, UnitOfWorkUserClaim>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork<Product>, UnitOfWorkProductRepo>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork<Order>, UnitOfWorkOrderRepo>();
            services.AddScoped<IOrderHistoryRepository, OrderHistoryRepository>();
            services.AddScoped<IOrderItemHistoryRepository, OrderItemHistoryRepository>();
            services.AddScoped<IUnitOfWork<OrderHistory>, UnitOfWorkOrderHistoryRepo>();
            services.AddScoped<IUnitOfWork<OrderItem>, UnitOfWorkOrderItemRepo>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IPricesRepository, PricesRepository>();
            services.AddScoped<IUnitOfWork<Prices>, UnitOfWorkPricesRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

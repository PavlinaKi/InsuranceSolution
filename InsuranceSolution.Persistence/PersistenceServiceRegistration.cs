using Microsoft.Extensions.Logging;

namespace InsuranceSolution.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddDbContext<InsuranceSolutionDbContext>(options =>
            //     options.UseSqlServer(configuration.GetConnectionString("SQLConnectionString"))
            //     .EnableSensitiveDataLogging()
            //.LogTo(Console.WriteLine, LogLevel.Information));
            services.AddDbContext<InsuranceSolutionDbContext>(options =>
            options
            //.UseLazyLoadingProxies()
            .UseSqlServer(configuration.GetConnectionString("SQLConnectionString"))
            //.UseNpgsql(configuration.GetConnectionString("PostgreConnectionString"))
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information));


             services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPolicyRepository, PolicyRepository>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IInsurerRepository, InsurerRepository>();

            return services;
        }
    }
}

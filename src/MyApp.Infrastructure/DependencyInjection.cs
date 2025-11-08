using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Infrastructure.Persistence;
using MediatR;
using MyApp.Infrastructure.Repository;
using MyApp.Domain.Interfaces;
using MyApp.Application.CQRS.CQ_ItemCategory.Commands; // Reference your Application layer for MediatR

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Register DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // 2. Register generic repository
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));

            // 3. Register MediatR for CQRS handlers in Application layer
            services.AddMediatR(cfg =>
            {
                // Scans the assembly containing Application layer handlers
                cfg.RegisterServicesFromAssembly(typeof(AddCategoryCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateAddCategoryCommand).Assembly);
            });

            // 4. (Optional) Add other infrastructure services here
            // services.AddScoped<IEmailService, EmailService>();
            // services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

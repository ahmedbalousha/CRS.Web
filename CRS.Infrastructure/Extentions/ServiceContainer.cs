using CRS.Infrastructure.AutoMapper;
using CRS.Infrastructure.Services;
using CRS.Infrastructure.Services.Advertisements;
using CRS.Infrastructure.Services.CarCompanies;
using CRS.Infrastructure.Services.Cars;
using CRS.Infrastructure.Services.Contracts;
using CRS.Infrastructure.Services.Notifications;
using CRS.Infrastructure.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Infrastructure.Extentions
{
    public static class ServiceContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICarCompanyService, CarCompanyService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IAdvertisementService, AdvertisementService>();
            services.AddTransient<IContractService, ContractService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<INotificationService, NotificationService>();



            return services;
        }
    }
}

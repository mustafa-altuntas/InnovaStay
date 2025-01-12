using InnovaStay.Data.Abstract;
using InnovaStay.Data.Concrete;
using InnovaStay.Data.Repositories;
using InnovaStay.Entity.Constant;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Data
{
    public static class ServiceRegistiration
    {
        public static void AddDataService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
            {
                opts.UseNpgsql(configuration.GetConnectionString(AppsettingConstants.PostgreDb));
            });


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<ISubscribeRepository, SubscribeRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();

        }
    }
}

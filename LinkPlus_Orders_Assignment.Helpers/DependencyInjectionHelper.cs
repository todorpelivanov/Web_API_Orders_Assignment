using LinkPlus_Orders_Assignment.DataAccess;
using LinkPlus_Orders_Assignment.DataAccess.Implementations;
using LinkPlus_Orders_Assignment.DataAccess.Interfaces;
using LinkPlus_Orders_Assignment.Domain.Entities;
using LinkPlus_Orders_Assignment.Services.Implementation;
using LinkPlus_Orders_Assignment.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkPlus_Orders_Assignment.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OrdersDbContext>(x =>
            x.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Order>, OrderRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}

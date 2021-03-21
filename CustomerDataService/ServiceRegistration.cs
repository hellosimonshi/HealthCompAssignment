using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerDataService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Entities;

namespace CustomerDataService
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerDataService<Customer>, CustomerDataService>();
        }
    }
}

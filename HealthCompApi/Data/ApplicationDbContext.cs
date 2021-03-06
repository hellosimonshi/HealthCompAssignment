using HealthCompApi.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace HealthCompApi.Data
{
    //    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }

    //public class IdentityDbContext : ApiAuthorizationDbContext<ApplicationUser>
    //{
    //    public IdentityDbContext(DbContextOptions options,
    //                             IOptions<OperationalStoreOptions> operationalStoreOptions)
    //            : base(options, operationalStoreOptions)
    //    {
    //    }
    //}
}

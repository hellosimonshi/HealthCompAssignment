using HealthCompApi.Data;
using HealthCompApi.Models;
using IdentityModel;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthCompApi.Services
{
    public class ClaimsFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClaimsFactory(
                    UserManager<ApplicationUser> userManager,
                    IOptions<IdentityOptions> optionsAccessor,
                    ApplicationDbContext context) : base(userManager, optionsAccessor)
        {
            _context = context;
            _userManager = userManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            identity.AddClaims(roles.Select(role => new Claim(JwtClaimTypes.Role, role)));
            //identity.AddClaim(new IdentityResource
            //{
            //    Name = "roles",
            //    DisplayName = "Roles",
            //    UserClaims = { JwtClaimTypes.Role }
            //});

            return identity;
        }
    }
}

using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Threading.Tasks;

namespace HealthCompApi
{
    public class MyProfileService : IProfileService
    {
        public MyProfileService()
        { }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //get role claims from ClaimsPrincipal 
            var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);

            //add your role claims 
            context.IssuedClaims.AddRange(roleClaims);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            // await base.IsActiveAsync(context);
            return Task.CompletedTask;
        }
    }
}

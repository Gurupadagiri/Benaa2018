using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Benaa2018.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            SBSDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<SBSDbContext>();
            //UserManager<IdentityUser> userManager = applicationBuilder.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();
            //// Add Lender
            //var user = new IdentityUser("Miroslav Mikus");
            //await userManager.CreateAsync(user, "%Miro1");
            context.SaveChanges();
        }
    }
}

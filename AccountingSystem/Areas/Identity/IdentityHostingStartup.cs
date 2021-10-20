using System;
using AccountingSystem.Data;
using AccountingSystem.Model.System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AccountingSystem.Areas.Identity.IdentityHostingStartup))]
namespace AccountingSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AccountingSystemContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AccountingSystemContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AccountingSystemContext>();
            });
        }
    }
}
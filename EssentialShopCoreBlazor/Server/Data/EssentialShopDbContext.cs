using EssentialShopCoreBlazor.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialShopCoreBlazor.Server.Data
{
    public class EssentialShopDbContext : IdentityDbContext
    {
        public EssentialShopDbContext(DbContextOptions<EssentialShopDbContext> options) : base(options)
        {

        }

        public DbSet<IdentityUsersModel> IdentityUsersModel { get; set; }
    }
}

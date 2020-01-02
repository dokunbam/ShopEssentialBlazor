using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EssentialShopCoreBlazor.Shared
{
    public class IdentityUsersModel : IdentityUser
    {
        public string BusinessName { get; set; }
    }
}

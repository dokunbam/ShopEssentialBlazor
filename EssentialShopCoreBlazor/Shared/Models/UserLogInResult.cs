using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialShopCoreBlazor.Shared
{
    public class UserLogInResult
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}

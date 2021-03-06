#pragma checksum "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\Auth\Register.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8bfe058bcb6497dbde936f20c054a73a712e2886"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace EssentialShopCoreBlazor.Client.Auth
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\_Imports.razor"
using EssentialShopCoreBlazor.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\_Imports.razor"
using EssentialShopCoreBlazor.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\_Imports.razor"
using EssentialShopCoreBlazor.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/register")]
    public partial class Register : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 8 "C:\Users\DELL\Desktop\TestEssentialShopFolder\New Project\EssentialShopCore\EssentialShopCoreBlazor\Client\Auth\Register.razor"
       

    private ApplicationUserModel RegisterModel = new ApplicationUserModel();
    private bool ShowErrors;
    private IEnumerable<string> Errors;

    private async Task HandleRegistration()
    {
        ShowErrors = false;

        var result = await AuthService.Register(RegisterModel);

        if (result.Successful)
        {
            NavigationManager.NavigateTo("/login");
        }
        else
        {
            Errors = result.Errors;
            ShowErrors = true;
            Console.WriteLine(Errors);
        }

        System.Console.WriteLine(RegisterModel);
    }




#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthService AuthService { get; set; }
    }
}
#pragma warning restore 1591

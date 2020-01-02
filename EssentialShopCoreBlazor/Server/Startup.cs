using EssentialShopCoreBlazor.Server.Controllers;
using EssentialShopCoreBlazor.Server.Data;
using EssentialShopCoreBlazor.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;

namespace EssentialShopCoreBlazor.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        readonly string EssentialAllowSpecificOrigins = "essentialAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EssentialShopDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUsersModel, IdentityRole>()
                .AddEntityFrameworkStores<EssentialShopDbContext>()
                .AddDefaultTokenProviders();

            //services.AddIdentityCore<IdentityUsersModel>()
            //    .AddEntityFrameworkStores<EssentialShopDbContext>()
            //    .AddDefaultTokenProviders();


            //services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<EssentialShopDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtIssuer"],
                    ValidAudience = Configuration["JwtAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"]))
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy(EssentialAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("https://localhost:44365", "https://localhost:44398")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("myPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //});

            services.AddScoped<AccountAuthController>();
           

            services.AddMvc().AddNewtonsoftJson();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }


       // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseCors(EssentialAllowSpecificOrigins);
            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseCors(builder =>
            //builder.WithOrigins("https://localhost:44365", "https://localhost:44398").AllowAnyHeader().AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}

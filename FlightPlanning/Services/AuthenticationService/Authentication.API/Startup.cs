using System;
using System.Text;
using Microsoft.OpenApi.Models;
using Authentication.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Authentication.API.Repositories;
using Authentication.API.Handlers.Base;
using Microsoft.Extensions.Configuration;
using Authentication.API.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Authentication.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(o => {
                o.Configuration = Configuration.GetValue<string>("CacheSettings:ConnectionString");
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Authentication.API", Version = "v1" });
            });

            services.Configure<JWTManagementModel>(Configuration.GetSection("jwtManagement"));

            var authToken = Configuration.GetSection("jwtManagement").Get<JWTManagementModel>();

            var signInKey = Encoding.UTF8.GetBytes(authToken.SignInKey);

            var scheme = authToken.Scheme;

            services.AddAuthentication(o => {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(scheme, c => {
                c.RequireHttpsMetadata = false;
                c.SaveToken = true;
                c.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(signInKey),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = false,
                    RequireExpirationTime = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenHandler, Authentication.API.Handlers.TokenHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Authentication.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
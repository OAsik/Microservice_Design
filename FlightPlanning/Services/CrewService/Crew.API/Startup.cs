using System;
using MassTransit;
using System.Text;
using Crew.API.Models;
using CrewService.Application;
using Microsoft.OpenApi.Models;
using EventBus.Messages.Common;
using Crew.API.EventBusConsumers;
using CrewService.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Crew.API
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
            services.Configure<JWTManagementModel>(Configuration.GetSection("jwtManagement"));

            var authToken = Configuration.GetSection("jwtManagement").Get<JWTManagementModel>();

            var signInKey = Encoding.UTF8.GetBytes(authToken.SignInKey);

            services.AddAuthentication(o => {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(c => {
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

            services.AddAplicationServices();

            services.AddInfrastructureServices(Configuration);

            services.AddMassTransit(config => {
                config.AddConsumer<CrewChecoutConsumer>();
                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);
                    cfg.UseHealthCheck(ctx);
                    cfg.ReceiveEndpoint(EventBusConstants.CrewCheckoutQueue, config => {
                        config.ConfigureConsumer<CrewChecoutConsumer>(ctx);
                    });
                });
            });

            services.AddMassTransitHostedService();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<CrewChecoutConsumer>();

            services.AddControllers();

            //Sample token for testing purposes. Do not forget to set validation period of your tokens in real-time scenarios
            //eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJSYXp6IiwianRpIjoiaHFrYjtUOTAifQ.2gskbTHFeNwCpJa6vzmBZ077GZXHI4yN2RC3vZRc3K0

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Crew.API", Version = "v1" });
                //No need to set below definitions if you are using tools like Postman for your authorization required requests
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter your access token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                          new string[] {}
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crew.API v1"));
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
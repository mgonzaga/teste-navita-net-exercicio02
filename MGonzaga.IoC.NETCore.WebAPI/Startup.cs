using AutoMapper;
using MGonzaga.IoC.NETCore.BussinessLayer.Impl;
using MGonzaga.IoC.NETCore.BussinessLayer.Interfaces;
using MGonzaga.IoC.NETCore.BussinessLayer.Validations.Impl;
using MGonzaga.IoC.NETCore.BussinessLayer.Validations.Interfaces;
using MGonzaga.IoC.NETCore.Data.Context;
using MGonzaga.IoC.NETCore.Data.Repositories;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Base;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using MGonzaga.IoC.NETCore.Proxys.Email.Impl;
using MGonzaga.IoC.NETCore.Proxys.Email.Interfaces;
using MGonzaga.IoC.NETCore.WebAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
namespace MGonzaga.IoC.NETCore.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, builder =>
                {
                    builder
                        .WithOrigins("*")
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                        .Build();
                });
               
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "https://localhost:50887",
                    ValidAudience = "https://localhost:50887",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")),

                };
            });
            //services.AddAutoMapper();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMvc();
            services.AddControllers();
            // Add configuration for DbContext
            // Use connection string from appsettings.json file
            var dbContextAssembly = typeof(SysDataBaseContext).GetTypeInfo().Assembly;
            services.AddDbContext<SysDataBaseContext>(options =>
            {
                options.UseSqlServer(Configuration["DatabaseConnectionString"], opt =>
                {
                    opt.CommandTimeout(30);
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Patrimônio",
                    Description = "API REST para gerenciamento de patrimônio de uma empresa",
                    Contact = new OpenApiContact
                    {
                        Name = "Marcio Cesar Gonzaga",
                        Email = "marcio.c.gonzaga@gmail.com"
                    }
                });
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Coloque neste campo o texto 'Bearer' seguido por um espaço e o Token retornado na rota de autenticação",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddScoped(typeof(IDbContext), typeof(SysDataBaseContext));
            
            //Usuarios
            services.AddScoped(typeof(IUserBussinessClass), typeof(UserBussinessClass));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUserValidation), typeof(UserValidation));

            //Marcas
            services.AddScoped(typeof(IMarcaBussinessClass), typeof(MarcaBussinessClass));
            services.AddScoped(typeof(IMarcaRepository), typeof(MarcaRepository));
            services.AddScoped(typeof(IMarcaValidation), typeof(MarcaValidation));

            //Patrimonio
            services.AddScoped(typeof(IPatrimonioBussinessClass), typeof(PatrimonioBussinessClass));
            services.AddScoped(typeof(IPatrimonioRepository), typeof(PatrimonioRepository));
            services.AddScoped(typeof(IPatrimonioValidation), typeof(PatrimonioValidation));
            
            services.AddScoped(typeof(IEmailSend), typeof(EmailSend));
            

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Patrimônio V1");
                c.ConfigObject.DeepLinking = true;
                c.ConfigObject.DocExpansion = Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseMiddleware(typeof(ErrorsMiddleware));

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

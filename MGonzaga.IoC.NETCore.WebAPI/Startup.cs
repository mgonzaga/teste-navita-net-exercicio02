using AutoMapper;
using MGonzaga.IoC.NETCore.BussinessLayer.Impl;
using MGonzaga.IoC.NETCore.BussinessLayer.Interfaces;
using MGonzaga.IoC.NETCore.Data.Context;
using MGonzaga.IoC.NETCore.Data.Repositories;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Base;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using MGonzaga.IoC.NETCore.Proxys.Email.Impl;
using MGonzaga.IoC.NETCore.Proxys.Email.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
                            .AllowCredentials()
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Add configuration for DbContext
            // Use connection string from appsettings.json file
            var dbContextAssembly = typeof(SysDataBaseContext).GetTypeInfo().Assembly;
            services.AddDbContext<SysDataBaseContext>(options =>
            {
                options.UseMySql(Configuration["DatabaseConnectionString"], opt => {
                    opt.CommandTimeout(30);
                });
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info{
                    Version = "v1",
                        Title = "MGonzaga.IoC.NETCore.WebAPI",
                        Description = "A simple example ASP.NET Core Web API",
                        TermsOfService = "None",
                        Contact = new Contact
                        {
                            Name = "Marcio Cesar Gonzaga",
                            Email = "marcio.c.gonzaga@gmail.com",
                            Url = "https://twitter.com/spboyer"
                        },
                        License = new License
                        {
                            Name = "Use under LICX",
                            Url = "https://example.com/license"
                        }
                });
                c.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Please enter into field the word 'Bearer' following by space and JWT",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                { "Bearer", Enumerable.Empty<string>() },
            });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //services.ConfigureSwaggerGen(option => {
            //    option.CustomSchemaIds((type) => type.ToString()
            //       .Replace("[", "_")
            //       .Replace("]", "_")
            //       .Replace(",", "-")
            //       .Replace("`", "_"));
            //});

            services.AddScoped(typeof(IDbContext), typeof(SysDataBaseContext));
            services.AddScoped(typeof(IUserBussinessClass), typeof(UserBussinessClass));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IEmailSend), typeof(EmailSend));
            services.AddScoped(typeof(ILinksBussinessClass), typeof(LinksBussinessClass));
            services.AddScoped(typeof(ILinksRepository), typeof(LinksRepository));
            



        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "MGonzaga.IoC.NETCore.WebAPI V1");
                c.ConfigObject.DeepLinking = true;
                c.ConfigObject.DocExpansion = Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None;
#if DEBUG
                c.ConfigObject.DisplayOperationId = true;
#endif
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

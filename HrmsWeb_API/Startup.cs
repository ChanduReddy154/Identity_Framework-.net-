using Hrms.Business.BusinessInterfaces;
using Hrms.Business.Implementations;
using Hrms.Repository.Implementations;
using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using HRMS.API.Auth;
using HRMS.Communication.Email;
using HRMS.Communication.SMS;
using HRMS.Utilities;
using HrmsWeb_API.ActionFilters;
using HrmsWeb_API.EmailSend;
using HrmsWeb_API.Report_Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace HrmsWeb_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<HrmsDBContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging(), ServiceLifetime.Scoped);
            services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging(), ServiceLifetime.Scoped);
            services.AddDbContext<HrmsIdentityContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging(), ServiceLifetime.Scoped);
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<CustomFilterAttribute>();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<HrmsIdentityContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("LicenceStatus",
                                  policy => policy.Requirements.Add(new StatusRequirement("Active")));
                //policy => policy.RequireClaim("Status", new string[] { "Active", "OnHold" }));
            });
            services.AddSingleton<IAuthorizationHandler, StatusHandler>();
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            options.TokenLifespan = TimeSpan.FromMinutes(5));

            services.Configure<IdentityOptions>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                opt.Lockout.MaxFailedAccessAttempts = 3;

            });
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            // services.Configure<EmailConfiguration>(Configuration.GetSection("MailSettings"));
            var emailConfig = Configuration.GetSection("EmailConfiguration")
              .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddTransient<IMailService,MailService>();
            services.AddTransient<IEmployeeBusiness, EmployeeBusiness>();
            services.AddTransient<IEmployeeRepository, EmployeeRepostitory>();
            services.AddTransient<IDepartmentBusiness, DepartmentBusiness>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IAccountsBusiness, AccountsBusiness>();
            services.AddTransient<IAccountsRepository, AccountsRepository>();
            services.AddTransient<IAddressInterface, AddressBusiness>();
            services.AddTransient<IAddressRepositoryInterface, AddressRepository>();
            services.AddTransient<IReportInterface, ReportService>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ISendSMSNotification, SendSMSNotification>();
            services.AddTransient<IPersonalInfoInterface, PersonalInfoBusiness>();
            services.AddTransient<IPersonalRepoInterface, PersonalInfoRepository>();


            //JWT Configuration
            var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);

            services.AddSingleton<IJwtTokenManager, JwtTokenManager>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ClockSkew = TimeSpan.FromMinutes(60)
                };
            });

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HrmsWeb_API", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "HrmsWeb_API.xml");


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
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
                    Array.Empty<string>()
                }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HrmsWeb_API v1"));
            }
            app.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "application/json";
                var response = new ApiResponse(context.HttpContext.Response.StatusCode, "Unauthorized Access", null, true);
                var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                await context.HttpContext.Response.WriteAsync(json);
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(op => op.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            Task.Run(() => this.CreateRoles(roleManager)).Wait();

        }
        private async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (string rol in this.Configuration.GetSection("Roles").Get<List<string>>())
            {
                if (!await roleManager.RoleExistsAsync(rol))
                {
                    await roleManager.CreateAsync(new IdentityRole(rol));
                }
            }
        }
    }
}

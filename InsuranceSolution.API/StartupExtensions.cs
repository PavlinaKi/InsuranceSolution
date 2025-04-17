using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace InsuranceSolution.API
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
            this WebApplicationBuilder builder)
        {

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddHealthChecks();

            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.DefaultApiVersion = ApiVersion.Default;
            });

            //// Configure HSTS options
            //if (builder.Environment.IsProduction())
            //{
            //    builder.Services.AddHsts(options =>
            //    {
            //        options.Preload = true;
            //        // options.IncludeSubDomains = true;
            //        options.MaxAge = TimeSpan.FromDays(90);
            //    });
            //}
            builder.Services.AddControllers();
            builder.Services.AddProblemDetails(options =>
            {
                options.CustomizeProblemDetails = context =>
                {
                    context.ProblemDetails.Instance = $@"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
                    context.ProblemDetails.Extensions.Add("requestId", context.HttpContext.TraceIdentifier);
                    Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>().Activity;
                    context.ProblemDetails.Extensions.Add("traceId", activity.Id);
                };
            }
);
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "InsuranceSolution API",
                    Description = "InsuranceSolution API",
                    Contact = new OpenApiContact
                    {
                        Name = "Contact : PavlinaKi Github",
                        Url = new Uri("https://github.com/PavlinaKi")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License : About CC Licenses",
                        Url = new Uri("https://creativecommons.org/share-your-work/cclicenses/")
                    }
                });
                //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter: Bearer {your JWT token}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[] { }
                    }
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    policy.WithOrigins("http://localhost:7080")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddHealthChecks();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwtSettings = builder.Configuration.GetSection("JwtSettings");
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])),
                    RoleClaimType = ClaimTypes.Role
                };
            });

            ////Singleton Redis ConnectionMultiplexer
            //builder.Services.AddOutputCache(options =>
            //{
            //    options.AddBasePolicy(builder =>
            //        builder.Expire(TimeSpan.FromSeconds(10)));
            //    options.AddPolicy("Expire30s", builder =>
            //        builder.Expire(TimeSpan.FromSeconds(30)));
            //    options.AddPolicy("Expire2m", builder =>
            //        builder.Expire(TimeSpan.FromMinutes(2)));
            //    options.AddPolicy("Expire5m", builder =>
            //        builder.Expire(TimeSpan.FromMinutes(5)));
            //});
            //builder.Services.AddSingleton<IConnectionMultiplexer>(sp => { var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("RedisCacheConnectionString"), true); return ConnectionMultiplexer.Connect(configuration); });
            //builder.Services.AddStackExchangeRedisOutputCache(options => { options.ConnectionMultiplexerFactory = async () => { var multiplexer = builder.Services.BuildServiceProvider().GetRequiredService<IConnectionMultiplexer>(); return await Task.FromResult(multiplexer); }; });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.ShowCommonExtensions();
                x.ShowExtensions();
                x.DisplayRequestDuration();
                x.EnableDeepLinking();
                x.InjectStylesheet("/swagger-ui/custom.css");
            });


            //if (app.Environment.IsProduction())
            //{
            //    app.UseHsts();
            //}

            // app.UseHttpsRedirection();
            app.UseExceptionHandler();
            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSerilogRequestLogging();
            app.MapControllers();
            //app.UseOutputCache();
            return app;
        }

        public static async Task MigrateDBAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<InsuranceSolutionDbContext>();
                if (context != null)
                {
                    //await context.Database.EnsureCreatedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                //add logging here later on
            }
        }
        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<InsuranceSolutionDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                //add logging here later on
            }
        }
    }
}

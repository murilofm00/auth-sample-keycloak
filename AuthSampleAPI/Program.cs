using AuthSampleAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace AuthSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                // KeyCloak
                c.CustomSchemaIds(type => type.ToString());
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "KEYCLOAK",
                    Type = SecuritySchemeType.OAuth2,
                    In = ParameterLocation.Header,
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(builder.Configuration["Jwt:AuthorizationUrl"]!),
                            TokenUrl = new Uri(builder.Configuration["Jwt:TokenUrl"]!),
                            Scopes = new Dictionary<string, string> { }
                        }
                    },
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                                                {securityScheme, new string[] { }}
                                            });
            });

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.Authority = builder.Configuration["Jwt:Authority"];
                    options.Audience = builder.Configuration["Jwt:Audience"];
                    options.RequireHttpsMetadata = false;

                    options.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = c =>
                        {
                            c.NoResult();

                            c.Response.StatusCode = 500;
                            c.Response.ContentType = "text/plain";

                            return c.Response.WriteAsync(c.Exception.ToString());
                        }
                    };
                });

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSingleton<AtividadesService>();
            builder.Services.AddSingleton<ParticipacaoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.OAuthClientId(builder.Configuration["Jwt:ClientId"]!);
                    c.OAuthClientSecret(builder.Configuration["Jwt:ClientSecret"]!);
                    c.OAuthRealm(builder.Configuration["Jwt:Realm"]!);
                    c.OAuthAppName("KEYCLOAK");
                });
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

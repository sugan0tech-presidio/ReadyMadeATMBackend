using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReadyMadeATMBackend.Context;
using ReadyMadeATMBackend.Interfaces;
using ReadyMadeATMBackend.Models;
using ReadyMadeATMBackend.Repos;
using ReadyMadeATMBackend.Services;

namespace ReadyMadeATMBackend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
        }); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddHttpContextAccessor();

        #region Context

        builder.Services.AddDbContext<ReadyMadeATMContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Banking;User Id=sa;Password=Sugan@123;TrustServerCertificate=True;");
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        );

        #endregion

        #region Repos

        builder.Services.AddScoped<IBaseRepo<User>, UserRepo>();
        builder.Services.AddScoped<IBaseRepo<Transaction>, TransactionRepo>();

        #endregion


        #region Services

        builder.Services.AddScoped<ITransactionService, TransactionService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IUserService, UserService>();

        #endregion

        #region Cors

        builder.Services.AddCors(opts =>
        {
            opts.AddPolicy("AllowAll",
                corsPolicyBuilder => { corsPolicyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
        });

        #endregion

        #region AuthConfig

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey("This is the dummy key which has to be a bit long for the 512. which should be even more longer for the passing"u8.ToArray())
                };
            });
        builder.Services.AddAuthorization();

        #endregion

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
using MakeYourTrip_API.Models;
using MakeYourTrip_API.Repositories.AdminRepo;
using MakeYourTrip_API.Repositories.AuthRepo;
using MakeYourTrip_API.Repositories.FestivalRepo;
using MakeYourTrip_API.Repositories.PackageRepo;
using MakeYourTrip_API.Repositories.PlaceRepo;
using MakeYourTrip_API.Repositories.ProfileRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IRepoRegister, RepoRegister>();
        builder.Services.AddScoped<IRepoLogin, RepoLogin>();
        builder.Services.AddScoped<IRepoFestival,RepoFestival>();
        builder.Services.AddScoped<IRepoAddPlace, RepoAddPlace>();
        builder.Services.AddScoped<IRepoPlace, RepoPlace>();
        builder.Services.AddScoped<IRepoPackage, RepoPackage>();
        builder.Services.AddScoped<IRepoCoupon, RepoCoupon>();
        builder.Services.AddScoped<IRepoPackageBooking, RepoPackageBooking>();
        builder.Services.AddScoped<IRepoProfile, RepoProfile>();
        builder.Services.AddScoped<IRepoAdmin, RepoAdmin>();


        builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

        //For Authorize in swagger
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
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

        //Newtonsoft loop haandling
        builder.Services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


        //JWT
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
             .AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience = builder.Configuration["JWT:ValidAudience"],
                     ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                 };
             });

        //CORS Policy

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MyPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("MyPolicy");

        app.UseAuthentication();

        app.UseAuthorization();
        app.Use(async (context, next) =>
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var user = context.User;
            }
            await next.Invoke();
        });


        app.MapControllers();

        app.Run();
    }
}
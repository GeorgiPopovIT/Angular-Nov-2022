using CloudinaryDotNet;
using GorgesMusic.Core.Files;
using GorgesMusic.Core.Songs;
using GorgesMusic.Core.Users;
using GorgesMusic.Data;
using GorgesMusic.Data.Models;
using GorgesMusic.Data.Seed;
using GorgesMusicBackend;
using GorgesMusicBackend.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
Account account = new(
    "daxn3ngly",//builder.Configuration["Cloudinary:CloudName"],
    builder.Configuration["Cloudinary:ApiKey"],
    builder.Configuration["Cloudinary:ApiSecret"]);


// Add services to the container.
builder.Services.AddDbContext<GorgesMusicDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;
            })
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<GorgesMusicDbContext>();

Cloudinary cloudinary = new(account);
//cloudinary.Api.Secure = true;

var jwtSettingsConfiguration = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettingsConfiguration);

var jwtSettings = jwtSettingsConfiguration.Get<JwtSettings>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            ValidateIssuer = false,
            ValidateAudience = true
        };
    });


builder.Services.AddAuthorization();

builder.Services.AddMemoryCache();

builder.Services.AddResponseCaching();


builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(cloudinary);
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GorgesMusicDbContext>();

    Seeder.SeedData(dbContext);

    //SeedAdmin.SeedAdministrator(scope.ServiceProvider);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(policy => policy.AllowAnyHeader()
            .AllowAnyMethod().AllowAnyOrigin());

app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.MapSongEndpoints();

app.Run();

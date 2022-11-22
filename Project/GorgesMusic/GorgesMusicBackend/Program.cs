using CloudinaryDotNet;
using GorgesMusic.Core.Files;
using GorgesMusic.Core.Songs;
using GorgesMusic.Data;
using GorgesMusic.Data.Models;
using GorgesMusic.Data.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Account account = new(
    builder.Configuration["Cloudinary:CloudName"],
    builder.Configuration["Cloudinary:ApiKey"],
    builder.Configuration["Cloudinary:ApiSecret"]);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<GorgesMusicDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<GorgesMusicDbContext>();

Cloudinary cloudinary = new Cloudinary(account);
//cloudinary.Api.Secure = true;


//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//});

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(cloudinary);
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<IFileService, FileService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GorgesMusicDbContext>();
    //var cloudinaryService = scope.ServiceProvider.GetRequiredService<Cloudinary>();

    Seeder.SeedData(dbContext);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader()
            .AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using BillingPOC.BLL.Implementations;
using BillingPOC.Core.Confihurations;
using BillingPOC.Core.Entities;
using BillingPOC.Core.Interfaces.Repositories;
using BillingPOC.Core.Interfaces.Services;
using BillingPOC.DAL.Data;
using BillingPOC.DAL.UnitOfWork;
using BillingPOC.Flow.Implmentations;
using BillingPOC.Flow.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Register DbContext and Identity
var connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<User, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Register configuration settings
var jwtSettings = new JwtSettings();
configuration.GetSection("JwtSettings").Bind(jwtSettings);
builder.Services.AddSingleton(jwtSettings);

var smtpSettings = new SmtpSettings();

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddSingleton(smtpSettings);

// JWT Configuration
var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Register other services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserFlow, UserFlow>();

builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<IBillFlow, BillFlow>();

builder.Services.AddControllers().AddJsonOptions(x =>
                  x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

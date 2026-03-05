
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using Scraplan_dotnet.Data;
using Scraplan_dotnet.Global.Enums;
using Scraplan_dotnet.Repositiry.IServices;
using Scraplan_dotnet.Repositiry.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScrapDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICareerService,CareersService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IStateService,StateService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IIssueService, IssueService>();
builder.Services.AddScoped<IRateService, RateService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<IOrderLogService, OrderLogService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IIssueDetailService,IssueDetailService>();
builder.Services.AddScoped<IFileService, FileService>();


//NpgsqlConnection.GlobalTypeMapper.MapEnum<RoleEnum>();



var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecurityKey"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Scraplan API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter JWT token as: Bearer {your token}",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
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
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new string[] {}
        }
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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


















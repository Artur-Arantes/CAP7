using System.Text;
using AutoMapper;
using Fiap.Desafio.Api.Data;
using Fiap.Desafio.Api.Data.Repositories;
using Fiap.Desafio.Api.Dtos;
using Fiap.Desafio.Api.Models;
using Fiap.Desafio.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddEnvironmentVariables();


#region DB
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseMySQL(connectionString).EnableSensitiveDataLogging(true));
#endregion
#region repositories and Services

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
builder.Services.AddScoped<IMeasureRepository, MeasureRepository>();
builder.Services.AddScoped<IResourceIndexRepository, ResourceIndexRepository>();
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<IMeasurementDataService, MeasurementDataService>();
builder.Services.AddScoped<IIndexService, IndexService>();
builder.Services.AddScoped<IAlertStatusRepository, AlertStatusRepository>();


#endregion
#region mapper

var mapperConfig = new AutoMapper.MapperConfiguration(
    c =>
    {
        c.AllowNullCollections = true;
        c.AllowNullDestinationValues = true;
        c.CreateMap<AddUserDto, UserModel>();
        c.CreateMap<LoginDto, UserModel>();
        c.CreateMap<AddUserDto, PersonModel>();
        c.CreateMap<AddMeasureDto, RecordMeasurementModel>();
        c.CreateMap<AddIndexDto, ResourceIndexModel>()
            .ForMember(dest => dest.IndexMinimum, opt => opt.MapFrom(src => src.Min))
            .ForMember(dest => dest.IndexNormal, opt => opt.MapFrom(src => src.Normal))
            .ForMember(dest => dest.IndexMaximum, opt => opt.MapFrom(src => src.Max))
            .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => src.ResourceId))
            .ForMember(dest => dest.Resource, opt => opt.MapFrom(src => new ResourceModel
            {
                Id = src.ResourceId,
                Name = src.Name,
                UnityMeasure = src.UnityOfMeasure
            }));

    }
);
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion
#region jwt

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting(); 
app.MapControllers();
app.UseAuthorization();

app.Run();

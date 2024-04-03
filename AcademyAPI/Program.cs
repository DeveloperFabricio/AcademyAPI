using Academy.Application.Commands.CreateInstructorCommand;
using Academy.Application.Commands.CresteSportCommand;
using Academy.Application.Commands.CresteStudentCommand;
using Academy.Application.Commands.LoginInstructorCommand;
using Academy.Application.Commands.PaymentStudentCommand;
using Academy.Application.Consumers;
using Academy.Application.DTO_s;
using Academy.Application.Email;
using Academy.Application.Options;
using Academy.Application.Queries.GetInstructorQuery;
using Academy.Application.Queries.GetSportQuery;
using Academy.Application.Queries.GetStudentQuery;
using Academy.Application.Validators;
using Academy.Core.Entities;
using Academy.Core.Interface;
using Academy.Core.Services;
using Academy.Infrasctructure.Auth;
using Academy.Infrasctructure.MessageBus;
using Academy.Infrasctructure.Payments;
using Academy.Infrasctructure.Persistence;
using Academy.Infrasctructure.Persistence.Repositories;
using AcademyAPI.Filters;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

string chaveSecreta = "7aa3ef07-9ecc-43b3-aa53-60dfcfa58721";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var webMailOptions = builder.Configuration.GetSection("WebMailOptions").Get<WebMailOptions>();

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Gym - API", Version = "v1" });

    var securitySchems = new OpenApiSecurityScheme
    {
        Name = "JWT Autenticação",
        Description = "Entre com o JWT Bearer Token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    x.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchems);
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securitySchems, new string[] { } }
            });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "Gym",
        ValidAudience = "Gym",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta))
    };
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CreateInstructorCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CreateStudentCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CreateSportCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(LoginInstructorCommand)));
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(PaymentStudentCommand)));

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IValidator<InstructorCreateDTO>, InstructorCreateDTOValidator>();

builder.Services.AddTransient<IRequestHandler<GetStudentQuery, Student>, GetStudentQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetInstructorQuery, Instructor>, GetInstructorQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetSportQuery, Sport>, GetSportQueryHandler>();

builder.Services.AddHttpClient();

builder.Services.Configure<WebMailOptions>(builder.Configuration.GetSection("WebMailOptions"));
builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMqOptions"));

builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<ISportRepository, SportRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IMessageBusService, MessageBusService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));

builder.Services.AddHostedService<PaymentApprovedConsumer>();
builder.Services.AddHostedService<SendEmailConsumerService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gym.API v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

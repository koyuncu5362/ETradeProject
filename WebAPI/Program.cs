using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Abstract;
using Business.Concrete;
//using Business.DependencyResolvers.Autofac;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.DependencyResolvers;
using Business.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});
builder.Services.AddControllers();
builder.Services.AddCors();
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//This is new Code
builder.Host.UseServiceProviderFactory
    (services => new AutofacServiceProviderFactory())
  .ConfigureContainer<ContainerBuilder>
  (builder => { builder.RegisterModule(new AutofacBusinessModule()); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureCustomExceptionMiddleware();
//app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());//new code
app.UseHttpsRedirection();

//new code
app.UseAuthentication();
//new code
app.UseAuthorization();

app.MapControllers();

app.Run();
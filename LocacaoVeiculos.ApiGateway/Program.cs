using LocacaoVeiculos.ApiGateway.Config;
using Microsoft.IdentityModel.Tokens;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Eureka;
using Ocelot.Provider.Polly;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
//builder.Configuration.AddOcelotWithSwaggerSupport(builder.Environment);

var authenticationProviderKey = "kCJGhD7ArRdWVvzQARhMSgzmDdeySObw";

builder.Services.AddAuthentication()
    .AddJwtBearer(authenticationProviderKey, x =>
    {
        x.Authority = "http://localhost:5001";

        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

// Configure ocelot
builder.Services.AddOcelot(builder.Configuration).AddEureka().AddPolly();

//builder.Services.AddSwaggerForOcelot(builder.Configuration);

// Add or register service discovery to your application
builder.Services.AddServiceDiscovery(o => o.UseEureka());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseOcelot();
app.UseAuthorization();

//app.UseSwaggerForOcelotUI(options =>
//{
//    options.PathToSwaggerGenerator = "/swagger/docs";
//    options.ReConfigureUpstreamSwaggerJson = AlterUpstream.AlterUpstreamSwaggerJson;
//}).UseOcelot().Wait();

app.MapControllers();

app.UseOcelot().Wait();

app.Run();

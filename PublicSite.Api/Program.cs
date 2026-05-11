using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi;
using PublicSite.Api.Middleware;
using PublicSite.Application.Common.DependencyInjection;
using PublicSite.Application.Services;
using PublicSite.Infrastructure.Common.DependencyInjection;
using PublicSite.Infrastructure.Common.Initialization;
using PublicSite.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddPostgreSqlDB(builder.Configuration, typeof(DBContext).Assembly.FullName!);

builder.Services.Configure<SmtpSetting>(
    builder.Configuration.GetSection("SmtpSetting"));

string corsName = builder.Configuration["Cors:Policy"]!;
var corsOrigin = builder.Configuration.GetSection("Cors:Origin").Get<string[]>();
var corsHeaders = builder.Configuration.GetSection("Cors:Header").Get<string[]>();

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "JWT Token Authentication API",
        Description = ".NET 10 Web API"
    });
     
    // Configuration API KEY
    swagger.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "Enter APiKey",
        Type = SecuritySchemeType.ApiKey,
        Name = "X-API-KEY",
        In = ParameterLocation.Header,
        Scheme = "apiKeyScheme"
    });

    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer schema",
    });

    swagger.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = [],
        [new OpenApiSecuritySchemeReference("ApiKey", document)] = []
    });
    
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsName, policy =>
    {
        policy.WithOrigins(corsOrigin ?? [])
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
        //.WithHeaders(corsHeaders ?? Array.Empty<string>());
    });
});


var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}
//Auto migration au démarrage
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DBContext>();
    db.Database.Migrate();
}
app.UseCors(corsName); 

app.UseSwagger();
//app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectManager.Api v1");
});

// initialisation
using (var scope = app.Services.CreateScope())
{
    var initializer = new AppInitializer(scope.ServiceProvider);
    await initializer.InitializeAsync();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(builder.Configuration["Upload:StoragePath"]!),
    RequestPath = "/uploads"
});

app.Run();

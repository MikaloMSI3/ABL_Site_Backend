using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PublicSite.Api.Middleware;
using PublicSite.Application.Common.DependencyInjection;
using PublicSite.Application.Services;
using PublicSite.Infrastructure.Common.DependencyInjection;
using PublicSite.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddPostgreSqlDB(builder.Configuration, typeof(DBContext).Assembly.FullName!);

builder.Services.Configure<SmtpSetting>(
    builder.Configuration.GetSection("SmtpSetting"));

string corsName = builder.Configuration["Cors:Policy"]!;
var corsOrigin = builder.Configuration.GetSection("Cors:Origin").Get<string[]>();
var corsHeaders = builder.Configuration.GetSection("Cors:Header").Get<string[]>();

builder.Services.AddSwaggerGen();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
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

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(builder.Configuration["Upload:StoragePath"]!),
    RequestPath = "/uploads"
});

app.Run();

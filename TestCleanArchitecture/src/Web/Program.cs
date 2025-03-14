using TestCleanArchitecture.Application;
using TestCleanArchitecture.Infrastructure;
using TestCleanArchitecture.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyVaultIfConfigured(builder.Configuration);

// Add other layers services and dependencies
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

var app = builder.Build();

app.UseCors("AllowAll");

app.UseRouting();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

if (app.Environment.IsDevelopment())
{
    // Add swagger in development mode
    app.UseOpenApi();
    app.UseSwaggerUi();
    
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();

app.Run();

// TODO - Test API for Bank, Product, Payment and Account Controller
// TODO - Add Result for create and update operations for Bank
// TODO - Add Result for create and update operations for Bank
// TODO - Add validation for string types in create and update operations for Bank and Product

public partial class Program
{
}

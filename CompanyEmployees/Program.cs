var builder = WebApplication.CreateBuilder(args);
/*
 * WebApplicationBuilder main responsibilities:
 * -> Adding configuration to the project by using the builder.Configuration property
 * -> Registering services by using the builder.Services property
 * -> Logging configuration by using the builder.Logging property
 * -> Other IHostBuilder and IWebHostBuilder properties
 */

// Add services to the container.
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

//enable authorization middleware, allowing you to control access to different parts of your application based on user roles or policies.
app.UseAuthorization();

//registers all controller classes in the application with the framework's routing system, allowing them to handle incoming HTTP requests.
app.MapControllers();


app.Run();

using AspNetCoreRateLimit;
using CompanyEmployees.Extensions;
using CompanyEmployees.Presentation.ActionFilters;
using CompanyEmployees.Utility;
using Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using NLog;
using Service;
using Shared.DataTransfertObjects;


var builder = WebApplication.CreateBuilder(args);
/*
 * WebApplicationBuilder main responsibilities:
 * -> Adding configuration to the project by using the builder.Configuration property
 * -> Registering services by using the builder.Services property
 * -> Logging configuration by using the builder.Logging property
 * -> Other IHostBuilder and IWebHostBuilder properties
 */

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));



// Add Cors Services to the container => ServiceExtensions 
builder.Services.ConfigureCors();

// Add IIS services to the container => ServiceExtensions
builder.Services.ConfigureIISIntegration();

// Add Logger Services to the container => ServiceExtensions
builder.Services.ConfigureLoggerService();


// Add Repository Manager services to the container => ServiceExtensions
builder.Services.ConfigureRepositoryManager();

// Add Service Manager services to the container => ServiceExtensions 
builder.Services.ConfigureServiceManager();

// Add Sql Context to the container => ServiceExtensions
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.Configure<ApiBehaviorOptions>(
 options =>
 {
  options.SuppressModelStateInvalidFilter = true;
 }
);

//
builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();

builder.Services.AddScoped<ValidateMediaTypeAttribute>();

builder.Services.AddScoped<IEmployeeLinks, EmployeeLinks>();

builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureHttpCacheHeaders();
builder.Services.AddMemoryCache();

builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllers(
  config =>
  {
   config.RespectBrowserAcceptHeader = true;
   config.ReturnHttpNotAcceptable = true;
   config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
   config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
   {
    Duration = 120
   });
  })
 .AddXmlDataContractSerializerFormatters()
 .AddCustomCSVFormatters()
 .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

builder.Services.AddCustomMediaTypes();


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);


if (app.Environment.IsProduction())
 app.UseHsts();


// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();

//enables using static files for the request. If
// we don’t set a path to the static files directory, it will use a wwwroot
// folder in our project by default.
app.UseStaticFiles();

/*
 * The `UseForwardedHeaders` middleware in ASP.NET Core is used to handle HTTP headers modified or added by proxies
 * or load balancers in front of your web application. It allows your app to recognize and use headers
 * like `X-Forwarded-For`, `X-Forwarded-Proto`, and `X-Forwarded-Host` for proper request processing,
 * essential when deployed behind such infrastructure.
 * By specifying `ForwardedHeaders.All`, it ensures all forwarded headers are read and considered for incoming HTTP requests.
 */
app.UseForwardedHeaders( new ForwardedHeadersOptions
 {
  ForwardedHeaders = ForwardedHeaders.All
 });

app.UseIpRateLimiting();

// enable middleware to the pipeline to enable CORS.
app.UseCors("CorsPolicy");


app.UseResponseCaching();

app.UseHttpCacheHeaders();

//enable authorization middleware, allowing you to control access to different parts of your application based on user roles or policies.
app.UseAuthorization();

//registers all controller classes in the application with the framework's routing system, allowing them to handle incoming HTTP requests.
app.MapControllers();


app.Run();

NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter(){
 
 return new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
  .Services.BuildServiceProvider()
  .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
  .OfType<NewtonsoftJsonPatchInputFormatter>().First();
}

namespace CompanyEmployees.Extensions;

/*
 * An extension method is inherently a static method.
 * It accepts this as the firs parameter and this represents the data type of the objet which will be using that extension method.
 * It can be chained with other extension methods.
 */

public static class ServiceExtensions
{
    /*
     * the first thing we are going to do is to configure CORS.
     * CORS (Cross-Origin Resource Sharing) is mechanism to give or restrict access rights to applications from different domains.
     * To start we'll add a code that allows all request from any origins to access our API.
     * We should be more restrictive in production environnement => as restrictive as possible
     *
     * Instead of AllowAnyOrigin() (allows from any source)
     * we can use WithOrigins("http://localhost:5102") which allow requests only from that concrete source
     *
     * Instead of AllowAnyMethod() (allows from any method)
     * we can use WithMethods("POST", "GET") which allow requests only from that specific method
     *
     * Instead of AllowAnyHeader() (allows from any header)
     * we can use WithHeaders("accept", "content-type") which allow requests only from that specific header
     */

    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options => 
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader())
        );
}
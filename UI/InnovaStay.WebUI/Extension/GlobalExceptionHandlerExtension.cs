using Microsoft.AspNetCore.Diagnostics;

namespace InnovaStay.WebUI.Extension
{
    public static class GlobalExceptionHandlerExtension
    {
        public static void ExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionHandlerFeature.Error switch
                    {
                        HttpRequestException => 400,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                });
            });
        }
    }
}

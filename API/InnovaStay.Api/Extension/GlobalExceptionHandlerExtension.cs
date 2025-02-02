using InnovaStay.Business.Exceptions;
using InnovaStay.Dto.Dtos;
using Microsoft.AspNetCore.Diagnostics;
using System.Net.Mime;

namespace InnovaStay.Api.Extension
{
    public static class GlobalExceptionHandlerExtension
    {
        public static void ExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFactory = context.Features.Get<IExceptionHandlerFeature>();

                    int statusCode = exceptionHandlerFactory.Error switch
                    {
                        EntityNotFoundException => 404,
                        _ => 500
                    };

                    var result = ResponseDto<NoDataDto>.Fail(exceptionHandlerFactory.Error.Message, statusCode);

                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    context.Response.StatusCode = statusCode;
                    await context.Response.WriteAsJsonAsync(result);



                });
            });
        }

    }
}

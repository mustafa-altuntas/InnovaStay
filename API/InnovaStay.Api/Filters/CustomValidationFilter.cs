using InnovaStay.Dto.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InnovaStay.Api.Filters
{
    public class CustomValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            List<string> errors = context.ModelState
                    .Where(ms => ms.Value.Errors.Count > 0) // Hata olan alanları filtrele
                    .SelectMany(ms => ms.Value.Errors)     // Hata mesajlarını seç
                    .Select(e => e.ErrorMessage)           // Hata mesajını al
                    .ToList();                             // Listeye dönüştür

            var response = ResponseDto<NoDataDto>.Fail(errors, 400);

            context.Result = new OkObjectResult(errors);
        }
    }
}

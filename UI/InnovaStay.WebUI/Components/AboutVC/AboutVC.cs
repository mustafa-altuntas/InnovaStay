using InnovaStay.WebUI.Constant;
using InnovaStay.WebUI.Models.About;
using InnovaStay.WebUI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace InnovaStay.WebUI.Components.AboutVC
{
    public class AboutVC : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public AboutVC(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var responseMessage = await _httpClient.GetAsync($"{ApiConsumeUrlAddressConstants.About.GetByActive}");
            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto<DetailAboutVM>>(jsonData);

            return View(response!.Data);
        }
    }
}

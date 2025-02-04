using InnovaStay.WebUI.Constant;
using InnovaStay.WebUI.Models.DTOs;
using InnovaStay.WebUI.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace InnovaStay.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {

        private readonly HttpClient _httpClient;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var client = await _httpClient.GetAsync(ApiConsumeUrlAddressConstants.Service.Get);
            client.EnsureSuccessStatusCode();
            var jsonData = await client.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ResponseDto<List<ServiceVM>>>(jsonData);

            return View(response?.Data);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{ApiConsumeUrlAddressConstants.Service.Get}/{id}");
            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto<DetailServiceVM>>(jsonData);

            return View(response!.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateServiceVM model)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync(ApiConsumeUrlAddressConstants.Service.Create, model);

            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode(); // Eğer yanıt bir hata kodu içeriyorsa (ör. 404 Not Found, 500 Internal Server Error), şu şekilde bir HttpRequestException fırlatır: Exception mesajı, yanıt durum kodunu ve durum mesajını içerir.

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ResponseDto<List<ServiceVM>>>(jsonData);
            if (!response.Successful)
            {
                foreach (var error in response.Errors)
                    ModelState.AddModelError("", error);


                TempData["FailMessage"] = "Personel eklenemedi";
                return View(response?.Data);
            }

            TempData["SuccessMessage"] = "Personel başarıyle eklendi";
            return Redirect("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"{ApiConsumeUrlAddressConstants.Service.Delete}/{id}");
            try
            {
                responseMessage.EnsureSuccessStatusCode();
                return Ok(new { myMessage = "Personel başarıyle silindi" });
            }
            catch (Exception)
            {
                return BadRequest(new { myMessage = "Personel silinemedi" });
            }

        }

        public async Task<IActionResult> Update(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{ApiConsumeUrlAddressConstants.Service.Get}/{id}");
            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto<UpdateServiceVM>>(jsonData);

            return View(response!.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateServiceVM model)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync($"{ApiConsumeUrlAddressConstants.Service.Update}/{id}", model);

            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode(); // Eğer yanıt bir hata kodu içeriyorsa (ör. 404 Not Found, 500 Internal Server Error), şu şekilde bir HttpRequestException fırlatır: Exception mesajı, yanıt durum kodunu ve durum mesajını içerir

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto<string>>(jsonData);
            if (!response.Successful)
            {
                foreach (var error in response.Errors)
                    ModelState.AddModelError("", error);


                TempData["FailMessage"] = "Personel güncellenemedi";
                return View(response?.Data);
            }

            TempData["SuccessMessage"] = "Personel başarıyle güncellendi";
            return RedirectToAction("Index", "Service");
        }

    }
}

using InnovaStay.WebUI.Constant;
using InnovaStay.WebUI.Models.About;
using InnovaStay.WebUI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace InnovaStay.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {

        private readonly HttpClient _httpClient;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var client = await _httpClient.GetAsync(ApiConsumeUrlAddressConstants.About.Get);
            client.EnsureSuccessStatusCode();
            var jsonData = await client.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ResponseDto<List<AboutVM>>>(jsonData);

            return View(response?.Data);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{ApiConsumeUrlAddressConstants.About.Get}/{id}");
            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto<DetailAboutVM>>(jsonData);

            return View(response!.Data);
        }

        public async Task<IActionResult> GetByActive()
        {
            var responseMessage = await _httpClient.GetAsync($"{ApiConsumeUrlAddressConstants.About.GetByActive}");
            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto<DetailAboutVM>>(jsonData);

            return View(response!.Data);
        }

        public async Task<IActionResult> MarkAsActivate(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{ApiConsumeUrlAddressConstants.About.MakeAsActive}/{id}");
            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto<bool>>(jsonData);


            if (!response.Data)
            {
                //TempData["FailMessage"] = "Hakkımızda bilgisi  aktif edilemedi.";
                //return View(response?.Data);
            }

            TempData["SuccessMessage"] = "Hakkımızda bilgisi  başarıyle aktif edildi.";
            return RedirectToAction("Index","About");

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAboutVM model)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync(ApiConsumeUrlAddressConstants.About.Create, model);

            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode(); // Eğer yanıt bir hata kodu içeriyorsa (ör. 404 Not Found, 500 Internal Server Error), şu şekilde bir HttpRequestException fırlatır: Exception mesajı, yanıt durum kodunu ve durum mesajını içerir.

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ResponseDto<List<AboutVM>>>(jsonData);
            if (!response.Successful)
            {
                foreach (var error in response.Errors)
                    ModelState.AddModelError("", error);


                TempData["FailMessage"] = "Hakkımızda bilgisi  eklenemedi";
                return View(response?.Data);
            }

            TempData["SuccessMessage"] = "Hakkımızda bilgisi  başarıyle eklendi";
            return Redirect("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"{ApiConsumeUrlAddressConstants.About.Delete}/{id}");
            try
            {
                responseMessage.EnsureSuccessStatusCode();
                return Ok(new { myMessage = "Hakkımızda bilgisi  başarıyle silindi" });
            }
            catch (Exception)
            {
                return BadRequest(new { myMessage = "Hakkımızda bilgisi  silinemedi" });
            }

        }

        public async Task<IActionResult> Update(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{ApiConsumeUrlAddressConstants.About.Get}/{id}");
            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto<UpdateAboutVM>>(jsonData);

            return View(response!.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateAboutVM model)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync($"{ApiConsumeUrlAddressConstants.About.Update}/{id}", model);

            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode(); // Eğer yanıt bir hata kodu içeriyorsa (ör. 404 Not Found, 500 Internal Server Error), şu şekilde bir HttpRequestException fırlatır: Exception mesajı, yanıt durum kodunu ve durum mesajını içerir

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto<string>>(jsonData);
            if (!response.Successful)
            {
                foreach (var error in response.Errors)
                    ModelState.AddModelError("", error);


                TempData["FailMessage"] = "Hakkımızda bilgisi  güncellenemedi";
                return View(response?.Data);
            }

            TempData["SuccessMessage"] = "Hakkımızda bilgisi  başarıyle güncellendi";
            return RedirectToAction("Index", "About");
        }


    }
}

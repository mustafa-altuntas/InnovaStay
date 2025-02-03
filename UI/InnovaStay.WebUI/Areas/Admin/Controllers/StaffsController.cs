using InnovaStay.WebUI.Constant;
using InnovaStay.WebUI.Models.DTOs;
using InnovaStay.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace InnovaStay.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaffsController : Controller
    {
        private readonly HttpClient _httpClient;

        public StaffsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {

            var client = await _httpClient.GetAsync(ApiConsumeUrlAddressConstants.Staff.GetAll);
            client.EnsureSuccessStatusCode();
            var jsonData = await client.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var response = JsonConvert.DeserializeObject<ResponseDto<List<StaffVM>>>(jsonData);

            return View(response?.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStaffVM model)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync(ApiConsumeUrlAddressConstants.Staff.GetAll, model);


            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode(); // Eğer yanıt bir hata kodu içeriyorsa (ör. 404 Not Found, 500 Internal Server Error), şu şekilde bir HttpRequestException fırlatır: Exception mesajı, yanıt durum kodunu ve durum mesajını içerir.

            var jsonData = await responseMessage.Content.ReadAsStringAsync();


            var response = JsonConvert.DeserializeObject<ResponseDto<List<StaffVM>>>(jsonData);
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

        [HttpDelete("/Admin/[controller]/[action]/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"{ApiConsumeUrlAddressConstants.Staff.Delete}/{id}");
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


    }
}

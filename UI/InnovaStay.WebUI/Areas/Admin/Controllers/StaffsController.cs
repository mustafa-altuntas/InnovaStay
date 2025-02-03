using InnovaStay.WebUI.Constant;
using InnovaStay.WebUI.Models.DTOs;
using InnovaStay.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

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
            var client = await _httpClient.GetAsync(ApiConsumeUrlAddressConstants.Staff.Get);
            client.EnsureSuccessStatusCode();
            var jsonData = await client.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ResponseDto<List<StaffVM>>>(jsonData);

            return View(response?.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{ApiConsumeUrlAddressConstants.Staff.Get}/{id}");
            if (responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto<UpdateStaffVM>>(jsonData);

            return View(response!.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStaffVM model)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync(ApiConsumeUrlAddressConstants.Staff.Create, model);

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
        
        [HttpGet("/Admin/[controller]/[action]/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"{ApiConsumeUrlAddressConstants.Staff.Get}/{id}");
            if(responseMessage.StatusCode != HttpStatusCode.BadRequest)
                responseMessage.EnsureSuccessStatusCode();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto<UpdateStaffVM>>(jsonData);

            return View(response!.Data);
        }

        [HttpPost("/Admin/[controller]/[action]/{id}")]
        public async Task<IActionResult> Update(int id, UpdateStaffVM model)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync($"{ApiConsumeUrlAddressConstants.Staff.Update}/{id}", model);

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
            return RedirectToAction("Index","Staffs");
        }


    }
}

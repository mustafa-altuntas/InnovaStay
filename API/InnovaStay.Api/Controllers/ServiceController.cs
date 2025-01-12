using InnovaStay.Business.Abstract;
using InnovaStay.Dto.Dtos.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovaStay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }

        // GET: api/Service
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _service.GetAllAsync();
            return Ok(values);
        }

        // GET api/Service/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _service.GetByIdAsync(id);
            return Ok(values);
        }

        // POST api/Service
        [HttpPost]
        public async Task Create([FromBody] ServiceDto dto)
        {
            await _service.AddAsync(dto);
        }

        // PUT api/Service/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ServiceDto dto)
        {
            _service.Update(dto, id);
            return Ok("Güncelleme Başarılı!");
        }

        // DELETE api/Service/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return Ok("Silme Başarılı!");
        }
    }
}

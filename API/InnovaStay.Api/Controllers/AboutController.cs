using InnovaStay.Business.Abstract;
using InnovaStay.Dto.Dtos.About;
using Microsoft.AspNetCore.Mvc;

namespace InnovaStay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _service;

        public AboutController(IAboutService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _service.GetAllAsync();
            return StatusCode(values.StatusCode, values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _service.GetByIdAsync(id);
            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByActive()
        {
            var values = await _service.GetByActive();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AboutDto dto)
        {
            var values = await _service.AddAsync(dto);
            return Ok(values);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AboutDto dto)
        {
            var values = _service.Update(dto, id);
            return Ok(values);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var values = _service.Remove(id);
            return Ok(values);

        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> MakeAsActive(int id)
        {
            var values = await _service.MarkAsActivateAsycn(id);
            return Ok(values);

        }
    }
}

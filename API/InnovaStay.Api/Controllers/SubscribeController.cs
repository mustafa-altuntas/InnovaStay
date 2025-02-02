using InnovaStay.Business.Abstract;
using InnovaStay.Dto.Dtos.Subscribe;
using Microsoft.AspNetCore.Mvc;


namespace InnovaStay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _service;

        public SubscribeController(ISubscribeService service)
        {
            _service = service;
        }

        // GET: api/Subscribe
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _service.GetAllAsync();
            return Ok(values);
        }

        // GET api/Subscribe/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _service.GetByIdAsync(id);
            return Ok(values);
        }

        // POST api/Subscribe
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubscribeDto dto)
        {
            var values = await _service.AddAsync(dto);
            return Ok(values);

        }

        // PUT api/Subscribe/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SubscribeDto dto)
        {
            var values = _service.Update(dto, id);
            return Ok(values);

        }

        // DELETE api/Subscribe/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var values = _service.Remove(id);
            return Ok(values);

        }
    }
}

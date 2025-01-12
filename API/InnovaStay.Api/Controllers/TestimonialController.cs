using InnovaStay.Business.Abstract;
using InnovaStay.Dto.Dtos.Testimonial;
using Microsoft.AspNetCore.Mvc;


namespace InnovaStay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _service;

        public TestimonialController(ITestimonialService service)
        {
            _service = service;
        }

        // GET: api/Testimonial
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _service.GetAllAsync();
            return Ok(values);
        }

        // GET api/Testimonial/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _service.GetByIdAsync(id);
            return Ok(values);
        }

        // POST api/Testimonial
        [HttpPost]
        public async Task Create([FromBody] TestimonialDto dto)
        {
            await _service.AddAsync(dto);
        }

        // PUT api/Testimonial/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TestimonialDto dto)
        {
            _service.Update(dto,id);
            return Ok("Güncelleme Başarılı!");
        }

        // DELETE api/Testimonial/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return Ok("Silme Başarılı!");
        }
    }
}

using InnovaStay.Business.Abstract;
using InnovaStay.Dto.Dtos.Staff;
using Microsoft.AspNetCore.Mvc;


namespace InnovaStay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _service;

        public StaffController(IStaffService service)
        {
            _service = service;
        }

        // GET: api/Staff
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _service.GetAllAsync();
            return Ok(values);
        }

        // GET api/Staff/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _service.GetByIdAsync(id);
            return Ok(values);
        }

        // POST api/Staff
        [HttpPost]
        public async Task Create([FromBody] StaffDto dto)
        {
            await _service.AddAsync(dto);
        }

        // PUT api/Staff/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StaffDto dto)
        {
            _service.Update(dto,id);
            return Ok("Güncelleme Başarılı!");
        }

        // DELETE api/Staff/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return Ok("Silme Başarılı!");
        }
    }
}

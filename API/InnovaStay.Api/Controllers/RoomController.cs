using InnovaStay.Business.Abstract;
using InnovaStay.Dto.Dtos.Room;
using Microsoft.AspNetCore.Mvc;


namespace InnovaStay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _service.GetAllAsync();
            return Ok(values);
        }

        // GET api/Room/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _service.GetByIdAsync(id);
            return Ok(values);
        }

        // POST api/Room
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoomDto dto)
        {
            var values = await _service.AddAsync(dto);
            return Ok(values);

        }

        // PUT api/Room/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RoomDto dto)
        {
            var values = _service.Update(dto, id);
            return Ok(values);

        }

        // DELETE api/Room/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var values = _service.Remove(id);
            return Ok(values);

        }
    }
}

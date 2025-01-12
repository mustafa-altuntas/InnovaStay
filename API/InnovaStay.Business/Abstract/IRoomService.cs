using InnovaStay.Dto.Dtos.Room;
using InnovaStay.Dto.Dtos.Testimonial;
using InnovaStay.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Business.Abstract
{
    public interface IRoomService : IGenericService<RoomDto,Room>
    {
    }
}

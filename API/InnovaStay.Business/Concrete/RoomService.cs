using InnovaStay.Data.Abstract;
using InnovaStay.Dto.Dtos.Room;
using InnovaStay.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Business.Concrete
{
    public class RoomService : GenericService<RoomDto, Room>
    {
        public RoomService(IGenericRepository<Room> repository) : base(repository)
        {
        }
    }
}

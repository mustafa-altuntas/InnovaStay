using InnovaStay.Business.Abstract;
using InnovaStay.Data.Abstract;
using InnovaStay.Dto.Dtos;
using InnovaStay.Dto.Dtos.Room;
using InnovaStay.Entity.Concrete;

namespace InnovaStay.Business.Concrete
{
    public class RoomService : GenericService<RoomDto, Room>,IRoomService
    {
        public RoomService(IGenericRepository<Room> repository) : base(repository)
        {
        }
    }
}

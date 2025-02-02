using InnovaStay.Dto.Dtos;
using InnovaStay.Dto.Dtos.Staff;
using InnovaStay.Entity.Concrete;

namespace InnovaStay.Business.Abstract
{
    public interface IStaffService : IGenericService<StaffDto,Staff>
    {
    }
}

using InnovaStay.Business.Abstract;
using InnovaStay.Data.Abstract;
using InnovaStay.Dto.Dtos;
using InnovaStay.Dto.Dtos.Staff;
using InnovaStay.Entity.Concrete;

namespace InnovaStay.Business.Concrete
{
    public class StaffService : GenericService<StaffDto, Staff>,IStaffService
    {
        public StaffService(IGenericRepository<Staff> repository) : base(repository)
        {
        }
    }
}

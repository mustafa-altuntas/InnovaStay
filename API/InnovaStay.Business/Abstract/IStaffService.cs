using InnovaStay.Dto.Dtos.Staff;
using InnovaStay.Dto.Dtos.Testimonial;
using InnovaStay.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Business.Abstract
{
    public interface IStaffService : IGenericService<StaffDto,Staff>
    {
    }
}

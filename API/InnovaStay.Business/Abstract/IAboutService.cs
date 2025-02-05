using InnovaStay.Dto.Dtos;
using InnovaStay.Dto.Dtos.About;
using InnovaStay.Entity.Concrete;

namespace InnovaStay.Business.Abstract
{
    public interface IAboutService : IGenericService<AboutDto,About>
    {
        Task<ResponseDto<bool>> MarkAsActivateAsycn(int id);
        Task<ResponseDto<AboutDto>?> GetByActive();


    }
}

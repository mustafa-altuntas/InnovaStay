using InnovaStay.Dto.Dtos;
using InnovaStay.Entity.Abstract;

namespace InnovaStay.Business.Abstract
{
    public interface IGenericService<TDto,TEntity> where TDto : class where TEntity : class,IBaseEntity
    {
        Task<ResponseDto<TDto>?> GetByIdAsync(int id);
        Task<ResponseDto<IEnumerable<TDto>>> GetAllAsync();
        Task<ResponseDto<NoDataDto>> AddAsync(TDto dto);
        ResponseDto<NoDataDto> Update(TDto dto,int id);
        ResponseDto<NoDataDto> Remove(int id);


    }
}

using Azure.Core;
using InnovaStay.Business.Abstract;
using InnovaStay.Business.Exceptions;
using InnovaStay.Business.Mappings;
using InnovaStay.Data.Abstract;
using InnovaStay.Dto.Dtos;
using InnovaStay.Dto.Dtos.About;
using InnovaStay.Entity.Concrete;

namespace InnovaStay.Business.Concrete
{
    public class AboutService : GenericService<AboutDto, About>, IAboutService
    {
        public AboutService(IAboutRepository repository) : base(repository)
        {
        }

        public async Task<ResponseDto<AboutDto>?> GetByActive()
        {
            var about = await (_repository as IAboutRepository)!.GetByActiveAsync();
            if(about == null)
                throw new EntityNotFoundException();

            return ResponseDto<AboutDto>.Success(ObjectMapper.Mapper.Map<AboutDto>(about),200);

        }

        public async Task<ResponseDto<bool>> MarkAsActivateAsycn(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            if (value == null) 
                throw new EntityNotFoundException();
            var result =  await (_repository as IAboutRepository)!.MarkAsActivateAsycn(id);
            return ResponseDto<bool>.Success(result, 200);
        }


    }
}

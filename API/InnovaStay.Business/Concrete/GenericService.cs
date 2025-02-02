using InnovaStay.Business.Abstract;
using InnovaStay.Business.Exceptions;
using InnovaStay.Business.Mappings;
using InnovaStay.Data.Abstract;
using InnovaStay.Dto.Dtos;
using InnovaStay.Entity.Abstract;

namespace InnovaStay.Business.Concrete
{
    public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity> where TDto : class where TEntity : class, IBaseEntity
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDto<NoDataDto>> AddAsync(TDto dto)
        {
            var entity = ObjectMapper.Mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
            return ResponseDto<NoDataDto>.SuccessNoData(201);
        }

        public async Task<ResponseDto<IEnumerable<TDto>>> GetAllAsync()
        {
            var values = await _repository.GetAllAsync();
            var data = ObjectMapper.Mapper.Map<List<TDto>>(values);
            return ResponseDto<IEnumerable<TDto>>.Success(data,200);

        }

        public async Task<ResponseDto<TDto>?> GetByIdAsync(int id)
        {
            var isExistEntity = await _repository.GetByIdAsync(id);
            if (isExistEntity == null)
                throw new EntityNotFoundException(id);

            var data = ObjectMapper.Mapper.Map<TDto>(isExistEntity);
            return ResponseDto<TDto>.Success(data, 200);

        }

        public ResponseDto<NoDataDto> Remove(int id)
        {
            var isExistEntity = _repository.GetByIdAsync(id).Result;

            if (isExistEntity == null)
                throw new EntityNotFoundException(id);

            _repository.Remove(isExistEntity);

            return ResponseDto<NoDataDto>.SuccessNoData(204);

        }

        public ResponseDto<NoDataDto> Update(TDto dto,int id)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var isExistEntity = _repository.GetByIdAsync(id).Result;

            if (isExistEntity == null)
                throw new EntityNotFoundException(id);

            TEntity value = ObjectMapper.Mapper.Map<TEntity>(dto);
            _repository.Update(value);

            return ResponseDto<NoDataDto>.SuccessNoData(204);


        }
    }
}

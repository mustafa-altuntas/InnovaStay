using InnovaStay.Business.Abstract;
using InnovaStay.Business.Mappings;
using InnovaStay.Data.Abstract;
using InnovaStay.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Business.Concrete
{
    public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity> where TDto : class where TEntity : class, IBaseEntity
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(TDto dto)
        {
            var entity = ObjectMapper.Mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var values = await _repository.GetAllAsync();
            return ObjectMapper.Mapper.Map<List<TDto>>(values);
        }

        public async Task<TDto?> GetByIdAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return ObjectMapper.Mapper.Map<TDto>(value);
        }

        public void Remove(TDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            TEntity value = ObjectMapper.Mapper.Map<TEntity>(dto);
            var entity = _repository.GetByIdAsync(value.Id).Result;

            if (entity == null)
                throw new InvalidOperationException($"Entity with Id '{value.Id}' not found.");

            _repository.Remove(entity);
        }

        public void Update(TDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            TEntity value = ObjectMapper.Mapper.Map<TEntity>(dto);
            var entity = _repository.GetByIdAsync(value.Id).Result;

            if (entity == null)
                throw new InvalidOperationException($"Entity with Id '{value.Id}' not found.");

            _repository.Update(entity);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Business.Abstract
{
    public interface IGenericService<TDto> where TDto : class
    {
        Task<TDto?> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task AddAsync(TDto dto);
        void Update(TDto dto);
        void Remove(TDto dto);


    }
}

using InnovaStay.Dto.Dtos;
using InnovaStay.Dto.Dtos.Testimonial;
using InnovaStay.Entity.Concrete;

namespace InnovaStay.Business.Abstract
{
    public interface ITestimonialService : IGenericService<TestimonialDto,Testimonial>
    {
    }
}

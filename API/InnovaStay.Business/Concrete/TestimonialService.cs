using InnovaStay.Business.Abstract;
using InnovaStay.Data.Abstract;
using InnovaStay.Dto.Dtos;
using InnovaStay.Dto.Dtos.Testimonial;
using InnovaStay.Entity.Concrete;

namespace InnovaStay.Business.Concrete
{
    public class TestimonialService : GenericService<TestimonialDto, Testimonial>,ITestimonialService
    {
        public TestimonialService(IGenericRepository<Testimonial> repository) : base(repository)
        {
        }
    }
}

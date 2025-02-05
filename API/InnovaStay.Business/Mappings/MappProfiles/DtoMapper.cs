using AutoMapper;
using InnovaStay.Dto.Dtos.About;
using InnovaStay.Dto.Dtos.Room;
using InnovaStay.Dto.Dtos.Service;
using InnovaStay.Dto.Dtos.Staff;
using InnovaStay.Dto.Dtos.Subscribe;
using InnovaStay.Dto.Dtos.Testimonial;
using InnovaStay.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Business.Mappings.MappProfiles
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<RoomDto, Room>().ReverseMap();
            CreateMap<ServiceDto, Service>().ReverseMap();
            CreateMap<StaffDto, Staff>().ReverseMap();
            CreateMap<SubscribeDto, Subscribe>().ReverseMap();
            CreateMap<TestimonialDto, Testimonial>().ReverseMap();
            CreateMap<AboutDto, About>().ReverseMap();
        }
    }
}

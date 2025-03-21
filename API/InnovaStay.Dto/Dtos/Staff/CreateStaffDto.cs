﻿using InnovaStay.Dto.Dtos.Subscribe;
using InnovaStay.Dto.Dtos.Testimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Dto.Dtos.Staff
{
    public class CreateStaffDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string? SocialMedia1 { get; set; }
        public string? SocialMedia2 { get; set; }
        public string? SocialMedia3 { get; set; }
    }
}

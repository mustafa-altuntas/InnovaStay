﻿using InnovaStay.Entity.Abstract;

namespace InnovaStay.Entity.Concrete
{
    public class Staff : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string? SocialMedia1 { get; set; }
        public string? SocialMedia2 { get; set; }
        public string? SocialMedia3 { get; set; }
    }
}

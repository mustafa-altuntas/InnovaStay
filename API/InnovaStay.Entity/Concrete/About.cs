﻿using InnovaStay.Entity.Abstract;

namespace InnovaStay.Entity.Concrete
{
    public class About : IBaseEntity
    {
        public int Id { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Content { get; set; }
        public int RoomCount { get; set; }
        public int StaffCount { get; set; }
        public int CustomerCount { get; set; }
        public bool İsActive { get; set; } = false;

    }
}

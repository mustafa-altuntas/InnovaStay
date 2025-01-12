﻿using InnovaStay.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Entity.Concrete
{
    public class Subscribe : IBaseEntity
    {
        public int Id { get; set; }
        public string Mail { get; set; }
    }
}

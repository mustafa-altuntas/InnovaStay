using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Dto.Dtos.Room
{
    public class RoomDto
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}

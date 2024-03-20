using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class HotelRoom
    {
        [Key]
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public bool IsOccupied { get; set; }
        public decimal PricePerNight { get; set; }
    }
}

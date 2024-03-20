using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business
{
    public class HotelBusiness
    {
        public bool IsValidReservation(DateTime checkInDate, DateTime checkOutDate)
        {
            // Проверка за валидност на резервацията, например да не се прави резервация за минало време и други подобни правила
            if (checkInDate < DateTime.Today || checkInDate >= checkOutDate)
            {
                return false;
            }

            return true;
        }
    }
}

using Hotel_ADO.Models;
using Hotel_ADO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ADO.Controllers
{
    public class HotelController
    {
        public bool Insert(Models.Hotel hotel)
        {
            return new HotelService().Insert(hotel);
        }

        public List<Models.Hotel> FindAll()
        {
            return new HotelService().FindAll();
        }
    }
}

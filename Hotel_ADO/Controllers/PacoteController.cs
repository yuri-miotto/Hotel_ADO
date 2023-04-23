using Hotel.Services;
using Hotel_ADO.Models;
using Hotel_ADO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ADO.Controllers
{
    public class PacoteController
    {
        public bool Insert(Pacote pacote)
        {
            return new PacoteService().Insert(pacote);
        }

        public List<Pacote> FindAll()
        {
            return new PacoteService().FindAll();
        }
    }
}

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
    public class ClienteController
    {
        public bool Insert(Cliente cliente)
        {
            return new ClienteService().Insert(cliente);
        }

        public List<Cliente> FindAll()
        {
            return new ClienteService().FindAll();
        }
    }
}

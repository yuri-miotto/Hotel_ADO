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
    public class EnderecoController
    {
        public bool Insert(Endereco endereco)
        {
            return new EnderecoService().Insert(endereco);
        }

        public List<Endereco> FindAll()
        {
            return new EnderecoService().FindAll();
        }
    }
}

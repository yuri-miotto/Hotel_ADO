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
    public class CidadeController
    {
        public bool Insert(Cidade cidade)
        {
            return new CidadeService().Insert(cidade);
        }

        public List<Cidade> FindAll()
        {
            return new CidadeService().FindAll();
        }
    }
}

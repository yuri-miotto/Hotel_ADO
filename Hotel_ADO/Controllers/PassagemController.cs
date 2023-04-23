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
    public class PassagemController
    {
        public bool Insert(Passagem passagem)
        {
            return new PassagemService().Insert(passagem);
        }

        public List<Passagem> FindAll()
        {
            return new PassagemService().FindAll();
        }
    }
}

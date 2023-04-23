using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ADO.Models
{
    public class Pacote
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Passagem Passagem { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }
        public Cliente Cliente { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + "\nHotel: " + Hotel + "\nPassagem: " + Passagem +
                "\nData de cadastro: " + DataCadastro + "\nValor: " + Valor + "\nCliente: " + Cliente;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ADO.Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public Endereco Origem { get; set; }
        public Endereco Destino { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + "\nOrigem: " + Origem + "\nDestino: " + Destino +
                "\nCliente: " + Cliente + "\nData: " + Data + "\nValor: " + Valor;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hotel_ADO.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataCadastro { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + "\nNome: " + Nome + "\nTelefone: " + Telefone +
                "\nEndereço: " + Endereco + "\nData de cadastro: " + DataCadastro;
        }

    }
}

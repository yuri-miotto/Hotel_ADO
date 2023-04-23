// See https://aka.ms/new-console-template for more information
using Hotel_ADO.Controllers;
using Hotel_ADO.Models;

Console.WriteLine("Proj MVC - ADO.NET");

Console.WriteLine("Teste Inclusão de dados");

Endereco endereco = new()
{
    Logradouro = "Av Brasil",
    Numero = 100,
    Bairro = "Centro",
    CEP = "123456",
    Complemento = "casa",
    DataCadastro = DateTime.Now,
    Cidade = new()
    {
        Descricao = "Araraquara",
        DataCadastro = DateTime.Now,
    }
};

//Cidade cidade = new()
//{
//    Descricao = "São Paulo",
//    DataCadastro = DateTime.Now,
//};

if (new EnderecoController().Insert(endereco))
    Console.WriteLine("Sucesso! Registro inserido!");
else
    Console.WriteLine("Erro ao inserir registro");

//new EnderecoController().FindAll().ForEach(Console.WriteLine);

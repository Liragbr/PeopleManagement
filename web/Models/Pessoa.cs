using System;

namespace web.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }

        public Pessoa(string nome, string telefone, DateTime dataDeNascimento)
        {
            Nome = nome;
            Telefone = telefone;
            DataDeNascimento = dataDeNascimento;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Telefone: {Telefone}, Data de Nascimento: {DataDeNascimento.ToShortDateString()}";
        }
    }
}








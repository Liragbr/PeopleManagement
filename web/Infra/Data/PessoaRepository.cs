using System;
using System.Collections.Generic;
using web.Models;

namespace web.Infra.Data
{
    public class PessoaRepository
    {
        private List<Pessoa> pessoas;

        public PessoaRepository()
        {
            pessoas = new List<Pessoa>();
        }

        public void Insert(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
            Console.WriteLine("Pessoa inserida com sucesso!");
        }

        public List<Pessoa> Get()
        {
            return new List<Pessoa>(pessoas);
        }

        public void LoadFromCsv(List<Pessoa> pessoasFromCsv)
        {
            pessoas.AddRange(pessoasFromCsv);
        }
    }
}

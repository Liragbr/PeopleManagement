using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Extensions.Logging;
using web.Models;

namespace web
{
    public class ManagePessoa
    {
        private readonly string _filePath;
        private readonly ILogger<ManagePessoa> _logger;

        public ManagePessoa(string filePath, ILogger<ManagePessoa> logger)
        {
            _filePath = filePath;
            _logger = logger;
        }

        public DataSet CreateDataSetFromCsv()
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable("Pessoas");

            try
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');

                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }

                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dataTable.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dataTable.Rows.Add(dr);
                    }
                }
                dataSet.Tables.Add(dataTable);
                _logger.LogInformation("DataSet criado a partir do CSV com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar DataSet a partir do CSV.");
                throw;
            }

            return dataSet;
        }

        public List<Pessoa> ReadDataSet(DataSet dataSet)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            try
            {
                DataTable dataTable = dataSet.Tables["Pessoas"];
                foreach (DataRow row in dataTable.Rows)
                {
                    string nome = row["Nome"].ToString();
                    string telefone = row["Telefone"].ToString();
                    DateTime dataDeNascimento = DateTime.Parse(row["DataDeNascimento"].ToString());

                    Pessoa pessoa = new Pessoa(nome, telefone, dataDeNascimento);
                    pessoas.Add(pessoa);
                }
                _logger.LogInformation("DataSet lido e convertido para lista de pessoas com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao ler DataSet.");
                throw;
            }

            return pessoas;
        }
    }
}

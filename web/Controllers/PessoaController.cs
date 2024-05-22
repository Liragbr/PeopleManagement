using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using web.Infra.Data;
using web.Models;
using web;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaRepository _repository;
        private readonly ManagePessoa _managePessoa;
        private readonly ILogger<PessoaController> _logger;

        public PessoaController(PessoaRepository repository, ManagePessoa managePessoa, ILogger<PessoaController> logger)
        {
            _repository = repository;
            _managePessoa = managePessoa;
            _logger = logger;
        }

        [HttpPost("add")]
        public IActionResult AdicionarPessoa([FromBody] Pessoa pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.Nome) || string.IsNullOrEmpty(pessoa.Telefone) || pessoa.DataDeNascimento == default)
            {
                _logger.LogWarning("Dados inválidos ao tentar adicionar uma pessoa.");
                return BadRequest("Dados inválidos.");
            }

            _repository.Insert(pessoa);
            _logger.LogInformation("Pessoa adicionada com sucesso: {Nome}", pessoa.Nome);
            return Ok("Pessoa adicionada com sucesso!");
        }

        [HttpGet("list")]
        public IActionResult ListarPessoas()
        {
            var pessoas = _repository.Get();
            if (!pessoas.Any())
            {
                _logger.LogInformation("Nenhuma pessoa encontrada.");
                return NotFound("Nenhuma pessoa encontrada.");
            }

            _logger.LogInformation("Lista de pessoas retornada com sucesso.");
            return Ok(pessoas);
        }

        [HttpPost("load-csv")]
        public IActionResult CarregarCsv([FromQuery] string filePath)
        {
            try
            {
                var dataSet = _managePessoa.CreateDataSetFromCsv();
                var pessoas = _managePessoa.ReadDataSet(dataSet);
                _repository.LoadFromCsv(pessoas);
                _logger.LogInformation("Dados carregados a partir do CSV com sucesso.");
                return Ok("Dados carregados a partir do CSV com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar dados do CSV.");
                return StatusCode(500, "Erro ao carregar dados do CSV.");
            }
        }
    }
}

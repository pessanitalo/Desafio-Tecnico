using Desafio_Tecnico.Application.Interfaces;
using Desafio_Tecnico.Application.Services;
using Desafio_Tecnico.Data.Repository;
using Desafio_Tecnico.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Tecnico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        public readonly IContatoService _contatoService;
        public readonly IContatoRepository _contatoRepository;

        public ClienteController(IContatoService contatoService, IContatoRepository contatoRepository)
        {
            _contatoService = contatoService;
            _contatoRepository = contatoRepository;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok("ok");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAsync()
        {
            var clientes = await _contatoRepository.GetAllAsync();
            return Ok(clientes);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(Contato Cliente)
        {
            await _contatoService.AddAsync(Cliente);
            return Ok("Cliente Salvo com sucesso");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var contato = await _contatoRepository.GetByIdAsync(id);
            return Ok(contato);
        }
    }
}

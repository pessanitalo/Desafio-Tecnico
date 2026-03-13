using Desafio_Tecnico.Api.ViewModels;
using Desafio_Tecnico.Application.Interfaces;
using Desafio_Tecnico.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Tecnico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssinaturaController : ControllerBase
    {

        public readonly IAssinaturaService _assinaturaService;

        public AssinaturaController(IAssinaturaService assinaturaService)
        {
            _assinaturaService = assinaturaService;
        }


        [HttpGet("list")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var assinaturas = await _assinaturaService.GetAllAsync();
                if (assinaturas == null || !assinaturas.Any()) return NotFound(new ResultViewModel<Assinatura>("Não a dados para mostrar."));
                return Ok(assinaturas);
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Assinatura>>("Falha interna no servidor"));
            }

        }

        [HttpPost()]
        public async Task<IActionResult> Create(Assinatura assinatura)
        {
            try
            {
                await _assinaturaService.AddAsync(assinatura);
                return Ok("Cliente Salvo com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Assinatura>>("Falha interna no servidor"));
            }

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var assinatura = await _assinaturaService.GetByIdAsync(id);

                if (assinatura == null) return NotFound(new ResultViewModel<Assinatura>("Assinatura não encontrada"));
                return Ok(assinatura);
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Assinatura>>("Falha interna no servidor"));
            }

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Assinatura assinatura)
        {
            try
            {
                assinatura.Id = id;

                await _assinaturaService.UpdateAsync(assinatura);
                return Ok(new ResultViewModel<string>("Assinatura alterada com sucesso!"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Assinatura>>("Falha interna no servidor"));
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> DeactivateAsync(int id)
        {
            try
            {
                await _assinaturaService.DeactivateAsync(id);
                return Ok(new ResultViewModel<string>("Assinatura inativada com sucesso!"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Assinatura>>("Falha interna no servidor"));
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {

                await _assinaturaService.DeleteAsync(id);
                return Ok(new ResultViewModel<string>("Assinatura excluída com sucesso!"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Assinatura>>("Falha interna no servidor"));
            }

        }
    }
}

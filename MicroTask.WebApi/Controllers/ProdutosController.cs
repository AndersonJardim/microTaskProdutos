using Microsoft.AspNetCore.Mvc;
using MicroTask.Domain.Interfaces;
using MicroTask.Domain.Models;

namespace MicroTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> logger;
        private readonly IProdutosService produtosService;

        public ProdutosController(ILoggerFactory loggerFactory, IProdutosService produtosService)
        {
            logger = loggerFactory.CreateLogger<ProdutosController>()
                ?? throw new ArgumentNullException(nameof(loggerFactory));
            this.produtosService = produtosService
                ?? throw new ArgumentNullException(nameof(produtosService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            logger.LogInformation($"Inicio do método {nameof(GetAllAsync)}");

            var produtos = await produtosService.GetAllAsync();

            logger.LogInformation($"Finalizado método {nameof(GetAllAsync)}");

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            logger.LogInformation($"Inicio do método {nameof(GetByIdAsync)}. Id da consulta {id}.");

            var produto = await produtosService.GetByIdAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            logger.LogInformation($"Finalizado método {nameof(GetByIdAsync)}");

            return Ok(produto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] Produtos produto)
        {
            var result = await produtosService.AddAsync(produto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = result }, produto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] Produtos produto)
        {
            await produtosService.UpdateAsync(produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await produtosService.DeleteAsync(id);
            return NoContent();
        }
    }
}

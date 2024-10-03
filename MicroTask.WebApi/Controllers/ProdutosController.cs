using Microsoft.AspNetCore.Mvc;
using MicroTask.Domain.Interfaces;

namespace MicroTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProdutosController(
        ILoggerFactory loggerFactory,
        IProdutosService produtosService) : ControllerBase
    {
        private readonly ILogger logger = loggerFactory.CreateLogger<ProdutosController>()
                ?? throw new ArgumentNullException(nameof(loggerFactory));
        private readonly IProdutosService produtosService = produtosService
                ?? throw new ArgumentNullException(nameof(produtosService));

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
    }
}
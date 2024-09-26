using Microsoft.AspNetCore.Mvc;
using MicroTask.Domain.Interfaces;

namespace MicroTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IProdutosService produtosService;

        public ProdutosController(
            ILoggerFactory loggerFactory,
            IProdutosService produtosService)
        {
            this.logger = loggerFactory.CreateLogger<ProdutosController>()
                ?? throw new ArgumentNullException(nameof(loggerFactory));

            this.produtosService = produtosService
                ?? throw new ArgumentNullException(nameof(produtosService));
        }

        [HttpGet]
        public async Task<IActionResult> ProdutosGetAllAsync()
        {
            var produtos = await produtosService.ProdutosGetAllAsync();

            return Ok(produtos);
        }
    }
}
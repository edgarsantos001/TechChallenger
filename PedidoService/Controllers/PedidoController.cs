using Microsoft.AspNetCore.Mvc;
using Pedido.Models;
using Pedido.Models.Interface;

namespace Pedido.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;        
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody]PedidoModel pedido)
        {
            var newPedido = _pedidoService.CreatePedido(pedido);
            if (newPedido != null)
            {
                return Ok(newPedido);
            }
            return BadRequest("Erro ao Criar Pedido.");
        }

        [HttpGet("{id}")]
        public IActionResult GetPedidoById(int id)
        {
            var pedido = _pedidoService.GetPedidoById(id);
            if (pedido != null)
            {
                return Ok(pedido);
            }
            return NotFound("Pedido not found.");
        }

        [HttpPut("{id}/status")]
        public IActionResult Edit(int id, [FromBody] string status)
        {
            var pedido = _pedidoService.UpdatePedidoStatus(id, status);
            if (pedido != null)
            {
                return Ok(pedido);
            }
            return BadRequest("Erro ao Atualizar o Status do Pedido.");
        }

        [HttpPut("{id}")]
        public IActionResult Delete(string id) {

            return Ok();
        }
    }
}

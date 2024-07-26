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
            _pedidoService.CreatePedido(pedido);
            return Ok();
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
             _pedidoService.UpdatePedidoStatus(id, status);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Delete(string id) {

            return Ok();
        }
    }
}

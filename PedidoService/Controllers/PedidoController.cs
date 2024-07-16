using Microsoft.AspNetCore.Mvc;

namespace Pedido.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Delete(string id) {

            return Ok();
        }
    }
}

using ClienteService.Models;
using ClienteService.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClienteService.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult CreateCliente([FromBody] ClienteModel cliente)
        {
            var newCliente = _clienteService.CreateCliente(cliente);
            return Ok(newCliente);
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            var cliente = _clienteService.GetClienteById(id);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound("Cliente not found.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] ClienteModel cliente)
        {
            var updatedCliente = _clienteService.UpdateCliente(id, cliente);
            if (updatedCliente != null)
            {
                return Ok(updatedCliente);
            }
            return NotFound("Cliente not found.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var result = _clienteService.DeleteCliente(id);
            if (result)
            {
                return Ok();
            }
            return NotFound("Cliente not found.");
        }
    }
}

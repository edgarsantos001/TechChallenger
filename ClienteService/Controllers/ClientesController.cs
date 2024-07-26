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


        [HttpGet]
        public IActionResult GetClientes()
        {
            var clientes = _clienteService.GetClientes();
            return Ok(clientes);
        }


        [HttpPost]
        public IActionResult CreateCliente([FromBody] ClienteModel cliente)
        {
            _clienteService.CreateCliente(cliente);
            return Ok();
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
            _clienteService.UpdateCliente(id, cliente);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
           _clienteService.DeleteCliente(id);
            return Ok();
        }
    }
}

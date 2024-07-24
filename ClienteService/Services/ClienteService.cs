using ClienteService.Models;
using ClienteService.Models.Interface;

namespace ClienteService.Services
{
    public class ClienteService : IClienteService
    {
        private readonly List<ClienteModel> _clientes = new List<ClienteModel>();

        public ClienteModel CreateCliente(ClienteModel cliente)
        {
            cliente.Id = _clientes.Count + 1;
            _clientes.Add(cliente);
            return cliente;
        }

        public ClienteModel GetClienteById(int id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        public ClienteModel UpdateCliente(int id, ClienteModel cliente)
        {
            var existingCliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (existingCliente != null)
            {
                existingCliente.Nome = cliente.Nome;
                existingCliente.Email = cliente.Email;
                existingCliente.Cpf = cliente.Cpf;
                return existingCliente;
            }
            return null;
        }

        public bool DeleteCliente(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
                return true;
            }
            return false;
        }
    }
}

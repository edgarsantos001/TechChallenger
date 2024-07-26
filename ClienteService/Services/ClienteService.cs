using ClienteService.Data;
using ClienteService.Models;
using ClienteService.Models.Interface;

namespace ClienteService.Services
{
    public class ClienteService : IClienteService
    {

         private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }


        public void CreateCliente(ClienteModel cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public ClienteModel GetClienteById(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCliente(int id, ClienteModel cliente)
        {
            var existingCliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (existingCliente != null)
            {
                existingCliente.Nome = cliente.Nome;
                existingCliente.Email = cliente.Email;
                existingCliente.Cpf = cliente.Cpf;
                _context.SaveChanges();

            }
        }

        public void DeleteCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }

        public List<ClienteModel> GetClientes()
        {
            return _context.Clientes.ToList();
        }
    }
}

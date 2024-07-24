namespace ClienteService.Models.Interface
{
    public interface IClienteService
    {
        ClienteModel CreateCliente(ClienteModel cliente);
        ClienteModel GetClienteById(int id);
        ClienteModel UpdateCliente(int id, ClienteModel cliente);
        bool DeleteCliente(int id);
    }
}

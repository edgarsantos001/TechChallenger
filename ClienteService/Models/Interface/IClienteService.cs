namespace ClienteService.Models.Interface
{
    public interface IClienteService
    {

        List<ClienteModel> GetClientes();
        ClienteModel GetClienteById(int id);
        void CreateCliente(ClienteModel cliente);

        void UpdateCliente(int id, ClienteModel cliente);
        void DeleteCliente(int id);
    }
}

namespace ProdutoService.Models.Interface
{
    public interface IProdutoService
    {
        List<ProdutoModel> GetAllProdutos();
        ProdutoModel GetProdutoById(int id);
        void CreateProduto(ProdutoModel produto);
        void UpdateProduto(int id, ProdutoModel produto);
        void DeleteProduto(int id);
    }
}

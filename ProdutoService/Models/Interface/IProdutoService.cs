namespace ProdutoService.Models.Interface
{
    public interface IProdutoService
    {
        List<ProdutoModel> GetAllProdutos();
        ProdutoModel CreateProduto(ProdutoModel produto);
        ProdutoModel UpdateProduto(int id, ProdutoModel produto);
        bool DeleteProduto(int id);
    }
}

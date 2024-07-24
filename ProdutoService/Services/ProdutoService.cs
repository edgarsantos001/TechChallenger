using ProdutoService.Models;
using ProdutoService.Models.Interface;

namespace ProdutoService.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly List<ProdutoModel> _produtos = new List<ProdutoModel>();

        public List<ProdutoModel> GetAllProdutos()
        {
            return _produtos;
        }


        public ProdutoModel CreateProduto(ProdutoModel produto)
        {
            produto.Id = _produtos.Count + 1;
            _produtos.Add(produto);
            return produto;
        }

        public ProdutoModel UpdateProduto(int id, ProdutoModel produto)
        {
            var existingProduto = _produtos.FirstOrDefault(p => p.Id == id);
            if (existingProduto != null)
            {
                existingProduto.Nome = produto.Nome;
                existingProduto.Descricao = produto.Descricao;
                existingProduto.Preco = produto.Preco;
                existingProduto.Categoria = produto.Categoria;
                return existingProduto;
            }
            return null;
        }

        public bool DeleteProduto(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                _produtos.Remove(produto);
                return true;
            }
            return false;
        }

    }
}

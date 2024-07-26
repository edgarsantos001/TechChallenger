using ProdutoService.Data;
using ProdutoService.Models;
using ProdutoService.Models.Interface;

namespace ProdutoService.Services
{
    public class ProdutoService : IProdutoService
    {
       
        private readonly AppDbContext _context;


        public ProdutoService(AppDbContext context)
        {
            _context = context; 
        }

        public ProdutoModel GetProdutoById(int id) 
        {  
           return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public List<ProdutoModel> GetAllProdutos()
        {
            return _context.Produtos.ToList();
        }


        public void CreateProduto(ProdutoModel produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void UpdateProduto(int id, ProdutoModel produto)
        {
            var existingProduto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (existingProduto != null)
            {
                existingProduto.Nome = produto.Nome;
                existingProduto.Descricao = produto.Descricao;
                existingProduto.Preco = produto.Preco;
                existingProduto.Categoria = produto.Categoria;
                _context.Produtos.Update(existingProduto);  
                _context.SaveChanges();
            }
        }

        public void DeleteProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }

    }
}

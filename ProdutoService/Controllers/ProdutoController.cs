using Microsoft.AspNetCore.Mvc;
using ProdutoService.Models;
using ProdutoService.Models.Interface;

namespace ProdutoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }


        [HttpGet]
        public IActionResult GetAllProdutos()
        {
            var produtos = _produtoService.GetAllProdutos();
            return Ok(produtos);
        }


        [HttpPost]
        public IActionResult CreateProduto([FromBody] ProdutoModel produto)
        {
           var novoProduto = _produtoService.CreateProduto(produto);
            return Ok(novoProduto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, [FromBody] ProdutoModel produto)
        {
            var produtoAtualizado = _produtoService.UpdateProduto(id, produto);
            if(produtoAtualizado != null)
                return Ok(produtoAtualizado);
        
           return NotFound("Produto Não Encontrado.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            bool produto = _produtoService.DeleteProduto(id);
            if(produto)
                return Ok();
        
           return NotFound("Produto Não Encontrado.");
        }
    }
}

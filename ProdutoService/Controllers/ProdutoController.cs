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

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(string id)
        {
            var produto = _produtoService.GetProdutoById(Convert.ToInt32(id));
            return Ok(produto);
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
            _produtoService.CreateProduto(produto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, [FromBody] ProdutoModel produto)
        {
            _produtoService.UpdateProduto(id, produto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            _produtoService.DeleteProduto(id);
            return Ok();
        }
    }
}

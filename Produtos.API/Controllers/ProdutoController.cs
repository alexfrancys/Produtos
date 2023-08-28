using MediatR;
using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Commands.CreateProduto;
using Produtos.Application.Commands.DeleteProduto;
using Produtos.Application.Commands.UpdateEstoqueProduto;
using Produtos.Application.Commands.UpdateValorProduto;
using Produtos.Application.Queries.GetProdutoById;
using Produtos.Application.Queries.GetProdutoByKeyWord;
using Produtos.Application.Queries.GetProdutos;

namespace Produtos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Obter Produto pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProdutoById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProdutoByIdQueryInput() { Id = id };

            return Ok(await _mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Obter todos os produtos com opção de filtro
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetProdutos([FromQuery] GetProdutosQueryInput query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Obter Produto por Nome ou Código
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("keyword")]
        public async Task<IActionResult> GetProdutosByKeyWord([FromQuery] GetProdutoByKeyWordQueryInput query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Cadastrar Produto
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("cadastro")]
        public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoCommandInput produto, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(produto, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Deletar um Produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("deletar/{id:guid}")]
        public async Task<IActionResult> DeleteProduto([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var produtoId = new DeleteProdutoCommandInput() { Id = id };
            return Ok(await _mediator.Send(produtoId, cancellationToken));
        }

        /// <summary>
        /// Alterar quantidade de estoque de um Produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="qtdEstoque"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch("update/estoque/{id:guid}")]
        public async Task<IActionResult> UpdateEstoqueProduto([FromRoute] Guid id, [FromBody] int qtdEstoque, CancellationToken cancellationToken)
        {
            var produtoId = new UpdateEstoqueProdutoCommandInput() { Id = id, QtdEstoque = qtdEstoque };
            return Ok(await _mediator.Send(produtoId, cancellationToken));
        }

        /// <summary>
        /// Alterar valor de um Produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valor"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch("update/valor/{id:guid}")]
        public async Task<IActionResult> UpdateValorProduto([FromRoute] Guid id, [FromBody] decimal valor, CancellationToken cancellationToken)
        {
            var produtoId = new UpdateValorProdutoCommandInput() { Id = id, Valor = valor };
            return Ok(await _mediator.Send(produtoId, cancellationToken));
        }

    }
}

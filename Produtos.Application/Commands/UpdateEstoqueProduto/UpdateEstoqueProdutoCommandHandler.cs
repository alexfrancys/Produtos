using MediatR;
using Produtos.Domain.ProdutoAggregate;

namespace Produtos.Application.Commands.UpdateEstoqueProduto
{
    public class UpdateEstoqueProdutoCommandHandler : IRequestHandler<UpdateEstoqueProdutoCommandInput, UpdateEstoqueProdutoCommandResult>
    {
        readonly IProdutoRepository _produtoRepository;

        public UpdateEstoqueProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<UpdateEstoqueProdutoCommandResult> Handle(UpdateEstoqueProdutoCommandInput request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetProdutoById(request.Id);

            if (produto is not null)
            {               

                await _produtoRepository.UpdateEstoqueProduto(produto.Id, request.QtdEstoque);

                return new UpdateEstoqueProdutoCommandResult
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Codigo = produto.Codigo,
                    Estoque = produto.Estoque,
                    Valor = produto.Valor
                };
            }

            return new UpdateEstoqueProdutoCommandResult();
        }
    }
}

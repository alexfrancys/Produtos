using MediatR;
using Produtos.Domain.ProdutoAggregate;

namespace Produtos.Application.Commands.UpdateValorProduto
{
    public class UpdateValorProdutoCommandHandler : IRequestHandler<UpdateValorProdutoCommandInput, UpdateValorProdutoCommandResult>
    {
        readonly IProdutoRepository _produtoRepository;

        public UpdateValorProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<UpdateValorProdutoCommandResult> Handle(UpdateValorProdutoCommandInput request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetProdutoById(request.Id);

            if (produto is not null)
            {

                await _produtoRepository.UpdateValorProduto(produto.Id, request.Valor);

                return new UpdateValorProdutoCommandResult
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Codigo = produto.Codigo,
                    Estoque = produto.Estoque,
                    Valor = produto.Valor
                };
            }

            return new UpdateValorProdutoCommandResult();
        }
    }
}

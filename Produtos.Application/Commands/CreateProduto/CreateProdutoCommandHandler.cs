using MediatR;
using Produtos.Domain.ProdutoAggregate;

namespace Produtos.Application.Commands.CreateProduto
{
    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommandInput, CreateProdutoCommandResult>
    {
        readonly IProdutoRepository _produtoRepository;

        public CreateProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<CreateProdutoCommandResult> Handle(CreateProdutoCommandInput request, CancellationToken cancellationToken)
        {
            var produto = new Produto(
                Guid.NewGuid(),
                request.Codigo,
                request.Nome,
                request.Estoque,
                request.Valor
                );

            if(produto is not null)
                await _produtoRepository.AddProduto(produto);

            return new CreateProdutoCommandResult() { Id = produto.Id };
        }
    }
}

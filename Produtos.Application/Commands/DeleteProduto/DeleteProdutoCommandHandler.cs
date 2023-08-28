using MediatR;
using Produtos.Domain.ProdutoAggregate;

namespace Produtos.Application.Commands.DeleteProduto
{
    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommandInput, DeleteProdutoCommandResult>
    {
        private readonly IProdutoRepository _produtoRepository;

        public DeleteProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<DeleteProdutoCommandResult> Handle(DeleteProdutoCommandInput request, CancellationToken cancellationToken)
        {
            await _produtoRepository.DeleteProduto(request.Id);

            return new DeleteProdutoCommandResult();
        }
    }
}

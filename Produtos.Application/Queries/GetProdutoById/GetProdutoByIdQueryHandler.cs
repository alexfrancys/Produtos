using MediatR;
using Produtos.Domain.ProdutoAggregate;

namespace Produtos.Application.Queries.GetProdutoById
{
    public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQueryInput, GetProdutoByIdQueryResult>
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetProdutoByIdQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<GetProdutoByIdQueryResult> Handle(GetProdutoByIdQueryInput request, CancellationToken cancellationToken)
        {
            var result = await _produtoRepository.GetProdutoById(request.Id);

            return new GetProdutoByIdQueryResult
            {
                Id = result.Id,
                Nome = result.Nome,
                Codigo = result.Codigo,
                Estoque = result.Estoque,
                Valor = result.Valor
            };
        }
    }
}

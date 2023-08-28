using MediatR;
using Produtos.Domain.ProdutoAggregate;

namespace Produtos.Application.Queries.GetProdutos
{
    public class GetProdutosQueryHandler : IRequestHandler<GetProdutosQueryInput, IEnumerable<GetProdutosQueryResult>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetProdutosQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<IEnumerable<GetProdutosQueryResult>> Handle(GetProdutosQueryInput request, CancellationToken cancellationToken)
        {
            var result = _produtoRepository
                         .GetAllProdutos().Result
                         .Select(x => new GetProdutosQueryResult
                         {
                             Id = x.Id,
                             Codigo = x.Codigo,
                             Nome = x.Nome,
                             Estoque = x.Estoque,
                             Valor = x.Valor
                         })
                         .ToList();

            if (((byte)request.Ordem) <= 1)
                return result.OrderBy(x => x.Nome);

            if (((byte)request.Ordem) <= 2)
                return result.OrderBy(x => x.Codigo);

            if (((byte)request.Ordem) == 3)
                return result.OrderByDescending(x => x.Valor);

            if (((byte)request.Ordem) == 4)
                return result.OrderBy(x => x.Valor);

            if (((byte)request.Ordem) == 5)
                return result.OrderByDescending(x => x.Estoque);

            if (((byte)request.Ordem) == 6)
                return result.OrderBy(x => x.Estoque);

            return result;
        }
    }
}

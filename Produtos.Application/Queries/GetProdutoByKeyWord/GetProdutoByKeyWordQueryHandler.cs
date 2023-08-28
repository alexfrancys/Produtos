using MediatR;
using Produtos.Domain.ProdutoAggregate;

namespace Produtos.Application.Queries.GetProdutoByKeyWord
{
    public class GetProdutoByKeyWordQueryHandler : IRequestHandler<GetProdutoByKeyWordQueryInput, IEnumerable<GetProdutoByKeyWordQueryResult>>
    {
        readonly IProdutoRepository _produtoRepository;

        public GetProdutoByKeyWordQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<IEnumerable<GetProdutoByKeyWordQueryResult>> Handle(GetProdutoByKeyWordQueryInput request, CancellationToken cancellationToken)
        {
            var result = _produtoRepository.GetAllProdutos().Result
                       .Where(x => x.Nome.Trim().ToLower().Contains($"{request.KeyWord.Trim().ToLower()}") ||
                       x.Codigo.ToString().Contains($"{request.KeyWord.Trim().ToLower()}"))
                       .ToList();

            return result.Select(x => new GetProdutoByKeyWordQueryResult
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nome = x.Nome,
                Estoque = x.Estoque,
                Valor = x.Valor
            });
        }
    }
}

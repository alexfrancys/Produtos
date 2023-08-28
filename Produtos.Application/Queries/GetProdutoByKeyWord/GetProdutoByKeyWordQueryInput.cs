using MediatR;

namespace Produtos.Application.Queries.GetProdutoByKeyWord
{
    public class GetProdutoByKeyWordQueryInput : IRequest<IEnumerable<GetProdutoByKeyWordQueryResult>>
    {
        public string KeyWord { get; set; }
    }
}

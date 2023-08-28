using MediatR;

namespace Produtos.Application.Queries.GetProdutoById
{
    public class GetProdutoByIdQueryInput : IRequest<GetProdutoByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}

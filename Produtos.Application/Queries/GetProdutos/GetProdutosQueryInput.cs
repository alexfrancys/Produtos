using MediatR;

namespace Produtos.Application.Queries.GetProdutos
{
    public class GetProdutosQueryInput : IRequest<IEnumerable<GetProdutosQueryResult>>
    {
        public Ordem Ordem { get; set; }
    }

    public enum Ordem : byte
    {
        Nome = 1,
        Codigo = 2,        
        MaiorValor = 3,
        MenorValor = 4,
        MaiorQtdEstoque = 5,
        MenorQtdEstoque = 6
    }
}

namespace Produtos.Application.Queries.GetProdutoById
{
    public class GetProdutoByIdQueryResult
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public Decimal Valor { get; set; }
    }
}

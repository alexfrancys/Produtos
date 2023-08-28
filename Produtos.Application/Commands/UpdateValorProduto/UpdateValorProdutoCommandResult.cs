namespace Produtos.Application.Commands.UpdateValorProduto
{
    public class UpdateValorProdutoCommandResult
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public Decimal Valor { get; set; }
    }
}

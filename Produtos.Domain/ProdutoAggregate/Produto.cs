namespace Produtos.Domain.ProdutoAggregate
{
    public class Produto
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public Decimal Valor { get; set; }

        public Produto() { }

        public Produto(Guid id, int codigo, string nome, int estoque, decimal valor)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            Estoque = estoque;

            if (valor >= 0)
                Valor = valor;
        }

        public void AtualizarValor(Decimal valor)
        {
            if(valor >= 0)
             Valor = valor; 
        }

        public void AtualizarEstoque(int quantidade)
        {
            if(quantidade >= 0)
                Estoque = quantidade;
        }
    }
}

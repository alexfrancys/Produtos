using MediatR;

namespace Produtos.Application.Commands.CreateProduto
{
    public class CreateProdutoCommandInput : IRequest<CreateProdutoCommandResult>
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public Decimal Valor { get; set; }
    }
}


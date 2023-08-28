using MediatR;

namespace Produtos.Application.Commands.UpdateValorProduto
{
    public class UpdateValorProdutoCommandInput : IRequest<UpdateValorProdutoCommandResult>
    {
        public Guid Id { get; set; }
        public Decimal Valor { get; set; }
    }
}

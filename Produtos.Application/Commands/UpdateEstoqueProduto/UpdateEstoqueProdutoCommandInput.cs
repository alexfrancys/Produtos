using MediatR;

namespace Produtos.Application.Commands.UpdateEstoqueProduto
{
    public class UpdateEstoqueProdutoCommandInput : IRequest<UpdateEstoqueProdutoCommandResult>
    {
        public Guid Id { get; set; }
        public int QtdEstoque { get; set; }
    }
}

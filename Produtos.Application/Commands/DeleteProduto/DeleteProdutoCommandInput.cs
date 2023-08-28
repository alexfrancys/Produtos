using MediatR;

namespace Produtos.Application.Commands.DeleteProduto
{
    public class DeleteProdutoCommandInput : IRequest<DeleteProdutoCommandResult>
    {
        public Guid Id { get; set; }
    }
}

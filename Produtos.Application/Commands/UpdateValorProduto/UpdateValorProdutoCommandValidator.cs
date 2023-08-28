using FluentValidation;

namespace Produtos.Application.Commands.UpdateValorProduto
{
    public class UpdateValorProdutoCommandValidator : AbstractValidator<Decimal>
    {
        public UpdateValorProdutoCommandValidator()
        {
            RuleFor(x => x)
               .NotEmpty()
               .NotNull()
               .GreaterThan(-1);
        }
    }
}

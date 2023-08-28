using FluentValidation;

namespace Produtos.Application.Commands.CreateProduto
{
    public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommandInput>
    {
        public CreateProdutoCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Codigo)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Valor)
                .NotEmpty()
                .NotNull()
                .GreaterThan(-1);
        }
    }
}

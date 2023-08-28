using FluentAssertions;

namespace Produtos.UnitTests
{
    public class ProdutoTests
    {
        [Theory]
        [InlineData("8064e4c1-9fd4-477d-a9d6-1a7f13bc8a4d", 100, "Mesa", 10, 500)]
        [InlineData("2f50ee94-9fe7-4c70-8bc0-316d51b0c901", 123, "Computador", 7, 5000.90)]
        [InlineData("ba5175b1-35b6-428d-83ec-9be764e8d332", 53, "Tablet", 10, 560.70)]
        [InlineData("d062aea6-33da-4f54-9d85-651f3e7b461b", 1, "Headset", 320, 150)]
        public void Constructor_Should_Create(Guid id, int codigo, string nome, int estoque, decimal valor)
        {
            //Act
            var produto = new Produto(id, codigo, nome, estoque, valor);

            //Assert
            produto.Should().NotBeNull();
            produto.Id.Should().Be(id);
            produto.Codigo.Should().Be(codigo);
            produto.Nome.Should().Be(nome);
            produto.Estoque.Should().Be(estoque);
            produto.Valor.Should().Be(valor);
        }
    }
}
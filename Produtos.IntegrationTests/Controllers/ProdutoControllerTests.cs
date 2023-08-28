using FluentAssertions;
using Newtonsoft.Json;
using Produtos.Domain.ProdutoAggregate;
using Produtos.IntegrationTests.Factories;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace Produtos.IntegrationTests.Controllers
{
    [Collection("Database")]
    public class ProdutoControllerTests : IClassFixture<ApiFactory>
    {
        private readonly ApiFactory _factory;

        public ProdutoControllerTests(ApiFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CreateProduto_Should_Return_Ok()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var request = new Produto(Guid.Parse("8064e4c1-9fd4-477d-a9d6-1a7f13bc8a4d"), 999, "Mesa", 10, 500);

            var response = await client.PostAsJsonAsync("/produto/cadastro", request);

            //Assert

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetProdutoById_Should_Return_Ok()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var id = Guid.Parse("0D251AC5-4ABC-4DA5-A8E1-3B14EB3267B3");

            var response = await client.GetFromJsonAsync<Produto>($"/produto/{id}");

            //Assert

            Assert.NotNull(response);
            response.Id.Should().Be(id);
            response.Codigo.Should().Be(200);
        }

        [Fact]
        public async Task GetProdutos_Should_Return_Ok()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act            

            var response = await client.GetFromJsonAsync<List<Produto>>("/produto");

            //Assert

            Assert.NotNull(response);
            Assert.True(response.Count == 5);            
        }

        [Fact]
        public async Task GetProdutoByKeyWord_Should_Return_Ok()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var keyword = "Tapete";

            var response = await client.GetFromJsonAsync<List<Produto>>($"/produto/keyword?keyword={keyword}");

            //Assert
            var produto = response.FirstOrDefault();

            Assert.NotNull(response);
            produto.Nome.Should().Be(keyword);            
        }

        [Fact]
        public async Task UpdateEstoqueProduto_Should_Return_Ok()
        {
            //Arrange
            var client = _factory.CreateClient();

            
            var id = Guid.Parse("0D251AC5-4ABC-4DA5-A8E1-3B14EB3267B3");
            var qtdEstoque = 30;

            var json = JsonConvert.SerializeObject(qtdEstoque);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            
            //Act
            var response = await client.PatchAsync($"/produto/update/estoque/{id}", content);
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var produto = JsonConvert.DeserializeObject<Produto>(responseJson); 

            //Assert            

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            produto.Nome.Should().Be("Tapete");
            produto.Codigo.Should().Be(200);
            produto.Valor.Should().Be(10.90M);
            produto.Estoque.Should().Be(qtdEstoque);
        }

        [Fact]
        public async Task UpdateValorProduto_Should_Return_Ok()
        {
            //Arrange
            var client = _factory.CreateClient();


            var id = Guid.Parse("9b3229a5-5b29-42b7-b685-ddfec68f26ff");
            var valor = 12.99M;

            var json = JsonConvert.SerializeObject(valor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            //Act
            var response = await client.PatchAsync($"/produto/update/valor/{id}", content);
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var produto = JsonConvert.DeserializeObject<Produto>(responseJson);

            //Assert            

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            produto.Nome.Should().Be("Panela");
            produto.Codigo.Should().Be(100);
            produto.Estoque.Should().Be(10);
            produto.Valor.Should().Be(valor);            
        }
    }
}

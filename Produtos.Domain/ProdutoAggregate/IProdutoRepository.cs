namespace Produtos.Domain.ProdutoAggregate
{
    public interface IProdutoRepository
    {
        Task AddProduto(Produto produto);
        Task UpdateEstoqueProduto(Guid id, int QtdEstoque);
        Task UpdateValorProduto(Guid id, decimal valor);
        Task DeleteProduto(Guid id);
        Task<Produto> GetProdutoById(Guid id);        
        Task<IEnumerable<Produto>> GetAllProdutos();      
    }
}

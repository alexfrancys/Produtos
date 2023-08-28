using Produtos.Domain.ProdutoAggregate;

namespace Produtos.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private Context _context;

        public ProdutoRepository(Context context)
        {
            _context = context;  
        }

        public async Task AddProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateEstoqueProduto(Guid id, int qtdEstoque)
        {
            var produto = _context.Produtos.Find(id);

            if (produto is not null)
            {
                produto.AtualizarEstoque(qtdEstoque);
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateValorProduto(Guid id, decimal valor)
        {
            var produto = _context.Produtos.Find(id);

            if (produto is not null)
            {
                produto.AtualizarValor(valor);
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduto(Guid id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto is not null)
            {
                _context.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Produto>> GetAllProdutos()
        {
            return await Task.FromResult(_context.Produtos.ToList());
        }

        public async Task<Produto> GetProdutoById(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }
    }
}

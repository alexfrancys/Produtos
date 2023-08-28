using Microsoft.EntityFrameworkCore;

namespace Produtos.IntegrationTests.Fixtures
{
    public class DbFixture : IDisposable
    {
        private readonly Context _context;
        public readonly string DatabaseName = $"Context-{Guid.NewGuid()}";
        public readonly string ConnectionString;
        private bool _disposed;

        public DbFixture()
        {
            ConnectionString = $"Server=localhost,1433;Database={DatabaseName};User Id=SA;Password=produtosteste@12345;";

            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseSqlServer(ConnectionString);

            _context = new Context(builder.Options);

            _context.Database.Migrate();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Database.EnsureDeleted();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

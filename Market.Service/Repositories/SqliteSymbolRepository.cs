using System.Threading.Tasks;
using Market.Models;
using Market.Repositories;
using Market.Service.Schema;

namespace Market.Service.Repositories
{
    internal class SqliteSymbolRepository : ISymbolRepository
    {
        private readonly SchemaContext _schemaContext;

        public SqliteSymbolRepository(SchemaContext schemaContext)
        {
            _schemaContext = schemaContext;
        }

        public Task AddSymbolAsync(Symbol symbol)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteSymbolAsync(Symbol symbol)
        {
            throw new System.NotImplementedException();
        }

        public Task<Symbol> GetSymbolAsync(string symbolId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Symbol> GetSymbolAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateSymbolAsync(Symbol symbol)
        {
            throw new System.NotImplementedException();
        }
    }
}

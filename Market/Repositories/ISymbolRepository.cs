using System.Threading.Tasks;
using Market.Models;

namespace Market.Repositories
{
    public interface ISymbolRepository
    {
        Task AddSymbolAsync(Symbol symbol);

        Task UpdateSymbolAsync(Symbol symbol);

        Task DeleteSymbolAsync(Symbol symbol);

        Task<Symbol> GetSymbolAsync(string symbolId);

        Task<Symbol> GetSymbolAsync(long id);
    }
}

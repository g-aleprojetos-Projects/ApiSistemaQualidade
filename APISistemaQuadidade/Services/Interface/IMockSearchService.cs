using APISistemaQuadidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISistemaQuadidade.Services
{
    public interface IMockSearchService
    {
        Task<IEnumerable<MockSearch>> GetSearchs();
        Task<MockSearch> GetSearch(int id);
        Task<IEnumerable<MockSearch>> GetSearch(string empreendimento);
        Task CreateSearch(MockSearch search);
        Task UpdateSearch(MockSearch search);
        Task DeleteSearch(MockSearch search);
    }
}

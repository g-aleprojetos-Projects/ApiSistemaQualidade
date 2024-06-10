using APISistemaQuadidade.Context;
using APISistemaQuadidade.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISistemaQuadidade.Services
{
    public class MockSearchsService : IMockSearchService
    {

        private readonly ApiContext _context;

        public MockSearchsService(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MockSearch>> GetSearchs()
        {
            try
            {
                return await _context.Searchs.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<MockSearch>> GetSearch(string empreendimento)
        {
            IEnumerable<MockSearch> empreendimentos;
            if (!string.IsNullOrWhiteSpace(empreendimento))
            {
                empreendimentos = await _context.Searchs.Where(n => n.Empreendimento.Contains(empreendimento)).ToListAsync();
            }
            else
            {
                empreendimentos = await GetSearchs();
            }
            return empreendimentos;
        }

        public async Task<MockSearch> GetSearch(int id)
        {
            var search = await _context.Searchs.FindAsync(id);
            return search;
        }

        public async Task CreateSearch(MockSearch search)
        {
            _context.Searchs.Add(search);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSearch(MockSearch search)
        {
            _context.Entry(search).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSearch(MockSearch search)
        {
            _context.Searchs.Remove(search);
            await _context.SaveChangesAsync();
        }
    }
}

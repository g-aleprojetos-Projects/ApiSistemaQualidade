using APISistemaQuadidade.Context;
using APISistemaQuadidade.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APISistemaQuadidade.Services
{
    public class MockTablesService : IMockTableService
    {
        private readonly ApiContext _context;

        public MockTablesService(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MockTable>> GetTable()
        {
            try
            {
                return await _context.Tables.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<MockTable> GetTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            return table;
        }

        public async Task CreateTable(MockTable table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTable(MockTable table)
        {

            _context.Entry(table).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteTable(MockTable table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
        }
    }
}

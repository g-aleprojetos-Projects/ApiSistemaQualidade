using APISistemaQuadidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISistemaQuadidade.Services
{
    public interface IMockTableService
    {
        Task<IEnumerable<MockTable>> GetTable();
        Task<MockTable> GetTable(int id);
        Task CreateTable(MockTable table);
        Task UpdateTable(MockTable table);
        Task DeleteTable(MockTable table);
    }
}

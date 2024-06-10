using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISistemaQuadidade.Models
{
    public class MockTable
    {
        public ulong Id { get; set; }
        public string Document { get; set; }
        public string CreatedBy { get; set; }
        public string LastModification { get; set; }
        public string Status { get; set; }
    }
}

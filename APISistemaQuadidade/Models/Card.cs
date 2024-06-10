using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISistemaQuadidade.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Modificacao { get; set; }
        public string Aprovacao { get; set; }
        public int Itens { get; set; }
    }
}

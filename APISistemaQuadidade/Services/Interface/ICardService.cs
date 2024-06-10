using APISistemaQuadidade.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APISistemaQuadidade.Services
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetCards();
        Task<Card> GetCard(int id);
        Task<IEnumerable<Card>> GetCardTitulo(string titulo);
        Task CreateCard(Card card);
        Task UpdateCard(Card card);
        Task DeleteCard(Card card);
    }
}

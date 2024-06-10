using APISistemaQuadidade.Context;
using APISistemaQuadidade.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISistemaQuadidade.Services
{
    public class CardsService : ICardService
    {
        private readonly ApiContext _context;

        public CardsService(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            try
            {
                return await _context.Cards.ToListAsync();
            }
            catch
            {
                throw;
            }

        }

        public async Task<IEnumerable<Card>> GetCardTitulo(string titulo)
        {
            IEnumerable<Card> cards;
            if (!string.IsNullOrWhiteSpace(titulo))
            {
                cards = await _context.Cards.Where(n => n.Titulo.Contains(titulo)).ToListAsync();
            }
            else
            {
                cards = await GetCards();
            }
            return cards;
        }

        public async Task<Card> GetCard(int id)
        {
            var cards = await _context.Cards.FindAsync(id);
            return cards;
        }

        public async Task CreateCard(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCard(Card card)
        {
            _context.Entry(card).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCard(Card card)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }
    }
}

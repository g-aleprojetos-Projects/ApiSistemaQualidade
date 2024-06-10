using APISistemaQuadidade.Models;
using APISistemaQuadidade.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISistemaQuadidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]

        public async Task<ActionResult<IAsyncEnumerable<Card>>> GetCards()
        {
            try
            {
                var cards = await _cardService.GetCards();
                return Ok(cards);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpGet("CardsPorTitulo")]
        public async Task<ActionResult<IAsyncEnumerable<Card>>> GetCardTitulo([FromQuery] string titulo)
        {
            try
            {
                var cards = await _cardService.GetCardTitulo(titulo);

                if (cards.Count() == null)
                    return NotFound($"Não exixtem cards com critérios {titulo}");

                return Ok(cards);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpGet("{id:int}", Name = "GetCard")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            try
            {
                var card = await _cardService.GetCard(id);

                if (card == null)
                    return NotFound($"Não exixtem cards com id= {id}");

                return Ok(card);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Card card)
        {
            try
            {
                await _cardService.CreateCard(card);
                return CreatedAtRoute(nameof(GetCard), new { id = card.Id }, card);

            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPut("id:int")]
        public async Task<ActionResult> Edit(int id, [FromBody] Card card)
        {
            try
            {
                if (card.Id == id)
                {
                    await _cardService.UpdateCard(card);
                    return NoContent();
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }

            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var card = await _cardService.GetCard(id);
                if(card != null)
                {
                    await _cardService.DeleteCard(card);
                    return Ok($"Card do id = {id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound($"Card com id = {id} não encontrado");
                }

            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

    }
}

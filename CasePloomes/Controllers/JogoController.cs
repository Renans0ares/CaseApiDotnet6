using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasePloomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private static List<Jogo> jogos = new List<Jogo>
        {
            new Jogo { Id = 1, Titulo = "God of War", Produtora = "Santa Monica" }
            //, new Jogo { Id = 2, Titulo = "Valorant", Produtora = "Riot Games" }
        };
        private readonly DataContext _context;
        public JogoController(DataContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Jogo>>> Get()
        {
            return Ok(await _context.Jogos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jogo>> Get(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
                return BadRequest("Jogo não Encontrado.");    
            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<List<Jogo>>> AdicionaJogo(Jogo jogo)
        {
            _context.Jogos.Add(jogo);

            try
            {
                await _context.SaveChangesAsync();
                return Ok(await _context.Jogos.ToListAsync());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

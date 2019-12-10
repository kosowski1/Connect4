using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Connect4.Data;
using Connect4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Connect4.Models.ManageViewModels;
using Connect4.Models.RankingViewModels;

namespace Connect4.Controllers
{
    public class TorneiosController : Controller
    {
        private UserManager<ApplicationUser> _userManager { get; set; }
        private SignInManager<ApplicationUser> _signInManager { get; set; }
        private ILogger<ManageController> _logger { get; set; }

        private ApplicationDbContext _context { get; set; }
        public TorneiosController(ApplicationDbContext context,  UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          ILogger<ManageController> logger
          )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        // GET: Torneios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Torneio.ToListAsync());
        }

        // GET: Torneios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneio
                .SingleOrDefaultAsync(m => m.Id == id);
            if (torneio == null)
            {
                return NotFound();
            }

            return View(torneio);
        }

        [Authorize]
        // GET: Torneios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Torneios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,NomeTorneio,QuantidadeJogadores,Inicio")] Torneio torneio)
        {
            if (ModelState.IsValid)
            {
                torneio.Dono = User.Identity.Name;
                _context.Add(torneio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(torneio);
        }

        // GET: Torneios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneio.SingleOrDefaultAsync(m => m.Id == id);
            if (torneio == null)
            {
                return NotFound();
            }
            return View(torneio);
        }

        // POST: Torneios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeTorneio,QuantidadeJogadores,Inicio")] Torneio torneio)
        {
            if (id != torneio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torneio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TorneioExists(torneio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(torneio);
        }

        // GET: Torneios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneio
                .SingleOrDefaultAsync(m => m.Id == id);
            if (torneio == null)
            {
                return NotFound();
            }
            if (User.Identity.Name != torneio.Dono)
            {
                return Forbid();
            }
            return View(torneio);
        }

        // POST: Torneios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var torneio = await _context.Torneio.SingleOrDefaultAsync(m => m.Id == id);
            if (User.Identity.Name != torneio.Dono)
            {
                return Forbid();
            }
            _context.Torneio.Remove(torneio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TorneioExists(int id)
        {
            return _context.Torneio.Any(e => e.Id == id);
        }
        public async Task<IActionResult> AddJogador(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneio.Include(j=> j.Jogadores)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (torneio == null)
            {
                return NotFound();
            }
            return View(torneio);
        }
        [HttpPost, ActionName("AddJogador")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddJogadorConfirmed(int? id)
        {
            List<Torneio> lista = new List<Torneio>();
            int? jogadorId =
               _userManager.GetUserAsync(User).Result.JogadorId;
            var jogadorAtual = _context.JogadorPessoas.Find(jogadorId);
            if (jogadorId == null)
            {
                throw new ApplicationException("O usuário atual não é um jogador.");
            }
            if (jogadorAtual == null || jogadorAtual.Id == 0)
            {
                return NotFound();
            }
            var torneio = _context.Torneio
                 .Include(t=> t.Jogadores)
                 .Where(t => t.Id == id)
                 .FirstOrDefault();
            if(torneio == null)
            {
                throw new Exception("Este torneio não existe");
            }
            else if(torneio != null)
            {
                if (!torneio.Jogadores.Contains(jogadorAtual))
                {
                    torneio.Jogadores.Add(jogadorAtual);
                    _context.SaveChanges();
                }

            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> listaJogos(int id)
        {
            var torneio = _context.Torneio
                 .Include(t => t.Jogadores)
                 .Include(t=> t.Jogos)
                 .Where(t => t.Id == id)
                 .FirstOrDefault();
            

            for (int i = 0; i < torneio.Jogadores.Count(); i++) {
                
                for (int j = 0; j < torneio.Jogadores.Count(); j++)
                {                    
                    if (i != j)
                    {
                       Jogo jogo = new Jogo();
                        if (jogo != null)
                        {
                            if (jogo.Jogador1 == null && jogo.Jogador2 == null)
                            {
                                jogo.Jogador1 = torneio.Jogadores[i];
                                jogo.Jogador2 = torneio.Jogadores[j];
                            }
                        }
                        torneio.Jogos.Add(jogo);
                       
                    }
                }                
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RankingJogadores(int id)
        {
            Ranking ranking = new Ranking();
            var torneio = _context.Torneio
                 .Include(t => t.Jogadores)
                 .Include(t => t.Jogos).ThenInclude(j=>j.Tabuleiro)
                 .Where(t => t.Id == id)
                 .FirstOrDefault();
           
           foreach(var tJogador in torneio.Jogadores)
            {
                JogadorRanking jogador = new JogadorRanking();
                jogador.JogadorId = tJogador.Id;
                if(tJogador is JogadorPessoa)
                {
                    var jogadorPessoa = _context.JogadorPessoas
                                    .Include(p => p.Usuario)
                                    .Where(p => p.Id == tJogador.Id)
                                    .FirstOrDefault();
                    jogador.NomeJogador = jogadorPessoa.Nome;
                }
                else if(tJogador is JogadorComputador)
                {
                    var jogadorComputador = _context.JogadorComputador
                                    .Where(p => p.Id == tJogador.Id)
                                    .FirstOrDefault();
                    jogador.NomeJogador = jogadorComputador.Nome;
                }
                
                foreach(var jogo in torneio.Jogos)
                {
                    if (jogo.Tabuleiro == null)
                    {
                        continue;
                    }
                    if (jogo.Jogador1Id == jogador.JogadorId && 
                        jogo.Tabuleiro.Vencedor() == 1)
                    {
                        jogador.Pontos = jogador.Pontos + 3;
                    }
                    else if(jogo.Jogador2Id == jogador.JogadorId && 
                        jogo.Tabuleiro.Vencedor() == 2)
                    {
                        jogador.Pontos = jogador.Pontos + 3;
                    }
                    else if(jogo.Jogador1Id == jogador.JogadorId && 
                        jogo.Tabuleiro.Vencedor() == -1)
                    {
                        jogador.Pontos = jogador.Pontos + 1;
                    }
                    else if (jogo.Jogador2Id == jogador.JogadorId && 
                        jogo.Tabuleiro.Vencedor() == -1){
                        jogador.Pontos = jogador.Pontos + 1;
                    }
            }
                ranking.Jogadores.Add(jogador);

            }
            _context.SaveChanges();
            return View(ranking);
        }
    }
 

}

using GeradorDeAtas.Data;
using GeradorDeAtas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GeradorDeAtas.Controllers
{
    public class HomeController : Controller
    {
        private AtasContexto _contexto;
        public HomeController(AtasContexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<IActionResult> Index()
        {
            var atas = await _contexto.Atas.ToListAsync();
            return View(atas);
        }

        public IActionResult CriarAtas()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CriarAtas(Atas ata)
        {
            if (ModelState.IsValid)
            {
                _contexto.Atas.Add(ata);
                await _contexto.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(ata);
            }
        }

        public async Task<IActionResult> RemoverAtas(Guid id)
        {
            var atas = await _contexto.Atas.FirstOrDefaultAsync(a => a.Id == id);

            _contexto.Atas.Remove(atas);
            _contexto.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditarAtas(Guid id)
        {
            var atas = await _contexto.Atas.FirstOrDefaultAsync(a => a.Id == id);

            return View(atas);

        }

        [HttpPost]
        public async Task<IActionResult> EditarAtas(Atas atasEditar)
        {
            var ata = await _contexto.Atas.FirstOrDefaultAsync(a => a.Id == atasEditar.Id);

            if (ModelState.IsValid)
            {
                ata.Titulo = atasEditar.Titulo;
                ata.Conteudo = atasEditar.Conteudo;
                ata.Alteracao = DateTime.Now;

                _contexto.Update(ata);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(ata);
            }
        }
    }
}

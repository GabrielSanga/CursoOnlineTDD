using System.Collections.Generic;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Web.Util;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Web.Controllers
{
    public class CursoController : Controller
    {

        private readonly ArmazenadorCursoService _armazenadorCurso;

        public CursoController(ArmazenadorCursoService armazenadorCursoService)
        {
            _armazenadorCurso = armazenadorCursoService;
        }

        public IActionResult Index()
        {
            var cursos = new List<CursoParaListagemDTO>();

            return View("Index", PaginatedList<CursoParaListagemDTO>.Create(cursos, Request));
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar", new CursoDTO());
        }

        [HttpPost]
        public IActionResult Salvar(CursoDTO model)
        {
            _armazenadorCurso.Armazenar(model);

            return Ok();
        }


    }
}

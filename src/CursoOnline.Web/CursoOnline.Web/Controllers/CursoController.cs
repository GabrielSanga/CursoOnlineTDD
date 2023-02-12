﻿using CursoOnline.Dominio.Cursos;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Web.Controllers
{
    public class CursoController : Controller
    {

        public IActionResult Index()
        {
            var cursos = new List<CursoParaListagemDTO>;

            return View("Index", PaginatedList<CursoPara>.Create(cursos, Request));
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar", new CursoDTO());
        }

        [HttpPost]
        public IActionResult Salvar(CursoDTO model)
        {
            return Ok();
        }


    }
}
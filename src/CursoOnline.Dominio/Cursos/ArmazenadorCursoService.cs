using System;

namespace CursoOnline.Dominio.Cursos
{
    public class ArmazenadorCursoService
    {
        private readonly iCursoRepositorio _cursoRepositorio;

        public ArmazenadorCursoService(iCursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDTO cursoDTO)
        {
            var cursoJaSalvo = _cursoRepositorio.ObterPeloNome(cursoDTO.Nome);

            if (cursoJaSalvo != null)
            {
                throw new ArgumentException("Nome do curso ja existente");
            }

            var curso = new Curso(cursoDTO.Nome, cursoDTO.Descricao, cursoDTO.CargaHoraria, cursoDTO.PublicoAlvo, cursoDTO.Valor);

            _cursoRepositorio.Adicionar(curso);
        }
    }

}

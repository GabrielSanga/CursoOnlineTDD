using CursoOnline.Dados.Contextos;
using CursoOnline.Dominio.Cursos;
using System;
using System.Linq;

namespace CursoOnline.Dados.Repositorios
{
    public class CursoRepositorio : RepositorioBase<Curso>, iCursoRepositorio
    {
        public CursoRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public Curso ObterPeloNome(string nome)
        {
            var entidade = Context.Set<Curso>().Where(c => c.nome.Contains(nome));

            if (entidade.Any())
                return entidade.First();
            return null;
        }
    }
}

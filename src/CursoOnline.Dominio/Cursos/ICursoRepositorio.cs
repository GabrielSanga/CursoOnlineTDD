using CursoOnline.Dominio._Base;

namespace CursoOnline.Dominio.Cursos
{
    public interface iCursoRepositorio : IRepositorio<Curso>
    {
        Curso ObterPeloNome(string nome);
    }

}

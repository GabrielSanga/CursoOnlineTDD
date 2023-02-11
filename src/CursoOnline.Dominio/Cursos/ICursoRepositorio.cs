namespace CursoOnline.Dominio.Cursos
{
    public interface iCursoRepositorio
    {
        void Adicionar(Curso curso);

        Curso ObterPeloNome(string nome);
    }

}

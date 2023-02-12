using CursoOnline.Dominio._Base;

namespace CursoOnline.Dominio.Cursos
{
    public class CursoDTO : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public double Valor { get; set; }
    }

}

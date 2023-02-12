using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnline.Dominio._Base
{
    public interface IRepositorio<TEntidade>
    {
        TEntidade ObterPorId(int id);

        List<TEntidade> Consultar();

        void Adicionar(TEntidade entity);
    }
}

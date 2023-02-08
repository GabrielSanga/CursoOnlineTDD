using System;

namespace CursoOnline.Dominio.Cursos
{
    public class Curso
    {
        public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (nome == string.Empty || nome == null)
            {
                throw new ArgumentException("Nome Inválido");
            }

            if (cargaHoraria < 1)
            {
                throw new ArgumentException("Carga Horária Invalida");
            }

            if (valor < 1)
            {
                throw new ArgumentException("Valor Inválido");
            }

            this.nome = nome;
            this.descricao = descricao;
            this.cargaHoraria = cargaHoraria;
            this.publicoAlvo = publicoAlvo;
            this.valor = valor;
        }

        public string nome { get; private set; }
        public string descricao { get; private set; }
        public double cargaHoraria { get; private set; }
        public PublicoAlvo publicoAlvo { get; private set; }
        public double valor { get; private set; }
    }
}

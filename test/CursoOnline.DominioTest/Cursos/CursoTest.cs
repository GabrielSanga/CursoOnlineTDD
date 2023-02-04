using System;
using ExpectedObjects;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{

    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {
            var oCursoEsperado = new
            {
                nome = "Informatica Basica",
                cargaHoraria = (double) 40,
                publicoAlvo = PublicoAlvo.Estudante,
                valor = (double) 950.00
            };

            var oCurso = new Curso(oCursoEsperado.nome, oCursoEsperado.cargaHoraria, oCursoEsperado.publicoAlvo, oCursoEsperado.valor);

            oCursoEsperado.ToExpectedObject().ShouldMatch(oCurso);
        }

    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    internal class Curso
    {

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            this.nome = nome;
            this.cargaHoraria = cargaHoraria;
            this.publicoAlvo = publicoAlvo;
            this.valor = valor;
        }

        public string nome { get; private set; }
        public double cargaHoraria { get; private set; }
        public PublicoAlvo publicoAlvo { get; private set; }
        public double valor { get; private set; }
    }
}

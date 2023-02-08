using System;
using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using ExpectedObjects;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos
{

    public class CursoTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly string _descricao;
        private readonly PublicoAlvo _publicAlvo;
        private readonly double _valor;

        /// <summary>
        /// Setup - É executado no inicio de cada método
        /// </summary>
        public CursoTest(ITestOutputHelper output)
        {
            _output = output;

            var faker = new Faker();

            _nome = faker.Random.Word();
            _descricao = faker.Lorem.Paragraph();
            _cargaHoraria = faker.Random.Double(50, 1000);
            _publicAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Double(100, 1000);
        }

        /// <summary>
        /// CleanUp - É executado no final de cada método
        /// </summary>
        public void Dispose()
        {
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var oCursoEsperado = new
            {
                nome = _nome,
                descricao = _descricao,
                cargaHoraria = _cargaHoraria,
                publicoAlvo = _publicAlvo,
                valor = _valor
            };

            var oCurso = new Curso(oCursoEsperado.nome, oCursoEsperado.descricao, oCursoEsperado.cargaHoraria, oCursoEsperado.publicoAlvo, oCursoEsperado.valor);

            oCursoEsperado.ToExpectedObject().ShouldMatch(oCurso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CursoNaoDeveTerNomeInvalido(string nomeInvalido)
        {
             Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComNome(nomeInvalido).Build()).ComMensagem("Nome Inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-12)]
        public void CursoNaoDeveTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build()).ComMensagem("Carga Horária Invalida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-12)]
        public void CursoNaoDeveTerValorMenorQue1(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComValor(valorInvalido).Build()).ComMensagem("Valor Inválido");
        }

    }

}

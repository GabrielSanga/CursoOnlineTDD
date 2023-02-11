using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using Moq;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorCursoTest
    {

        private readonly CursoDTO _cursoDTO;
        private readonly Mock<iCursoRepositorio> _cursoRepositorioMock;
        private readonly ArmazenadorCursoService _armazenarCurso;

        public ArmazenadorCursoTest()
        {
            var fake = new Faker();

            _cursoDTO = new CursoDTO
            {
                Nome = fake.Random.Words(4),
                Descricao = fake.Lorem.Paragraph(),
                CargaHoraria = fake.Random.Double(50, 1000),
                PublicoAlvo = "Estudante",
                Valor = fake.Random.Double(1, 1000)
            };

            _cursoRepositorioMock = new Mock<iCursoRepositorio>();
            _armazenarCurso = new ArmazenadorCursoService(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCusro()
        {
            _armazenarCurso.Armazenar(_cursoDTO);

            _cursoRepositorioMock.Verify(r => r.Adicionar(It.Is<Curso>(C => C.nome == _cursoDTO.Nome && C.descricao == _cursoDTO.Descricao)), Times.AtLeast(1));
        }

        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            _cursoDTO.PublicoAlvo = "Medico";

            Assert.Throws<ArgumentException>(() => _armazenarCurso.Armazenar(_cursoDTO)).ComMensagem("Publico alvo inválido");
        }

        [Fact] 
        public void NaoDeveAdicionarCursoComNomeExistente() 
        {
            var cursoJaSalvo = CursoBuilder.Novo().ComNome(_cursoDTO.Nome).Build();
            _cursoRepositorioMock.Setup(r => r.ObterPeloNome(_cursoDTO.Nome)).Returns(cursoJaSalvo);

            Assert.Throws<ArgumentException>(() => _armazenarCurso.Armazenar(_cursoDTO)).ComMensagem("Nome do curso ja existente");
        }

    }

}

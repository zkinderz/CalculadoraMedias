using CalculadoraMedias.Core.Models;
using CalculadoraMedias.Core.Services;

namespace CalculadoraMedias.Tests
{
    public class CalculadoraMediaServiceTests
    {
        private readonly CalculadoraMediaService _service;

        public CalculadoraMediaServiceTests()
        {
            _service = new CalculadoraMediaService();
        }

        [Fact]
        public void DeveCalcularMediaSemestralCorretamente()
        {
            decimal media = _service.CalcularMediaSemestral(7.0m, 8.0m, 9.0m);

            Assert.Equal(7.8m, media);
        }

        [Fact]
        public void DeveRetornarAprovadoQuandoMediaSemestralForMaiorOuIgualASete()
        {
            StatusAluno status = _service.DefinirStatusSemestral(7.0m);

            Assert.Equal(StatusAluno.Aprovado, status);
        }

        [Fact]
        public void DeveRetornarEmExameQuandoMediaSemestralForEntreQuatroESete()
        {
            StatusAluno status = _service.DefinirStatusSemestral(5.5m);

            Assert.Equal(StatusAluno.EmExame, status);
        }

        [Fact]
        public void DeveRetornarReprovadoQuandoMediaSemestralForMenorQueQuatro()
        {
            StatusAluno status = _service.DefinirStatusSemestral(3.9m);

            Assert.Equal(StatusAluno.Reprovado, status);
        }

        [Fact]
        public void DeveCalcularMediaFinalCorretamente()
        {
            decimal mediaFinal = _service.CalcularMediaFinal(6.0m, 8.0m);

            Assert.Equal(7.0m, mediaFinal);
        }

        [Fact]
        public void DeveRetornarAprovadoQuandoMediaFinalForMaiorOuIgualACinco()
        {
            StatusAluno status = _service.DefinirStatusFinal(5.0m);

            Assert.Equal(StatusAluno.Aprovado, status);
        }

        [Fact]
        public void DeveRetornarReprovadoQuandoMediaFinalForMenorQueCinco()
        {
            StatusAluno status = _service.DefinirStatusFinal(4.9m);

            Assert.Equal(StatusAluno.Reprovado, status);
        }

        [Fact]
        public void DeveLancarErroQuandoNotaForMenorQueZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _service.CalcularMediaSemestral(-1.0m, 8.0m, 7.0m)
            );
        }

        [Fact]
        public void DeveLancarErroQuandoNotaForMaiorQueDez()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _service.CalcularMediaSemestral(11.0m, 8.0m, 7.0m)
            );
        }

        [Fact]
        public void DeveLancarErroQuandoSomaDosPesosForDiferenteDeUm()
        {
            Assert.Throws<ArgumentException>(() =>
                _service.CalcularMediaSemestral(7.0m, 8.0m, 9.0m, 0.5m, 0.5m, 0.5m)
            );
        }
    }
}

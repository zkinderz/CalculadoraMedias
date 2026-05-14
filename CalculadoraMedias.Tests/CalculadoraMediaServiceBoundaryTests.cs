using System;
using CalculadoraMedias.Core.Models;
using CalculadoraMedias.Core.Services;
using Xunit;

namespace CalculadoraMedias.Tests
{
    public class CalculadoraMediaServiceBoundaryTests
    {
        private readonly CalculadoraMediaService _service = new CalculadoraMediaService();

        [Fact]
        public void DeveAprovarQuandoMediaSemestralForExatamenteSete()
        {
            StatusAluno status = _service.DefinirStatusSemestral(7.0m);

            Assert.Equal(StatusAluno.Aprovado, status);
        }

        [Fact]
        public void DeveEnviarParaExameQuandoMediaSemestralForExatamenteQuatro()
        {
            StatusAluno status = _service.DefinirStatusSemestral(4.0m);

            Assert.Equal(StatusAluno.EmExame, status);
        }

        [Fact]
        public void DeveReprovarQuandoMediaSemestralForMenorQueQuatro()
        {
            StatusAluno status = _service.DefinirStatusSemestral(3.9m);

            Assert.Equal(StatusAluno.Reprovado, status);
        }

        [Fact]
        public void DeveAprovarNaMediaFinalQuandoForExatamenteCinco()
        {
            StatusAluno status = _service.DefinirStatusFinal(5.0m);

            Assert.Equal(StatusAluno.Aprovado, status);
        }

        [Fact]
        public void DeveReprovarNaMediaFinalQuandoForMenorQueCinco()
        {
            StatusAluno status = _service.DefinirStatusFinal(4.9m);

            Assert.Equal(StatusAluno.Reprovado, status);
        }

        [Fact]
        public void DeveArredondarMediaSemestralParaUmaCasaDecimal()
        {
            decimal media = _service.CalcularMediaSemestral(6.25m, 6.25m, 6.25m);

            Assert.Equal(6.3m, media);
        }

        [Fact]
        public void DeveCalcularMediaSemestralComNotasMinimas()
        {
            decimal media = _service.CalcularMediaSemestral(0.0m, 0.0m, 0.0m);

            Assert.Equal(0.0m, media);
        }

        [Fact]
        public void DeveCalcularMediaSemestralComNotasMaximas()
        {
            decimal media = _service.CalcularMediaSemestral(10.0m, 10.0m, 10.0m);

            Assert.Equal(10.0m, media);
        }

        [Fact]
        public void DeveCalcularMediaFinalComValoresLimites()
        {
            decimal mediaFinal = _service.CalcularMediaFinal(10.0m, 0.0m);

            Assert.Equal(5.0m, mediaFinal);
        }

        [Fact]
        public void DeveLancarErroAoDefinirStatusSemestralComMediaInvalida()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _service.DefinirStatusSemestral(10.1m)
            );
        }
    }
}
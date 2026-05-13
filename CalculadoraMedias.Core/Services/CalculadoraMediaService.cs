using CalculadoraMedias.Core.Models;

namespace CalculadoraMedias.Core.Services
{
    public class CalculadoraMediaService
    {
        public ResultadoMedia CalcularResultadoSemestral(
            decimal np1,
            decimal np2,
            decimal pim,
            decimal pesoNp1 = 0.4m,
            decimal pesoNp2 = 0.4m,
            decimal pesoPim = 0.2m)
        {
            decimal media = CalcularMediaSemestral(np1, np2, pim, pesoNp1, pesoNp2, pesoPim);
            StatusAluno status = DefinirStatusSemestral(media);

            return new ResultadoMedia(media, status);
        }

        public decimal CalcularMediaSemestral(
            decimal np1,
            decimal np2,
            decimal pim,
            decimal pesoNp1 = 0.4m,
            decimal pesoNp2 = 0.4m,
            decimal pesoPim = 0.2m)
        {
            ValidarNota(np1, nameof(np1));
            ValidarNota(np2, nameof(np2));
            ValidarNota(pim, nameof(pim));
            ValidarPesos(pesoNp1, pesoNp2, pesoPim);

            decimal media = np1 * pesoNp1 + np2 * pesoNp2 + pim * pesoPim;

            return Math.Round(media, 1, MidpointRounding.AwayFromZero);
        }

        public StatusAluno DefinirStatusSemestral(decimal mediaSemestral)
        {
            ValidarNota(mediaSemestral, nameof(mediaSemestral));

            if (mediaSemestral >= 7.0m)
                return StatusAluno.Aprovado;

            if (mediaSemestral < 4.0m)
                return StatusAluno.Reprovado;

            return StatusAluno.EmExame;
        }

        public ResultadoMedia CalcularResultadoFinal(decimal mediaSemestral, decimal exame)
        {
            decimal mediaFinal = CalcularMediaFinal(mediaSemestral, exame);
            StatusAluno status = DefinirStatusFinal(mediaFinal);

            return new ResultadoMedia(mediaFinal, status);
        }

        public decimal CalcularMediaFinal(decimal mediaSemestral, decimal exame)
        {
            ValidarNota(mediaSemestral, nameof(mediaSemestral));
            ValidarNota(exame, nameof(exame));

            decimal mediaFinal = (mediaSemestral + exame) / 2;

            return Math.Round(mediaFinal, 1, MidpointRounding.AwayFromZero);
        }

        public StatusAluno DefinirStatusFinal(decimal mediaFinal)
        {
            ValidarNota(mediaFinal, nameof(mediaFinal));

            if (mediaFinal >= 5.0m)
                return StatusAluno.Aprovado;

            return StatusAluno.Reprovado;
        }

        private static void ValidarNota(decimal nota, string nomeCampo)
        {
            if (nota < 0.0m || nota > 10.0m)
            {
                throw new ArgumentOutOfRangeException(
                    nomeCampo,
                    "A nota deve estar entre 0,0 e 10,0."
                );
            }
        }

        private static void ValidarPesos(params decimal[] pesos)
        {
            foreach (decimal peso in pesos)
            {
                if (peso < 0.0m || peso > 1.0m)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(peso),
                        "O peso deve estar entre 0,0 e 1,0."
                    );
                }
            }

            decimal soma = pesos.Sum();

            if (soma != 1.0m)
            {
                throw new ArgumentException("A soma dos pesos deve ser igual a 1,0.");
            }
        }
    }
}

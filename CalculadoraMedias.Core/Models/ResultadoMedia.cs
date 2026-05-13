namespace CalculadoraMedias.Core.Models
{
    public class ResultadoMedia
    {
        public decimal Media { get; set; }
        public StatusAluno Status { get; set; }

        public ResultadoMedia(decimal media, StatusAluno status)
        {
            Media = media;
            Status = status;
        }
    }
}

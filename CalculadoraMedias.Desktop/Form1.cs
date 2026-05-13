using System.Globalization;
using CalculadoraMedias.Core.Models;
using CalculadoraMedias.Core.Services;

namespace CalculadoraMedias.Desktop
{
    public partial class Form1 : Form
    {
        private readonly CalculadoraMediaService _calculadoraService;

        private TextBox txtNp1 = null!;
        private TextBox txtNp2 = null!;
        private TextBox txtPim = null!;
        private TextBox txtMediaSemestral = null!;
        private TextBox txtExame = null!;
        private TextBox txtMediaFinal = null!;

        private Label lblStatus = null!;

        private Button btnSemestral = null!;
        private Button btnLimparSemestral = null!;
        private Button btnFinal = null!;
        private Button btnLimparFinal = null!;

        private decimal _mediaSemestral;

        public Form1()
        {
            InitializeComponent();

            _calculadoraService = new CalculadoraMediaService();

            ConfigurarTela();
            ConfigurarEstadoInicial();
        }

        private void ConfigurarTela()
        {
            Text = "Calculadora de Médias";
            Width = 540;
            Height = 430;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.WhiteSmoke;

            int labelX = 40;
            int textX = 200;
            int y = 35;
            int espacamento = 40;

            Label titulo = new Label
            {
                Text = "Calculadora de Médias",
                Left = 40,
                Top = 10,
                Width = 430,
                Height = 25,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            Controls.Add(titulo);

            y += 35;

            CriarLabel("NP1:", labelX, y);
            txtNp1 = CriarTextBox(textX, y);

            y += espacamento;
            CriarLabel("NP2:", labelX, y);
            txtNp2 = CriarTextBox(textX, y);

            y += espacamento;
            CriarLabel("PIM:", labelX, y);
            txtPim = CriarTextBox(textX, y);

            y += espacamento;
            CriarLabel("Média Semestral:", labelX, y);
            txtMediaSemestral = CriarTextBox(textX, y);
            txtMediaSemestral.ReadOnly = true;
            txtMediaSemestral.BackColor = Color.LightGray;

            y += espacamento;
            CriarLabel("Exame:", labelX, y);
            txtExame = CriarTextBox(textX, y);

            y += espacamento;
            CriarLabel("Média Final:", labelX, y);
            txtMediaFinal = CriarTextBox(textX, y);
            txtMediaFinal.ReadOnly = true;
            txtMediaFinal.BackColor = Color.LightGray;

            y += espacamento;
            CriarLabel("Status:", labelX, y);

            lblStatus = new Label
            {
                Left = textX,
                Top = y + 4,
                Width = 250,
                Height = 25,
                Text = "Em Andamento",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            Controls.Add(lblStatus);

            btnSemestral = new Button
            {
                Text = "Semestral",
                Left = 40,
                Top = 330,
                Width = 110,
                Height = 35
            };
            btnSemestral.Click += BtnSemestral_Click;
            Controls.Add(btnSemestral);

            btnLimparSemestral = new Button
            {
                Text = "Limpar Semestral",
                Left = 160,
                Top = 330,
                Width = 140,
                Height = 35
            };
            btnLimparSemestral.Click += BtnLimparSemestral_Click;
            Controls.Add(btnLimparSemestral);

            btnFinal = new Button
            {
                Text = "Final",
                Left = 310,
                Top = 330,
                Width = 80,
                Height = 35
            };
            btnFinal.Click += BtnFinal_Click;
            Controls.Add(btnFinal);

            btnLimparFinal = new Button
            {
                Text = "Limpar Final",
                Left = 400,
                Top = 330,
                Width = 100,
                Height = 35
            };
            btnLimparFinal.Click += BtnLimparFinal_Click;
            Controls.Add(btnLimparFinal);
        }

        private void ConfigurarEstadoInicial()
        {
            txtExame.Enabled = false;
            txtMediaSemestral.Clear();
            txtMediaFinal.Clear();

            btnFinal.Enabled = false;
            btnLimparFinal.Enabled = false;

            _mediaSemestral = 0;

            AtualizarStatus(StatusAluno.EmAndamento);
        }

        private void BtnSemestral_Click(object? sender, EventArgs e)
        {
            try
            {
                decimal np1 = ConverterNota(txtNp1.Text, "NP1");
                decimal np2 = ConverterNota(txtNp2.Text, "NP2");
                decimal pim = ConverterNota(txtPim.Text, "PIM");

                ResultadoMedia resultado = _calculadoraService.CalcularResultadoSemestral(np1, np2, pim);

                _mediaSemestral = resultado.Media;

                txtMediaSemestral.Text = resultado.Media.ToString("0.0");
                txtMediaFinal.Clear();

                AtualizarStatus(resultado.Status);

                if (resultado.Status == StatusAluno.EmExame)
                {
                    txtExame.Enabled = true;
                    btnFinal.Enabled = true;
                    btnLimparFinal.Enabled = true;
                    txtExame.Focus();
                }
                else
                {
                    txtExame.Enabled = false;
                    btnFinal.Enabled = false;
                    btnLimparFinal.Enabled = false;
                    txtExame.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BtnFinal_Click(object? sender, EventArgs e)
        {
            try
            {
                decimal exame = ConverterNota(txtExame.Text, "Exame");

                ResultadoMedia resultado = _calculadoraService.CalcularResultadoFinal(_mediaSemestral, exame);

                txtMediaFinal.Text = resultado.Media.ToString("0.0");

                AtualizarStatus(resultado.Status);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BtnLimparSemestral_Click(object? sender, EventArgs e)
        {
            txtNp1.Clear();
            txtNp2.Clear();
            txtPim.Clear();
            txtExame.Clear();
            txtMediaSemestral.Clear();
            txtMediaFinal.Clear();

            ConfigurarEstadoInicial();

            txtNp1.Focus();
        }

        private void BtnLimparFinal_Click(object? sender, EventArgs e)
        {
            txtExame.Clear();
            txtMediaFinal.Clear();

            AtualizarStatus(StatusAluno.EmExame);

            txtExame.Focus();
        }

        private void AtualizarStatus(StatusAluno status)
        {
            switch (status)
            {
                case StatusAluno.Aprovado:
                    lblStatus.Text = "Aprovado";
                    lblStatus.ForeColor = Color.Blue;
                    break;

                case StatusAluno.Reprovado:
                    lblStatus.Text = "Reprovado";
                    lblStatus.ForeColor = Color.Red;
                    break;

                case StatusAluno.EmExame:
                    lblStatus.Text = "Em Exame";
                    lblStatus.ForeColor = Color.DarkOrange;
                    break;

                default:
                    lblStatus.Text = "Em Andamento";
                    lblStatus.ForeColor = Color.Black;
                    break;
            }
        }

        private static decimal ConverterNota(string texto, string nomeCampo)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new ArgumentException($"Informe a nota de {nomeCampo}.");
            }

            texto = texto.Trim().Replace(".", ",");

            bool convertido = decimal.TryParse(
                texto,
                NumberStyles.Number,
                new CultureInfo("pt-BR"),
                out decimal nota
            );

            if (!convertido)
            {
                throw new ArgumentException($"A nota de {nomeCampo} deve ser um número válido.");
            }

            if (nota < 0 || nota > 10)
            {
                throw new ArgumentOutOfRangeException(
                    nomeCampo,
                    $"A nota de {nomeCampo} deve estar entre 0,0 e 10,0."
                );
            }

            return nota;
        }

        private Label CriarLabel(string texto, int x, int y)
        {
            Label label = new Label
            {
                Text = texto,
                Left = x,
                Top = y + 4,
                Width = 150,
                Height = 25,
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };

            Controls.Add(label);

            return label;
        }

        private TextBox CriarTextBox(int x, int y)
        {
            TextBox textBox = new TextBox
            {
                Left = x,
                Top = y,
                Width = 220,
                Height = 25,
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };

            Controls.Add(textBox);

            return textBox;
        }
    }
}

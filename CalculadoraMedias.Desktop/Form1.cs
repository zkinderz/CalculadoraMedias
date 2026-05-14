using System.Globalization;
using CalculadoraMedias.Core.Models;
using CalculadoraMedias.Core.Services;

namespace CalculadoraMedias.Desktop
{
    public partial class Form1 : Form
    {
        private readonly CalculadoraMediaService _calculadoraService;

        private PictureBox picLogo = null!;

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
            Controls.Clear();

            Text = "Calculadora de Médias - UNIP";
            Width = 640;
            Height = 520;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.WhiteSmoke;

            CriarLogoUnip();

            Label titulo = new Label
            {
                Text = "Calculadora de Médias Acadêmicas",
                Left = 170,
                Top = 25,
                Width = 400,
                Height = 30,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(titulo);

            Label subtitulo = new Label
            {
                Text = "Universidade Paulista - UNIP",
                Left = 170,
                Top = 58,
                Width = 400,
                Height = 25,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.DimGray,
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(subtitulo);

            int labelX = 60;
            int textX = 230;
            int y = 115;
            int espacamento = 42;

            CriarLabel("NP1:", labelX, y);
            txtNp1 = CriarTextBox(textX, y);
            txtNp1.KeyPress += PermitirApenasNumerosEVirgula;

            y += espacamento;
            CriarLabel("NP2:", labelX, y);
            txtNp2 = CriarTextBox(textX, y);
            txtNp2.KeyPress += PermitirApenasNumerosEVirgula;

            y += espacamento;
            CriarLabel("PIM:", labelX, y);
            txtPim = CriarTextBox(textX, y);
            txtPim.KeyPress += PermitirApenasNumerosEVirgula;

            y += espacamento;
            CriarLabel("Média Semestral:", labelX, y);
            txtMediaSemestral = CriarTextBox(textX, y);
            txtMediaSemestral.ReadOnly = true;
            txtMediaSemestral.BackColor = Color.LightGray;

            y += espacamento;
            CriarLabel("Exame:", labelX, y);
            txtExame = CriarTextBox(textX, y);
            txtExame.KeyPress += PermitirApenasNumerosEVirgula;

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
                Width = 280,
                Height = 28,
                Text = "Em Andamento",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            Controls.Add(lblStatus);

            btnSemestral = new Button
            {
                Text = "Semestral",
                Left = 60,
                Top = 415,
                Width = 120,
                Height = 38,
                BackColor = Color.LightSteelBlue
            };
            btnSemestral.Click += BtnSemestral_Click;
            Controls.Add(btnSemestral);

            btnLimparSemestral = new Button
            {
                Text = "Limpar Semestral",
                Left = 190,
                Top = 415,
                Width = 145,
                Height = 38
            };
            btnLimparSemestral.Click += BtnLimparSemestral_Click;
            Controls.Add(btnLimparSemestral);

            btnFinal = new Button
            {
                Text = "Final",
                Left = 345,
                Top = 415,
                Width = 90,
                Height = 38,
                BackColor = Color.LightGreen
            };
            btnFinal.Click += BtnFinal_Click;
            Controls.Add(btnFinal);

            btnLimparFinal = new Button
            {
                Text = "Limpar Final",
                Left = 445,
                Top = 415,
                Width = 120,
                Height = 38
            };
            btnLimparFinal.Click += BtnLimparFinal_Click;
            Controls.Add(btnLimparFinal);
        }

        private void CriarLogoUnip()
        {
            string caminhoLogo = ObterCaminhoLogo();

            if (File.Exists(caminhoLogo))
            {
                picLogo = new PictureBox
                {
                    Left = 45,
                    Top = 18,
                    Width = 105,
                    Height = 65,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = Image.FromFile(caminhoLogo),
                    BackColor = Color.Transparent
                };

                Controls.Add(picLogo);
            }
            else
            {
                Label lblLogoFallback = new Label
                {
                    Text = "UNIP",
                    Left = 45,
                    Top = 25,
                    Width = 105,
                    Height = 50,
                    Font = new Font("Segoe UI", 20, FontStyle.Bold),
                    ForeColor = Color.DarkBlue,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Controls.Add(lblLogoFallback);
            }
        }

        private static string ObterCaminhoLogo()
        {
            string caminhoSaida = Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                "unip-logo.png"
            );

            if (File.Exists(caminhoSaida))
            {
                return caminhoSaida;
            }

            string caminhoProjetoPelaSolution = Path.Combine(
                Directory.GetCurrentDirectory(),
                "CalculadoraMedias.Desktop",
                "Assets",
                "unip-logo.png"
            );

            if (File.Exists(caminhoProjetoPelaSolution))
            {
                return caminhoProjetoPelaSolution;
            }

            string caminhoProjetoAtual = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Assets",
                "unip-logo.png"
            );

            return caminhoProjetoAtual;
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

        private static void PermitirApenasNumerosEVirgula(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (sender is TextBox textBox)
                {
                    bool jaTemSeparador = textBox.Text.Contains(',') || textBox.Text.Contains('.');

                    if (!jaTemSeparador)
                    {
                        return;
                    }
                }
            }

            e.Handled = true;
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
                Width = 160,
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
                Width = 240,
                Height = 25,
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };

            Controls.Add(textBox);

            return textBox;
        }
    }
}
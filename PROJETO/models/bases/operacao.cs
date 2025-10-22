using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PROJETO.models.bases
{
    public class Operacao
    {

        public void HandleException(string message, Exception ex)
        {
            Console.WriteLine($"{message}: {ex.Message}");

            // Exibir uma mensagem de erro para o usuário (você pode usar um MessageBox ou uma caixa de diálogo)
            MessageBox.Show($"Ocorreu um erro: {message}\nDetalhes do erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string MascararDocumento(string documento)
        {
            if (documento.Length == 11) // CPF
            {
                return $"***.***.{documento.Substring(6, 3)}**";
            }
            else if (documento.Length == 14) // CNPJ
            {
                return $"**.***.***/{documento.Substring(8, 4)}-{documento.Substring(12, 2)}";
            }
            else
            {
                // Documento inválido ou RG
                return documento;
            }
        }
        public static Form CriarFormFoto(Image foto)
        {
            Form formFoto = new Form();
            // formFoto.WindowState = FormWindowState.Maximized;
            formFoto.StartPosition = FormStartPosition.CenterScreen;
            formFoto.FormBorderStyle = FormBorderStyle.Sizable;
            formFoto.MaximizeBox = true;
            formFoto.MinimizeBox = true;
            formFoto.Size = foto.Size;

            // PictureBox para exibir a imagem
            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Image = foto;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // ToolStrip para os botões de ação
            ToolStrip toolStrip = new ToolStrip();
            ToolStripButton salvarButton = new ToolStripButton("SALVAR");
            salvarButton.Click += (sender, e) =>
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox.Image.Save(saveFileDialog.FileName);
                    }
                }
            };
            toolStrip.Items.Add(salvarButton);

            ToolStripButton imprimirButton = new ToolStripButton("Imprimir");
            imprimirButton.Click += (sender, e) =>
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += (s, ev) =>
                {
                    ev.Graphics.DrawImage(pictureBox.Image, 0, 0);
                };

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            };
            toolStrip.Items.Add(imprimirButton);

            // Adicionando controles ao formulário
            formFoto.Controls.Add(pictureBox);
            formFoto.Controls.Add(toolStrip);

            // Posicionamento do ToolStrip
            toolStrip.Dock = DockStyle.Top;

            // Lidando com o evento de duplo clique para fechar o formulário
            formFoto.MouseDoubleClick += (sender, e) => formFoto.Close();

            return formFoto;
        }

        public bool IsForeignKeyViolation(SqlException ex)
        {
            foreach (SqlError error in ex.Errors)
            {
                if (error.Number == 547)
                {
                    // Número de erro 547 é comum para violações de chave estrangeira no SQL Server
                    return true;
                }
            }
            return false;
        }
        public static void DisableCopyPaste(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.KeyDown += BloquearKeyDowControlC;
                    textBox.ContextMenu = new ContextMenu(); // Remove o menu de contexto padrão
                }

                // Verifica recursivamente em todos os controles filhos
                if (control.HasChildren)
                {
                    DisableCopyPaste(control);
                }
            }
        }
        public static void BloquearKeyDowControlC(object sender, KeyEventArgs e)
        {
            // Desabilita Ctrl+C, Ctrl+X e Ctrl+V
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.X || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
            }
        }
        public static void ValidarNomes(object sender, KeyPressEventArgs e) // Validar nomes
        {
            TextBox textBox = (TextBox)sender;

            // Bloqueia qualquer modificação com Ctrl
            if (Control.ModifierKeys == Keys.Control)
            {
                e.Handled = true;
            }
            // Verificar se o caractere é uma letra, controle (como Backspace) ou espaço único
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ' ')
            {
                // Impedir mais de um espaço consecutivo
                if (e.KeyChar == ' ' && (textBox.Text.Length == 0 || textBox.Text.EndsWith(" ")))
                {
                    e.Handled = true;
                }
                // Impedir que o primeiro caractere seja um espaço
                else if (e.KeyChar == ' ' && textBox.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                // Bloquear todos os outros caracteres (caracteres especiais, dígitos, etc.)
                e.Handled = true;
            }
        }
        public static void ValidarValorKeyPress(TextBox textBox, KeyPressEventArgs e) // validar numeros inteiros.
        {
            // Bloqueia qualquer modificação com Ctrl
            if (Control.ModifierKeys == Keys.Control)
            {
                e.Handled = true;
            }

            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back);
        }
        public static void ValidarDecimais(TextBox textBox, KeyPressEventArgs e) // método para números decimais
        {
            // Bloqueia qualquer modificação com Ctrl
            if (Control.ModifierKeys == Keys.Control)
            {
                e.Handled = true;
                return;
            }

            // Permite dígitos, ponto e tecla Backspace
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back)
            {
                // Verifica se já existe um ponto no texto para não permitir mais de um
                if (e.KeyChar == '.' && textBox.Text.Contains("."))
                {
                    e.Handled = true; // Impede a entrada de mais um ponto
                }
                else if (e.KeyChar == '.' && textBox.Text.Length == 0)
                {
                    e.Handled = true; // Impede a entrada de um ponto no início
                }
                else
                {
                    e.Handled = false; // Permite a entrada
                }
            }
            else
            {
                e.Handled = true; // Impede a entrada de caracteres não permitidos
            }

            // Impede a entrada de espaços
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        public static bool IsTelefone(string telefone)
        {
            // Utilizamos uma expressão regular que aceita os formatos mencionados
            Regex Rgx = new Regex(@"^(?:(?:\+|00)\d{2}|0)?\d{2,5}\d{4,8}$");

            return Rgx.IsMatch(telefone);
        }
        public static bool IsEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        public static bool IsRg(string rg)
        {
            rg = rg.Trim();
            // Verifica se o RG tem 9 dígitos e se é composto apenas por números
            if (rg.Length != 9 || !int.TryParse(rg, out _))
                return false;

            // Outros critérios específicos do formato do RG brasileiro podem ser adicionados aqui, se necessário

            // Retorna true se o RG passar em todas as verificações
            return true;
        }


        public static string FormatarDocumento(string documento)
        {
            // Remova todos os caracteres não numéricos
            string documentoLimpo = new string(documento.Where(char.IsDigit).ToArray());


            if (documentoLimpo.Length == 11) // CPF
            {
                return string.Format("{0:000\\.000\\.000\\-00}", long.Parse(documentoLimpo));
            }
            else if (documentoLimpo.Length == 14) // CNPJ
            {
                return string.Format("{0:00\\.000\\.000\\/0000\\-00}", long.Parse(documentoLimpo));
            }
            return documento; // Retorna o documento original se não for CPF nem CNPJ
        }


        public static string FormatarCep(string cep)
        {
            if (cep.Length == 8)
            {
                return string.Format("{0:00000-000}", long.Parse(cep));
            }
            return cep;
        }

        public static string FormatarTelefone(string telefone)
        {
            // Remove espaços em branco e traços
            telefone = telefone.Replace(" ", "").Replace("-", "");

            try
            {
                if (telefone.Length == 11)
                {
                    return string.Format("({0}) {1}-{2}",
                        telefone.Substring(0, 2),
                        telefone.Substring(2, 5),
                        telefone.Substring(7, 4));
                }
                else if (telefone.Length == 10)
                {
                    return string.Format("({0}) {1}-{2}",
                        telefone.Substring(0, 2),
                        telefone.Substring(2, 4),
                        telefone.Substring(6, 4));
                }
                else if (telefone.Length == 9)
                {
                    return string.Format("{0}-{1}",
                        telefone.Substring(0, 5),
                        telefone.Substring(5, 4));
                }
                else if (telefone.Length == 8)
                {
                    return string.Format("{0}-{1}",
                        telefone.Substring(0, 4),
                        telefone.Substring(4, 4));
                }
            }
            catch (FormatException)
            {
                return "Formato inválido";
            }
            catch (Exception ex)
            {
                return "Erro ao formatar: " + ex.Message;
            }

            return telefone;
        }
        public static string FormatStatus(char status)
        {
            switch (status)
            {
                case 'E':
                    return "Enviado";
                case 'A':
                    return "Agendado";
                case 'N':
                    return "Não Enviado";
                default:
                    return "Desconhecido";
            }
        }


    }//////////////////////
}

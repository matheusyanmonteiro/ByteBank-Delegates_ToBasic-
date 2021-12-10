using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;
        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();

            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));
            AtualizarCamposDeTexto();
            AtualizarControles();
        }

        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco;
            txtDescricao.Text = _agencia.Descricao;
        }

        private void AtualizarControles()
        {

            RoutedEventHandler dialogResultTrue =  ( o, e) =>  DialogResult = true;
            //same
            RoutedEventHandler dialogResultFalse = delegate (object o, RoutedEventArgs e) { DialogResult = false; };

            var okEventHandler = dialogResultTrue + Fechar;
            var cancelarEventHandler = dialogResultFalse + Fechar;
        
            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;

            txtNumero.TextChanged += TextNumero_TextChanged;
            txtNumero.TextChanged += ValidarSomenteDigito;

            txtNome.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtNome);
            txtDescricao.TextChanged += TextDescricao_TextChanged;
            txtEndereco.TextChanged += TextEndereco_TextChanged;
            txtTelefone.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtTelefone);
        }

        private void ValidarSomenteDigito(Object sender, EventArgs e)
        {
            var txt = sender as TextBox;

            Func<char, bool> verificaSeEhDigito = caractere =>
            {
                return Char.IsDigit(caractere);
            };

            var todosCaracteresSaoDigitos = txt.Text.All(verificaSeEhDigito);


            txt.Background = todosCaracteresSaoDigitos ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.OrangeRed);
        }

        private TextChangedEventHandler ConstruirDelegateValidacaoCampoNulo(TextBox txt)
        {
            return (o, e) =>
            {
                var textEstaVazio = string.IsNullOrEmpty(txt.Text);

                txt.Background = textEstaVazio ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);
            };
        }

        private void TextTelefone_TextChagend(object sender, TextChangedEventArgs e)
        {
            var textEstaVazio = string.IsNullOrEmpty(txtTelefone.Text);

            if (textEstaVazio)
            {
                txtTelefone.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                txtTelefone.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textEstaVazio = string.IsNullOrEmpty(txtNumero.Text);

            if (textEstaVazio)
            {
                txtNumero.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                txtNumero.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextEndereco_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textEstaVazio = string.IsNullOrEmpty(txtEndereco.Text);

            if (textEstaVazio)
            {
                txtEndereco.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                txtEndereco.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextDescricao_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textEstaVazio = string.IsNullOrEmpty(txtDescricao.Text);

            if (textEstaVazio)
            {
                txtDescricao.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                txtDescricao.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void TextNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textEstaVazio = string.IsNullOrEmpty(txtNome.Text);

            if (textEstaVazio)
            {
                txtNome.Background = new SolidColorBrush(Colors.OrangeRed);
            } else
            {
                txtNome.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void Fechar(object sender, EventArgs e) => Close();

    }
}

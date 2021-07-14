using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Controls;

namespace Caselle_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        // Validates before entering value
        private void NumberValidation(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            System.Windows.Controls.TextBox txt = sender as System.Windows.Controls.TextBox;
            string txt_str = txt.Text;
            Regex reg = new Regex("[^0-9.]");

            // If our box already contains a decimal, don't allow
            if (txt_str.IndexOf('.') != -1 && e.Text == ".")
            {
                // Maybe add a shake or a notification to tell user?
                e.Handled = true;
            }
            // If we enter in a decimal, check if it is the first char
            else if (e.Text == "." && txt.CaretIndex == 0)
            {
                txt.Text = "0." + txt_str;
                txt.CaretIndex = txt.Text.Length + 1;
                e.Handled = true;
            }
            else
            {
                e.Handled = reg.IsMatch(e.Text);
            }
        }

        // We check for space input here.
        // This is the keyPress event handler
        // Using this for space, as all keys would require a workaround
        private void KeyValidation(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            } else if (e.Key == Key.Enter)
            {
                TextBox self = sender as TextBox;
                self.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }

        // Validates paste
        private void ExecuteValidation(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            // Disable paste for now, in the future parse if original + new string is valid
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}

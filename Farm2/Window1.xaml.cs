using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Farm2
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            if (string.IsNullOrWhiteSpace(username) || username == "Введите имя пользователя")
            {
                RegisterStatusTextBlock.Text = "Введите корректное имя пользователя";
                return;
            }

            if (string.IsNullOrWhiteSpace(password) || password == "Введите пароль")
            {
                RegisterStatusTextBlock.Text = "Введите корректный пароль";
                return;
            }

            if (MainWindow.Users.Any(u => u.Username == username))
            {
                RegisterStatusTextBlock.Text = "Пользователь с таким именем уже существует";
                return;
            }

            MainWindow.Users.Add(new User { Username = username, Password = password });
            MessageBox.Show("Регистрация успешна!");
            this.Close();
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "Введите имя пользователя")
            {
                UsernameTextBox.Text = "";
                UsernameTextBox.Foreground = Brushes.Black;
            }
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "Введите имя пользователя";
                UsernameTextBox.Foreground = Brushes.Gray;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == "Введите пароль")
            {
                PasswordBox.Password = "";
                PasswordBox.Foreground = Brushes.Black;
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                PasswordBox.Password = "Введите пароль";
                PasswordBox.Foreground = Brushes.Gray;
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authWindow = new AuthorizationWindow();
            authWindow.Show();
            this.Close();
        }

    }
}

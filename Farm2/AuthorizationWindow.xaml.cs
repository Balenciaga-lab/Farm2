using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Farm2
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            var user = MainWindow.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                MessageBox.Show("Авторизация успешна!");
                DatabaseWindow dbWindow = new DatabaseWindow();
                dbWindow.Show();
                this.Close();
            }
            else
            {
                LoginStatusTextBlock.Text = "Неверное имя пользователя или пароль";
            }
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
            MainWindow mainWindow = new MainWindow(); // Или любое другое окно, к которому вы хотите вернуться
            mainWindow.Show();
            this.Close();
        }

    }
}

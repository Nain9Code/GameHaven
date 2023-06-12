using System;
using System.Windows;

namespace GameHaven
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            // Aquí puedes poner tu lógica para verificar el inicio de sesión
            Console.WriteLine($"Intento de inicio de sesión con email: {email} y contraseña: {password}");
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Aquí puedes poner tu lógica para abrir la ventana de registro
            Console.WriteLine("Botón de registro pulsado");
        }
    }
}

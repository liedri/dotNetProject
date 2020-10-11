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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for managerLogin.xaml
    /// </summary>
    public partial class managerLogin : Window
    {
        public managerLogin()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int password = Configuration.ManagerPassword;
                if(int.Parse(ManagerPassword.Password) != password)
                {
                    MessageBox.Show($"Incorrect password", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                new Manager().ShowDialog();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Koks_PM_V3.WPF.Views.MainPages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : UserControl
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterPassword_Changed(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                if (((PasswordBox)sender).Name == "MPass")
                {
                    ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
                }
                else if (((PasswordBox)sender).Name == "CPass")
                {
                    ((dynamic)this.DataContext).ConfirmPassword = ((PasswordBox)sender).Password;
                }
            }
        }
    }
}

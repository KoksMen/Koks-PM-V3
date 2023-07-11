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

namespace Koks_PM_V3.WPF.Views.ModalPages
{
    /// <summary>
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : UserControl
    {
        public EditUserPage()
        {
            InitializeComponent();
        }

        private void AccountPassword_Changed(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                if (((PasswordBox)sender).Name == "AMPass")
                {
                    ((dynamic)this.DataContext).AccountPassword = ((PasswordBox)sender).Password;
                }
                else if (((PasswordBox)sender).Name == "ACPass")
                {
                    ((dynamic)this.DataContext).AccountSecondPassword = ((PasswordBox)sender).Password;
                }
            }
        }
    }
}

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

namespace TelephoneDirectory
{
    /// <summary>
    /// Interaction logic for AddNewContact.xaml
    /// </summary>
    public partial class AddNewContact : Window
    {
        public AddNewContact()
        {
            InitializeComponent();
        }

        private void txtName_NameChanged1(object sender, TextChangedEventArgs e)
        {
            txtHintName1.Visibility = Visibility.Visible;
            if (txtName1.Text.Length > 0)
            {
                txtHintName1.Visibility = Visibility.Hidden;
            }

        }

        private void txtphone_phoneChanged1(object sender, TextChangedEventArgs e)
        {
            txtHintphone.Visibility = Visibility.Visible;
            if (txtphone.Text.Length > 0)
            {
                txtHintphone.Visibility = Visibility.Hidden;
            }
        }

        private void saveBtnClick(object sender, RoutedEventArgs e)
        {
            String cName = txtName1.Text;
            String cPhone = txtphone.Text;
            MainWindow.tDList.Add(new TDirectory { fullName = cName , phoneNum = cPhone });
            MessageBox.Show(cName+" Added successfully");
            txtName1.IsEnabled=false;
            txtphone.IsEnabled = false;
        }

        private void back1_btnClick(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();
        }
    }
}

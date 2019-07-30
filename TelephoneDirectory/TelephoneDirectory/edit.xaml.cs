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
    /// Interaction logic for edit.xaml
    /// </summary>
    public partial class edit : Window
    {
        String cName;
        String cPhone;
        public edit( String fullName, String phone )
        {
            InitializeComponent();
            txtphone2.Text = phone;
            txtName2.Text = fullName;
            cName = fullName;
            cPhone = phone;
        }


        private void txtName_NameChanged2(object sender, TextChangedEventArgs e)
        {
            button.IsEnabled = true;
            txtHintName2.Visibility = Visibility.Visible;
            if (txtName2.Text.Length > 0)
            {
                txtHintName2.Visibility = Visibility.Hidden;
            }

        }

        private void txtphone_phoneChanged2(object sender, TextChangedEventArgs e)
        {
            button.IsEnabled = true;
            txtHintphone2.Visibility = Visibility.Visible;
            if (txtphone2.Text.Length > 0)
            {
                txtHintphone2.Visibility = Visibility.Hidden;
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            txtphone2.IsEnabled = true;
            txtName2.IsEnabled = true;
        }

        private void checkBox_Uncecked(object sender, RoutedEventArgs e)
        {
            txtphone2.IsEnabled = false;
            txtName2.IsEnabled = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            String cNewName = txtName2.Text;
            String cNewPhone = txtphone2.Text;
            foreach (TDirectory item in MainWindow.tDList)
            {
                if((item.fullName==cName) && (item.phoneNum==cPhone))
                {
                    item.fullName = cNewName;
                    item.phoneNum = cNewPhone;
                }
                              
            }
            txtphone2.IsEnabled = false;
            txtName2.IsEnabled = false;
            checkBox.IsChecked = false;
            MessageBox.Show("Succesfully Updated");
        }

        private void back_btnClick(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();
        }


        private void deleteBtn_Click_1(object sender, RoutedEventArgs e)
        {
            String cNewName = txtName2.Text;
            String cNewPhone = txtphone2.Text;
            foreach (TDirectory item in MainWindow.tDList)
            {
                if ((item.fullName == cName) && (item.phoneNum == cPhone))
                {
                    MainWindow.tDList.Remove(item);
                    break;
                }
               

            }
            MessageBox.Show("Succesfully Removed");
            txtphone2.IsEnabled = false;
            txtName2.IsEnabled = false;
            checkBox.IsChecked = false;
            button.IsEnabled = false;
        }
    }
}

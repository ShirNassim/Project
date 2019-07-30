using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xaml;
using System.Xml;

namespace TelephoneDirectory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public static List<TDirectory> tDList =new List<TDirectory>();
       public static List<TDirectory> tDOrderList = new List<TDirectory>();
       public static List<TDirectory> uploadList = new List<TDirectory>();
        static int counter = 0;
        string uploadData = "";
        string StartupPath = System.AppDomain.CurrentDomain.BaseDirectory;
        public MainWindow()
        {
            InitializeComponent();
            listViewEx();
            lvDataBinding.ItemsSource = tDList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtName.Text))
                return true;
            else
                return ((item as TDirectory).fullName.IndexOf(txtName.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


        public void listViewEx()
        {
          /*  if (counter == 0)
            {
                tDList.Add(new TDirectory { fullName = " Shir Nassim", phoneNum = "0587261851" });
                tDList.Add(new TDirectory { fullName = " Ortal Cohen", phoneNum = "0527610976" });
                tDList.Add(new TDirectory { fullName = " Yohanan Nassim", phoneNum = "0583226393" });
                lvDataBinding.ItemsSource = tDList;
                counter = 1;
            }
            */
        }

       

        private void txtName_NameChanged(object sender, RoutedEventArgs e)
        {
            txtHintName.Visibility = Visibility.Visible;
            if (txtName.Text.Length > 0)
            {
                txtHintName.Visibility = Visibility.Hidden;
            }

            CollectionViewSource.GetDefaultView(lvDataBinding.ItemsSource).Refresh();
        }

        private void addNewContactClick(object sender, RoutedEventArgs e)
        {
            AddNewContact win2 = new AddNewContact();
            win2.Show();
            this.Close();
        }

        private void onSelectedContact(object sender, RoutedEventArgs e)
        {

            TDirectory contact =  (TDirectory)lvDataBinding.SelectedItem;
            
            edit win2 = new edit(contact.fullName, contact.phoneNum);
            win2.Show();
            this.Close();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
               if (orderByNameCB.IsChecked == true)
                 {
                     Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                     dlg.FileName = "DumpFile1"; // Default file name
                     dlg.DefaultExt = ".txt"; // Default file extension
                     dlg.Filter = "Text files (.txt)|*.txt"; // Filter files by extension

                     // Show save file dialog box
                     Nullable<bool> result = dlg.ShowDialog();

                     // Process save file dialog box results
                     if (result == true)
                     {
                         // Save document
                         string filename = dlg.FileName;
                        string orderList= string.Join<TDirectory>(",", tDOrderList.ToArray());
                         string[] orderArray = new[] { orderList };
                         File.WriteAllLines(filename, orderArray, Encoding.UTF8);
                     }
                 }
                 else
                 {

                         Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                         dlg.FileName = "record"; // Default file name
                         dlg.DefaultExt = ".xml"; // Default file extension
                         dlg.Filter = "Text files (.txt)|*.txt"; // Filter files by extension

                         // Show save file dialog box
                         Nullable<bool> result = dlg.ShowDialog();

                         // Process save file dialog box results
                         if (result == true)
                         {
                
                    XamlServices.Save(dlg.FileName, tDList);

                    // Save document
                    //   string filename = dlg.FileName;
                    //string orderList = string.Join<TDirectory>(",", tDList.ToArray());
                    // string[] orderArray = new[] { orderList };
                    //  File.WriteAllLines(filename, orderArray, Encoding.UTF8);
                }
            }



     /*

            if (orderByNameCB.IsChecked == true)
            
                XamlServices.Save(StartupPath + @"\record.txt", tDOrderList);
                XamlServices.Save(StartupPath + @"\record.txt", tDList);
            MessageBox.Show("Telephone Directory was Saved");
            */
           
        }




        private void orderByNameCB1(object sender, RoutedEventArgs e)
        {
            foreach (TDirectory item in tDList)
            {
                tDOrderList.Add(item);
            }
            tDOrderList = tDList.OrderBy(m => m.fullName).ToList();
            lvDataBinding.ItemsSource = tDOrderList;
        }

        private void NotorderByNameCB1(object sender, RoutedEventArgs e)
        {
            lvDataBinding.ItemsSource = tDList;
        }

        private void loadBtn_Click(object sender, RoutedEventArgs e)
        {
          /*  string firstName = "";
            string phone = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            using (TextReader textReader = new StreamReader(openFileDialog.FileName))
            {
                // Load the text line by line
                string line = string.Empty;
                while ((line = textReader.ReadLine()) != null)
                {
                   
                }
                */
                   string firstName = "";
                   string phone = "";
                   OpenFileDialog openFileDialog = new OpenFileDialog();
                   if (openFileDialog.ShowDialog() == true)
                       uploadData = File.ReadAllText(openFileDialog.FileName);
                 System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                   doc.Load(openFileDialog.FileName);
                   foreach (XmlNode node in doc.DocumentElement)
                   {
                       firstName = node.Attributes[0].InnerText;
                       phone= node.Attributes[1].InnerText;
                       uploadList.Add(new TDirectory { fullName = firstName, phoneNum = phone });
                   }
                lvDataBinding.ItemsSource = uploadList; 

                //  OpenFileDialog openFileDialog = new OpenFileDialog();
                //   if (openFileDialog.ShowDialog() == true)
                //  {
                //     uploadData = File.ReadAllText(openFileDialog.FileName);
                //   uploadList = (List<TDirectory>)(XamlServices.Load(openFileDialog.FileName));
                // string[] uploadDataArray = File.ReadAllLines(openFileDialog.FileName);



           
            //  uploadData = File.ReadAllText(openFileDialog.FileName);



            //  uploadList = uploadData.Split(',').ToList();
            // lvDataBinding.ItemsSource = uploadList;
            //uploadList = (List<TDirectory>)(XamlServices.Load(StartupPath + @"\record.txt"));
        }
    }
}

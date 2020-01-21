using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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

namespace complaintBox
{
    /// <summary>
    /// Interaction logic for loggedin.xaml
    /// </summary>
    public partial class loggedin : Window
    {
        private String ID;
        private String Name;

        public loggedin(String val, String Name)
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            date.Content = dt.ToString();
            this.ID = val;
            id.Content = ID;
            this.Name = Name; ;
            name.Content = Name;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        static String GenerateHash(String Data)
        {
            using (SHA256 h = SHA256.Create())
            {
                byte[] bytes = h.ComputeHash(Encoding.UTF8.GetBytes(Data));
                StringBuilder b = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    b.Append(bytes[i].ToString("X2"));
                }
                return b.ToString();
            }


        }
    }

}

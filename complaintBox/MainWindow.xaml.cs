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

using System.Data.SqlClient;
using System.Security.Cryptography;

namespace complaintBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        String data;
        String gen;
        String userType;
        String readData;
        public MainWindow()
        {


            InitializeComponent();

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String name;
            String ID = id.Text;
            String hash = GenerateHash(passWord.Password.ToString());
            System.Data.SqlClient.SqlConnection Cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shami\source\repos\complaintBox\complaintBox\Database.mdf;Integrated Security=True");
            String query = "SELECT Name FROM login where Id=" + ID + "AND Password='"+hash+"';";
            SqlCommand cmd = new SqlCommand(query, Cn);
            Cn.Open();
            var queryResult = cmd.ExecuteScalar();
            if (queryResult != null)
            {
                ID = id.Text;
                name = Convert.ToString(queryResult);
                loggedin logged = new loggedin(ID,name);
                logged.Show();
                this.Close();
            }
            else
                MessageBox.Show("Invalid Credentials ! ");
 






        




        }

        private void RichTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {


        }

        private void RichTextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }



        private void qualification_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void gender1_Checked(object sender, RoutedEventArgs e)
        {
            gen = "female";

        }

        private void gender_Checked(object sender, RoutedEventArgs e)
        {
            gen = "male";
        }

        private void Teacher_Checked(object sender, RoutedEventArgs e)
        {
            if (userType != null)
                userType = userType + "\n" + "Teacher";
            else
                userType = "Teacher";
        }

        private void wTF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\Users\shami\Desktop\saved.txt");
                sw.Write(data);
                sw.Flush();
                sw.Close();
                rTF.Visibility = Visibility.Visible;

            }
            catch (Exception error)
            {
                readData = error.Message;

            }
            confirmation.Text = readData;
        }

        private void rTF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\Users\shami\Desktop\saved.txt");
                readData = null;
                while (true)
                {
                    String line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    readData = readData + "\n" + line;
                    confirmation.Text = readData;
                }
                sr.Close();
            }
            catch (Exception error)
            {
                readData = error.Message;
            }
            confirmation.Text = readData;

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            String hash =  GenerateHash(passWord.Password.ToString());
            System.Data.SqlClient.SqlConnection Cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shami\source\repos\complaintBox\complaintBox\Database.mdf;Integrated Security=True");
            String query = "insert into login(Id,Password)values(@a,@b)";
            SqlCommand cmd = new SqlCommand(query, Cn);
            cmd.Parameters.AddWithValue("@a", Convert.ToInt32(id.Text));
            cmd.Parameters.AddWithValue("@b", hash );
            Cn.Open();
            try
            {
                int r = cmd.ExecuteNonQuery();
                Cn.Close();
                if (r == 1)
                {
                    MessageBox.Show("values inserted");

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                Cn.Close();
            }
            
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
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
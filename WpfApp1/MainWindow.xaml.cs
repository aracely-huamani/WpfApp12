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
using System.Data.SqlClient;



namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAB1504-13\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=tecsup;Password=T3csup";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insertarclientes", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcliente",txtIdCliente.Text);
                    cmd.Parameters.AddWithValue("@nombrecompañia", txtNombreCompañia.Text);
                    cmd.Parameters.AddWithValue("@nombrecontacto", txtNombreContacto.Text);
                    cmd.Parameters.AddWithValue("@cargocontacto", txtCargoContacto.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente ingresado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el cliente: " + ex.Message);
            }
        }
    }
}

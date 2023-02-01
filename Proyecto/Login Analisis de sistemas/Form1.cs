using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login_Analisis_de_sistemas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-GFOI0JJ\SQLEXPRESS;Initial Catalog=Tarea_Login_Javier;Integrated Security=True");

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username, user_password;
            username = txt_username.Text;
            user_password = txt_password.Text;

            try
            {
                String querry = "SELECT * FROM data_login WHERE username = '" + txt_username.Text + "' AND password = '" + txt_password.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    user_password = txt_password.Text;

                    Menu form2 = new Menu();
                    form2.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Usuario o contraseña invalidos, vuelva a intentar");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

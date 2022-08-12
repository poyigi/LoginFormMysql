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

namespace LoginMysql
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-TPGDJL3E\SQLSERVER2019;Initial Catalog=userLogin;Integrated Security=True");
            string query = "select * from logins where username = '"+textBoxUn.Text.Trim()+"' and password = '"+textBoxPw.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                frmLoggedIn objfrmLoggedIn = new frmLoggedIn();
                this.Hide();
                objfrmLoggedIn.Show();
            }

            else
            {
                MessageBox.Show("Please check your username and password");
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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

namespace Store_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn= new SqlConnection(@"Data Source=DESKTOP-HDF6A4I\SQLEXPRESS;Initial Catalog=Store_Management;Integrated Security=True");

   
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();

            //to focus username
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName, Password;

            UserName= txtUserName.Text;
            Password= txtPassword.Text;

            try
            {
                string query = "select * from login_form where UserName='"+ txtUserName.Text+"' and Password ='"+txtPassword.Text+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                DataTable dataTable= new DataTable();
                adapter.Fill(dataTable);

                if(dataTable.Rows.Count>0)
                {
                    UserName = txtUserName.Text;
                    Password= txtPassword.Text;
                    
                    // the page that need to be loaded next

                    FCustomerDetails form2 = new FCustomerDetails();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("invalid login details","error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtUserName.Clear();
                    txtPassword.Clear();

                    //to focus username
                    txtUserName.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

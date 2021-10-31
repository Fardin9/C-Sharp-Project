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

namespace Bakery_Software
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
        //public string conn="Data Source=DESKTOP-0V5NG9S\\SQLEXPRESS;Initial Catalog=coopers_bakery;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-0V5NG9S\SQLEXPRESS;Initial Catalog=coopers_bakery;Integrated Security=True");
                conn.Open();
                // string query = "insert into tableone (uname,pass,department) values('" + Uname + "','" + pass + "','"+dept+"')";
                string query = "Select * from empdata where username='" + txt_user.Text.Trim() + "' and password='" +txt_pass.Text.Trim() + "'";
                SqlDataAdapter adp = new SqlDataAdapter(query, conn);
                DataTable dtb1 = new DataTable();
                adp.Fill(dtb1);

                if (dtb1.Rows.Count == 1)
                {
                    //MessageBox.Show("valid");
                    this.Hide();
                    salesman s1 = new salesman();
                    s1.ShowDialog();
                    this.Close();
                
                }
                else
                {
                    MessageBox.Show("Please Fill Correctly");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                salesman s1 = new salesman();
                s1.Show();
                Visible = false;
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup f2 = new Signup();
            f2.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txt_user_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

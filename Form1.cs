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

namespace JLAcademy_Omblero
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string cs = global.connection;
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (emailbox.Text == "" || passwordbox.Text == "")
            {
                MessageBox.Show("Please input Username and Password", "User Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmdLogin = new SqlCommand("Select Email, Password from Logintbl where Email ='" + emailbox.Text + "' and Password='" + passwordbox.Text + "' ", con);
                con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmdLogin);
            DataSet ds = new DataSet();
            adapt.Fill(ds);

            int count = ds.Tables[0].Rows.Count;
            if (count ==1)
            {
                Home home = new JLAcademy_Omblero.Home();
                this.Visible = false;
                home.ShowDialog();
                this.Close();
            }
                
            else
            {
                MessageBox.Show("Login Error: Email or Password is incorrect!", "User acces error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void emailtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm Registrationbox = new RegistrationForm();
            Registrationbox.ShowDialog();
        }
    }
}

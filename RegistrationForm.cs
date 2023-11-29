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

    public partial class RegistrationForm : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True");
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string cs = global.connection;
        public RegistrationForm()
        {
            InitializeComponent();
        }


        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        public void loadinfo()
        {
            studentinfolv.Items.Clear();
            SqlConnection con = new SqlConnection(cs);
            con.ConnectionString = cs;
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select UserID,FirstName,MiddleName,LastName,Address,Contact from registrationForms";
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            studentinfolv.Items.Clear();
            foreach (DataRow r in dt.Rows)
            {
                var list = studentinfolv.Items.Add(r.Field<int>(0).ToString());
                list.SubItems.Add(r.Field<string>(1).ToString());
                list.SubItems.Add(r.Field<string>(2).ToString());
                list.SubItems.Add(r.Field<string>(3).ToString());
                list.SubItems.Add(r.Field<string>(4).ToString());
                list.SubItems.Add(r.Field<string>(5).ToString());


                con.Close();
            }
            da.Dispose();
            con.Close();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            loadinfo(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void updatebtn_Click(object sender, EventArgs e)
        {
            update();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (password.Text != confirmedPassword.Text || email.Text == "" || password.Text == "")
            {
                MessageBox.Show("Your Password is not the same!", "Password mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand addaccount = new SqlCommand("INSERT INTO Logintbl(Email,Password) VALUES(@Email, @Password)");
                addaccount.Connection = con;
                con.Open();
                addaccount.Parameters.AddWithValue("@Email", email.Text);
                addaccount.Parameters.AddWithValue("@Password", password.Text);
                addaccount.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New Account successfully saved", "Add New Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                password.Text = "";
                email.Text = "";
                confirmedPassword.Text = "";

            }


        }


        private void button4_Click(object sender, EventArgs e)
        {
            Subjects Subjectbox = new Subjects();
            this.Hide();
            Subjectbox.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Schedule schedbox = new Schedule();
            this.Hide();
            schedbox.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home Dashboard = new Home();
            this.Hide();
            Dashboard.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Notification Notifbox = new Notification();
            this.Hide();
            Notifbox.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegistrationForm Registrationbox = new RegistrationForm();
            this.Hide();
            Registrationbox.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Grades Gradesbox = new Grades();
            this.Hide();
            Gradesbox.ShowDialog();
        }



        private void button14_Click(object sender, EventArgs e)
        {
            Profile profileBox = new Profile();
            this.Hide();
            profileBox.ShowDialog();
        }



        private void loginbtn_Click(object sender, EventArgs e)
        {
            panelsidemenu.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (firstName.Text == "" || middleName.Text == "" || lastName.Text == "" || address.Text == "" || contactno.Text == "")
            {
                MessageBox.Show("All field is rquired!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand addaccount = new SqlCommand("INSERT INTO registrationForms(FirstName,MiddleName,LastName,Address,Contact) VALUES(@FirstName,@MiddleName,@LastName,@Address,@Contact)");
                addaccount.Connection = con;
                con.Open();

                addaccount.Parameters.AddWithValue("@FirstName", firstName.Text);
                addaccount.Parameters.AddWithValue("@MiddleName", middleName.Text);
                addaccount.Parameters.AddWithValue("@LastName", lastName.Text);
                addaccount.Parameters.AddWithValue("@Address", address.Text);
                addaccount.Parameters.AddWithValue("@Contact", contactno.Text);



                addaccount.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Student Information successfully saved", "Add New Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                firstName.Text = "";
                middleName.Text = "";
                lastName.Text = "";
                address.Text = "";
                contactno.Text = "";

            }
            loadinfo();





        }


  

        private void label7_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button11_Click(object sender, EventArgs e)
        {
            if (!(txtID.Text == string.Empty))
            {
                studentinfolv.SelectedItems[0].Remove();
                SqlConnection con = new SqlConnection(cs);
                con.ConnectionString = cs;
                string query = "Delete from registrationForms where userID ='" + this.txtID.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader myreader;
                try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("Successfully data deleted", "Removing Information");
                    while (myreader.Read())
                    {

                    }
                    con.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.Message);
                }

            }
            else
            {
                MessageBox.Show("Enter ID you want to delete");
            }

        }



        private void Loadlist()
        {
            if (firstName.Text != "" || middleName.Text != "" || lastName.Text != "" || address.Text != "" || contactno.Text != "")
            {
                cn.Open();
                cmd.CommandText = "Update info set MiddleName='" + middleName.Text + "', FirstName='" + firstName.Text + "' ='" + studentinfolv.ToString() + "' and name= '" + studentinfolv.ToString() + "'";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record Deleted");
                Loadlist();
                firstName.Text = "";
                lastName.Text = "";

            }
        }

 
        private void button2_Click_2(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            con.ConnectionString = cs;
            con.Open();
            SqlCommand cmd = new SqlCommand("Update registrationForms set FirstName ='" + firstName.Text + "', MiddleName ='" + middleName.Text + "', LastName ='" + lastName.Text + "', Address ='" + address.Text +"', Contact = '" + contactno.Text + "'where UserID ='" + txtID.Text +"'",con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();


            txtID.Text = string.Empty;
            firstName.Text = string.Empty;
            middleName.Text = string.Empty;
            lastName.Text = string.Empty;
            address.Text = string.Empty;
            contactno.Text = string.Empty;
            loadinfo();
            con.Close();
            MessageBox.Show(" Information Succesfully Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
   
        }


        private void studentinfolv_Click(object sender, EventArgs e)
        {
            ListViewItem item = studentinfolv.SelectedItems[0];
            txtID.Text = item.SubItems[0].Text;
            firstName.Text = item.SubItems[1].Text;
            middleName.Text = item.SubItems[2].Text;
            lastName.Text = item.SubItems[3].Text;
            address.Text = item.SubItems[4].Text;
            contactno.Text = item.SubItems[5].Text;
        }


    }
}

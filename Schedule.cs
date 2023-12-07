using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JLAcademy_Omblero
{
    public partial class Schedule : Form
    {
        public Schedule()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Labelsda_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Schedule_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            panelsidemenu.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home Dashboard = new Home();
            this.Hide();
            Dashboard.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Profile profileBox = new Profile();
            this.Hide();
            profileBox.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Schedule schedbox = new Schedule();
            this.Hide();
            schedbox.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Subjects Subjectbox = new Subjects();
            this.Hide();
            Subjectbox.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Grades Gradesbox = new Grades();
            this.Hide();
            Gradesbox.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegistrationForm Registrationbox = new RegistrationForm();
            this.Hide();
            Registrationbox.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Notification Notifbox = new Notification();
            this.Hide();
            Notifbox.ShowDialog();
        }
    }
}

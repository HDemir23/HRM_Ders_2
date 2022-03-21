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

namespace HRM_Ders_2
{
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahaka\Documents\MyEmployeesDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fetchempdata()
        {
            Con.Open();
            string query = "select * from EmployeeTbl where EmpId='" + EmpIdTb.Text + "'    ";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                EmpIdlbl.Text = dr ["EmpId"].ToString();
                EmpNamelbl.Text = dr ["EmpName"].ToString();
                EmpAddlbl.Text = dr ["EmpAdd"].ToString();
                EmpPoslbl.Text = dr["EmpPos"].ToString();
                EmpDoblbl.Text = dr["EmpDOB"].ToString();
                EmpPhonelbl.Text = dr["EmpPhone"].ToString();
                EmpEdulbl.Text = dr["EmpEdu"].ToString();
                EmpGenlbl.Text = dr["EmpGen"].ToString();
            }


            Con.Close();
        }
        private void ViewEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Employees emp = new Employees();
            emp.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            salary.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("======= EMPLOYEE SUMMARY =======",new Font("Century Gothic",20,FontStyle.Bold),Brushes.Red,new Point(170));
            e.Graphics.DrawString("Employee ID: "+EmpIdlbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70,100));
            e.Graphics.DrawString("Employee Name: " + EmpNamelbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 140));
            e.Graphics.DrawString("Employee Address: " + EmpAddlbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 180));
            e.Graphics.DrawString("Employee Gender: " + EmpGenlbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 220));
            e.Graphics.DrawString("Employee Position: " + EmpPoslbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 260));
            e.Graphics.DrawString("Employee DOB: " + EmpDoblbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 300));
            e.Graphics.DrawString("Employee Phone: " + EmpPhonelbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 340));
            e.Graphics.DrawString("Employee Education: " + EmpEdulbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 380));

        }
    }
}

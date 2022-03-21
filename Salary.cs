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
using System.Data;
namespace HRM_Ders_2
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahaka\Documents\MyEmployeesDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button3_Click(object sender, EventArgs e)

        {
            
        }
        private void fetchempdata()
        {
            if(EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter Employee ID");
            }
            else
            {
                Con.Open();
                string query = "select * from EmployeeTbl where EmpId='" + EmpIdTb.Text + "'    ";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    //EmpIdlbl.Text = dr["EmpId"].ToString();
                    EmpNameTb.Text = dr["EmpName"].ToString();

                    EmpPosTb.Text = dr["EmpPos"].ToString();




                }
            }
          


            Con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        int DailyBase,total;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Employees emp = new Employees();
            emp.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ViewEmployee viewEmployee = new ViewEmployee();
            viewEmployee.Show();
            this.Hide();
        }

        private void SalarySlip_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printpreview.ShowDialog() == DialogResult.OK)
            {
                printdoc.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("======= SALARY SUMMARY =======", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(170));
            e.Graphics.DrawString("Employee ID          : " + EmpIdTb.Text,      new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 100));
            e.Graphics.DrawString("Employee Name        : " + EmpNameTb.Text,    new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 140));
            e.Graphics.DrawString("Employee Position    : " + EmpPosTb.Text,     new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 180));
            e.Graphics.DrawString("Worked Days          : " + WorkedTb.Text,     new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 220));
            e.Graphics.DrawString("Daily Pay            : " + DailyBase,         new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 260));
            e.Graphics.DrawString("Total Salary         : " + total,             new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 300));
          //  e.Graphics.DrawString("Employee Phone: " + EmpPhonelbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 340));
            //e.Graphics.DrawString("Employee Education: " + EmpEdulbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(70, 380));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(EmpPosTb.Text == "")
            {
                MessageBox.Show("Select an Employe");

            }else if(WorkedTb.Text == "" || Convert.ToInt32(WorkedTb.Text) > 28)
            {
                MessageBox.Show("Enter A Valid Number Of Days");
            }
            else
            {
                if(EmpPosTb.Text == "Manager")
                {
                    DailyBase = 1250;
                }
                else if(EmpPosTb.Text == "Senior Developer")
                {
                    DailyBase = 1000;
                }
                else if (EmpPosTb.Text == "Junior Developer")
                {
                    DailyBase = 850;
                }
                else 
                {
                    DailyBase = 650;
                }
                total = DailyBase * Convert.ToInt32(WorkedTb.Text);
                SalarySlip.Text = "Employee ID                :   " + EmpIdTb.Text + "\n" + "Employee Name           :   " + EmpNameTb.Text + "\n"+ "Employee Position       :   " + EmpPosTb.Text + "\n" + "Worked Days               :   " + WorkedTb.Text + "\n" + "Daily Balance               :   " + DailyBase + "\n"+ "Month Total Balance   :   " + total;

            }
        }
    }
}


//Manager
//Senior Developer
//Junior Developer
//Accountant
//Receptionist
//Tea Maker
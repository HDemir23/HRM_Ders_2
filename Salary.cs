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
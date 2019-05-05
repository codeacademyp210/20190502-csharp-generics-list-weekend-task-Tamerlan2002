using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {

        List<Employee> employeeList;
        public Form1()
        {
            InitializeComponent();  
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            WriteData();

        }
        
        public void CreateEmp()
        {

            employeeList = new List<Employee>();
            Employee emp = new Employee();
            string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            string numbersPattern = @"^-?[0-9][0-9,\.]+$";
            string onlyLetters = @"^[a-zA-Z]+$";
            bool isNameValid = Regex.IsMatch(NameText.Text, onlyLetters);
            bool isSurNameValid = Regex.IsMatch(SurnameText.Text, onlyLetters);
            bool isPositionValid = Regex.IsMatch(PositionText.Text, onlyLetters);
            bool isEmailValid = Regex.IsMatch(emailText.Text, emailPattern);
            bool isSalaryValid =  Regex.IsMatch(salaryText.Text, numbersPattern);
            
            if (!isNameValid)
            {
                MessageBox.Show("Please enter a valid Name");
                Application.Restart();
            }
            else
            {
                emp.Name = NameText.Text;
            }
            if (!isSurNameValid)
            {
                MessageBox.Show("Please enter a valid Surname");
                Application.Restart();
            }
            else
            {
                emp.Surname = SurnameText.Text;
            }
            if (!isEmailValid)
            {
                MessageBox.Show("Please enter a valid email");
                Application.Restart();
            }
            else
            {
                emp.Email = emailText.Text;
            }
            if (!isPositionValid)
            {
                MessageBox.Show("Please enter a valid Position");
                Application.Restart();
            }
            else
            {
                emp.Position = PositionText.Text;
            }
            if (!isSalaryValid)
            {
                MessageBox.Show("Please enter a valid Salary(Only Numbers)");
            }
            else
            {
                emp.Salary = Convert.ToDouble(salaryText.Text);
            }
            emp.ID = emp.GetId();
            employeeList.Add(emp);
            
        }
        public void WriteData()
        {
            CreateEmp();
            foreach (var item in employeeList)
            {
                //Adding Rows
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = item.ID;
                row.Cells[1].Value = item.Name;
                row.Cells[2].Value = item.Surname;
                row.Cells[3].Value = item.Email;
                row.Cells[4].Value = item.Position;
                row.Cells[5].Value = item.Salary;
                dataGridView1.Rows.Add(row);

            }
            
            //Clear Inputs
            NameText.Text = "";
            SurnameText.Text = "";
            emailText.Text = "";
            PositionText.Text = "";
            salaryText.Text = "";


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Deleting Rows
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);

            }
        }
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //Editing info
                DataGridViewRow dgvRowSel = dataGridView1.Rows[e.RowIndex];
                NameText.Text = dgvRowSel.Cells[1].Value.ToString();
                SurnameText.Text = dgvRowSel.Cells[2].Value.ToString();
                emailText.Text = dgvRowSel.Cells[3].Value.ToString();
                PositionText.Text = dgvRowSel.Cells[4].Value.ToString();
                salaryText.Text = dgvRowSel.Cells[5].Value.ToString();

                int index = dataGridView1.SelectedRows[0].Index;
            }

}

    private void EditButton_Click(object sender, EventArgs e)
        {
            //Changing edited info
            int index = dataGridView1.SelectedRows[0].Index;
            DataGridViewRow dgvRowSel = dataGridView1.Rows[index];
            dgvRowSel.Cells[1].Value = NameText.Text;
            dgvRowSel.Cells[2].Value = SurnameText.Text;
            dgvRowSel.Cells[3].Value = emailText.Text;
            dgvRowSel.Cells[4].Value = PositionText.Text;
            dgvRowSel.Cells[5].Value = salaryText.Text;
            Employee emp = new Employee
            {
                Name = NameText.Text,
                Surname = SurnameText.Text,
                Email = emailText.Text,
                Position = PositionText.Text,
                Salary = Convert.ToDouble(salaryText.Text)
            };


        }
    }
}


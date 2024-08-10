using EntityFrameWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Insert
        private void btnInsertWithEF_Click(object sender, EventArgs e)
        {
            using (var dbContext = new CsharpSampleDBEntities())
            {
                var student = new Student()
                {
                    FirstName = "Morteza",
                    LastName = "Chegeni",
                    NationalCode = "0023763191",
                    Gender = true
                };
                dbContext.Students.Add(student);
                dbContext.SaveChanges();
                MessageBox.Show("Insert Succ....");
            }
        }
        //Select
        private void btnSelectWithEF_Click(object sender, EventArgs e)
        {
            using (var dbContext = new CsharpSampleDBEntities())
            {
                var result = dbContext.Students.OrderBy(x => x.FirstName)
                .Select(x => new { x.Id, FullName = x.FirstName + " " + x.LastName, x.NationalCode });

                dataGridView1.DataSource = result.ToList();
            }
        }

        //Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            using (var db = new CsharpSampleDBEntities())
            {
                Student item = db.Students.Find(id);
                //Student item = db.Students.First(q => q.Id == id);
                //Student item = db.Students.FirstOrDefault(q => q.Id == id);
                //Student item = db.Students.Single(q => q.Id == id);
                //Student item = db.Students.SingleOrDefault(q => q.Id == id);

                db.Students.Remove(item);
                db.SaveChanges();
                MessageBox.Show("Delete Succ.....");
            }
        }

        //Update
        private void btnShowItemInfo_Click(object sender, EventArgs e)
        {
            {
                int id = Convert.ToInt32(txtId.Text);

                using (var db = new CsharpSampleDBEntities())
                {
                    Student item = db.Students.Find(id);

                    txtFirstName.Text = item.FirstName;
                    txtLastName.Text = item.LastName;
                    txtNationalCode.Text = item.NationalCode.ToString();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            using (var db = new CsharpSampleDBEntities())
            {
                Student item = db.Students.Find(id);

                item.FirstName = txtFirstName.Text;
                item.LastName = txtLastName.Text;
                item.NationalCode = txtNationalCode.Text;

                db.SaveChanges();
                MessageBox.Show("Update Succ......");

            }
        }
    }
}
    
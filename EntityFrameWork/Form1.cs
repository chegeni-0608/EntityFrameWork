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

        private void btnInsertWithEF_Click(object sender, EventArgs e)
        {
            using (var dbContext=new CsharpSampleDBEntities())
            {
                var student = new Student()
                {
                    FirstName = "Morteza",
                    LastName = "Chegeni",
                    NationalCode = 3962543600,
                    Gender = true
                };
                dbContext.Students.Add(student);
                dbContext.SaveChanges();
                MessageBox.Show("Insert Succ....");
            }
        }

        private void btnSelectWithEF_Click(object sender, EventArgs e)
        {
         using (var dbContext=new CsharpSampleDBEntities())
            {
                var result = dbContext.Students.OrderBy(x => x.FirstName)
                .Select(x => new { x.Id, FullName = x.FirstName + " " + x.LastName, x.NationalCode });

                dataGridView1.DataSource=result.ToList();
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

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
    }
}
    
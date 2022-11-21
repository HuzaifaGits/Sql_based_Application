using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign4
{

    public partial class Form1 : Form
    {
        Customer customer = new Customer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void insert_Click(object sender, EventArgs e)
        {
            customer.customerid = textBox1.Text;
            customer.companyname = textBox2.Text;
            customer.contactname = textBox3.Text;
            customer.phone = textBox4.Text;

            var success = customer.Insertcustomer(customer);
            if (success)
            {

                MessageBox.Show("Customer Data Inserted");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Error Occured");
            }
        }

        private void show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = customer.Showcustomer();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            customer.customerid = textBox1.Text;
            customer.companyname = textBox2.Text;
            customer.contactname = textBox3.Text;
            customer.phone = textBox4.Text;

            var success = customer.Deletecustomer(customer);
            if (success)
            {

                MessageBox.Show("Customer Data Deleted");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Error Occured");
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            customer.customerid = textBox1.Text;
            customer.companyname = textBox2.Text;
            customer.contactname = textBox3.Text;
            customer.phone = textBox4.Text;

            var success = customer.Updatecustomer(customer);
            if (success)
            {

                MessageBox.Show("Customer Data Updated");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Error Occured");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
    

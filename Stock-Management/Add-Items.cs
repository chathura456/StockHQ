using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TutorHQ.Models;
using TutorHQ.Controllers;
using TutorHQ.Navigation;
using TutorHQ.Views.Schedules;


namespace TutorHQ.Views.Student_Data
{
    public partial class Add_Items : Form

    {
       
        public Add_Items()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Closed += (s, args) => this.Close();
            if (this.WindowState == FormWindowState.Maximized)
            {
                dashboard.WindowState = FormWindowState.Maximized;
            }
            dashboard.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NavigateTo.To<Dashboard>(this);
        }

        private void button10_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();

            if (string.IsNullOrEmpty(textName.Text.Trim()))
            {
                textName.Focus();
                errorProvider1.SetError(textName, "Item Name Cannot be null");
            }
            else if (string.IsNullOrEmpty(textQty.Text.Trim()))
            {
                textQty.Focus();
                errorProvider1.SetError(textQty, "Quantity Cannot be null");
            }
            else
            {
                string name = textName.Text.Trim();
                int qty = int.Parse(textQty.Text.Trim());
                bool isAdded = DBconnection.AddNewItem(name, qty);
                if (isAdded)
                {
                    Clear();
                }
                else
                {
                    Clear();
                    MessageBox.Show("Database Error! \n", "Failed to add item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

           


            /* if (textBox1.Text == null)
             {
                 errorProvider1.SetError(textBox1, "Item Name is Required");
             }
             else { 

             }*/



            

        }

        public void Clear()
        {
            textName.Clear();
            textQty.Clear();
            errorProvider1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavigateTo.To<Dashboard>(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NavigateTo.To<StockLevels>(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NavigateTo.To<LoginForm>(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Add_Student_Load(object sender, EventArgs e)
        {
            
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void textQty_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
    }


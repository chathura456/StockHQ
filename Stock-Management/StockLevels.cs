using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TutorHQ.Controllers;
using TutorHQ.Models;
using TutorHQ.Navigation;
using TutorHQ.Views.Student_Data;


namespace TutorHQ.Views.Schedules
{
    public partial class StockLevels : Form
    {
        public StockLevels()
        {
            InitializeComponent();
        }

        private void Schedules_Load(object sender, EventArgs e)
        {
            LoadItemsToDataGridView();
        }

        private void LoadItemsToDataGridView()
        {
            // Retrieve the items from the database
            List<Item> items = DBconnection.GetAllItems();

            // Bind the list of items to the DataGridView
            dataGridViewItems.DataSource = items;

            // Optionally, set the column headers if needed
            dataGridViewItems.Columns["StockID"].HeaderText = "Stock ID";
            dataGridViewItems.Columns["ItemName"].HeaderText = "Item Name";
            dataGridViewItems.Columns["Quantity"].HeaderText = "Quantity";
            dataGridViewItems.Columns["DateAdded"].HeaderText = "Date Added";
            dataGridViewItems.Columns["Transaction"].HeaderText = "Transaction";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            NavigateTo.To<Dashboard>(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NavigateTo.To<Add_Items>(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NavigateTo.To<LoginForm>(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NavigateTo.To<Dashboard>(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

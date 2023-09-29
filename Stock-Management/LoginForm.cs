using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TutorHQ.Controllers;
using TutorHQ.Models;
using TutorHQ.Navigation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace TutorHQ
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();

            if(string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Email Cannot be null");
            }
            else if (string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                txtPass.Focus();
                errorProvider1.SetError(txtPass, "Password Cannot be null");
            }
            else {
                string email = txtEmail.Text.Trim();
                string pass = txtPass.Text.Trim();
                bool isAuthenticated = DBconnection.Login(email,pass);
                if (isAuthenticated)
                {
                    DialogResult result = MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        NavigateTo.To<Dashboard>(this);
                    }
                }
                else
                {
                    MessageBox.Show("Login Failed! \n", "Email or Password Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }




        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                txtPass.Focus();
                errorProvider1.SetError(txtPass, "Password Cannot be null");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

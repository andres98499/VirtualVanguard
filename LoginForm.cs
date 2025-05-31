using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualVanguard
{
    public partial class LoginForm : Form
    {
        private readonly SupabaseService _supabaseService;

        public LoginForm(SupabaseService supabaseService)
        {
            InitializeComponent();
            _supabaseService = supabaseService;
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text.Trim();
            string password = passwordBox.Text;

            bool success = await _supabaseService.LoginAsync(email, password);

            if (success)
            {
                // Login successful → Close login form and return OK result
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
        }
    }
}

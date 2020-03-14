using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminForm.Views
{
    public partial class LoginForm : MaterialForm
    {
        public LoginForm()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red400, Primary.Red400,
                Primary.Red400, Accent.Red700,
                TextShade.WHITE
            );
            InitializeComponent();
        }

        private void materialRaisedButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (materialSingleLineTextFieldUsername.Text == "admin" && materialSingleLineTextFieldPassword.Text == "admin")
                {
                    this.Hide();
                    var Form1 = new Form1();
                    Form1.Closed += (s, args) => this.Close();
                    Form1.Show();
                }
                else 
                {
                    errorProvider1.SetError(materialSingleLineTextFieldUsername, "Hibás bejelentkezési adatok!");
                }
            }
            catch
            {
                errorProvider1.SetError(materialSingleLineTextFieldUsername, "Ismeretlen hiba történt!");

            }
        }
    }
}

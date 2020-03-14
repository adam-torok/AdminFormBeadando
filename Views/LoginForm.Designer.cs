namespace AdminForm.Views
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialSingleLineTextFieldUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextFieldPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialRaisedButtonLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(95, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // materialSingleLineTextFieldUsername
            // 
            this.materialSingleLineTextFieldUsername.Depth = 0;
            this.materialSingleLineTextFieldUsername.Hint = "Az adminsztrátori felhasználónév";
            this.materialSingleLineTextFieldUsername.Location = new System.Drawing.Point(113, 290);
            this.materialSingleLineTextFieldUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextFieldUsername.Name = "materialSingleLineTextFieldUsername";
            this.materialSingleLineTextFieldUsername.PasswordChar = '\0';
            this.materialSingleLineTextFieldUsername.SelectedText = "";
            this.materialSingleLineTextFieldUsername.SelectionLength = 0;
            this.materialSingleLineTextFieldUsername.SelectionStart = 0;
            this.materialSingleLineTextFieldUsername.Size = new System.Drawing.Size(235, 28);
            this.materialSingleLineTextFieldUsername.TabIndex = 1;
            this.materialSingleLineTextFieldUsername.Text = "Felhasználónév";
            this.materialSingleLineTextFieldUsername.UseSystemPasswordChar = false;
            // 
            // materialSingleLineTextFieldPassword
            // 
            this.materialSingleLineTextFieldPassword.Depth = 0;
            this.materialSingleLineTextFieldPassword.Hint = "Az adminsztrátori felhasználónév";
            this.materialSingleLineTextFieldPassword.Location = new System.Drawing.Point(113, 337);
            this.materialSingleLineTextFieldPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextFieldPassword.Name = "materialSingleLineTextFieldPassword";
            this.materialSingleLineTextFieldPassword.PasswordChar = '*';
            this.materialSingleLineTextFieldPassword.SelectedText = "";
            this.materialSingleLineTextFieldPassword.SelectionLength = 0;
            this.materialSingleLineTextFieldPassword.SelectionStart = 0;
            this.materialSingleLineTextFieldPassword.Size = new System.Drawing.Size(235, 28);
            this.materialSingleLineTextFieldPassword.TabIndex = 2;
            this.materialSingleLineTextFieldPassword.Text = "Jelszó";
            this.materialSingleLineTextFieldPassword.UseSystemPasswordChar = false;
            // 
            // materialRaisedButtonLogin
            // 
            this.materialRaisedButtonLogin.Depth = 0;
            this.materialRaisedButtonLogin.Location = new System.Drawing.Point(150, 416);
            this.materialRaisedButtonLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonLogin.Name = "materialRaisedButtonLogin";
            this.materialRaisedButtonLogin.Primary = true;
            this.materialRaisedButtonLogin.Size = new System.Drawing.Size(161, 51);
            this.materialRaisedButtonLogin.TabIndex = 3;
            this.materialRaisedButtonLogin.Text = "Bejelentkezek";
            this.materialRaisedButtonLogin.UseVisualStyleBackColor = true;
            this.materialRaisedButtonLogin.Click += new System.EventHandler(this.materialRaisedButtonLogin_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(457, 530);
            this.Controls.Add(this.materialRaisedButtonLogin);
            this.Controls.Add(this.materialSingleLineTextFieldPassword);
            this.Controls.Add(this.materialSingleLineTextFieldUsername);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bejelentkezés";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextFieldUsername;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextFieldPassword;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonLogin;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
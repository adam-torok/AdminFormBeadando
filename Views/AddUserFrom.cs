using AdminForm.Interfaces;
using AdminForm.Models;
using AdminForm.Presenters;
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
    public partial class AddUserForm : MaterialForm, IUser
    {
        private int id;
        private UserPresenter Upresenter;
        public AddUserForm()
        {
            InitializeComponent();
            Upresenter = new UserPresenter(this);
        }
            
        public felhasznalo felhasznalo
        {
            get
            {
                var username = materialSingleLineTextFieldUsername.Text;
                var pass = materialSingleLineTextFieldPassword.Text;
                var email = materialSingleLineTextFieldEmail.Text;
                var profile_image = materialSingleLineTextFieldProfilePic.Text;
                var time = dateTimePickerTime.Value;
                var bio = materialSingleLineTextFieldBio.Text;
                var asd = new felhasznalo(id,username,pass,email,profile_image,time,bio);
                if(id > 0)
                {
                    asd.id = id;
                }
                return asd;
            }
            set
            {
                id = value.id;
                materialSingleLineTextFieldUsername.Text = value.felhnev;
                materialSingleLineTextFieldEmail.Text = value.email;
                materialSingleLineTextFieldPassword.Text = value.jelszo;
                materialSingleLineTextFieldBio.Text = value.bio;
                dateTimePickerTime.Value = value.time > new DateTime(0001, 01, 01, 0, 00, 00) ?
                value.time : new DateTime(1900, 1, 1);
            }
        }
      
        public string errorMsg {
            get => errorProvider1.GetError(materialSingleLineTextFieldUsername);
            set => errorProvider1.SetError(materialSingleLineTextFieldUsername, value);
        }
        public BindingList<felhasznalo> felhlist { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void materialRaisedButtonSaveUser_Click(object sender, EventArgs e)
        {
            Upresenter.Save(this.felhasznalo);
            if (string.IsNullOrEmpty(errorMsg))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void numericUpDownId_ValueChanged(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

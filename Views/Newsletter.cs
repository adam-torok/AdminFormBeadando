using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using AdminForm.Models;

namespace AdminForm.Views
{
    public partial class Newsletter : MaterialForm
    {
        public Newsletter()
        {
            InitializeComponent();
        }

        private void Newsletter_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'felhasznaloDataSet2.newsletter' table. You can move, or remove it, as needed.
            this.newsletterTableAdapter.Fill(this.felhasznaloDataSet2.newsletter);

        }

        private void materialRaisedButtonSendLetter_Click(object sender, EventArgs e)
        {
            List<string> listOfEmails = new List<string>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                LetterSubscriber subscirber = new LetterSubscriber(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value));
                listOfEmails.Add(subscirber.email);
            }
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("mymusicprodtestemail@gmail.com");
                foreach (var email in listOfEmails)
                {
                    mail.To.Add(email);
                    mail.Subject = materialSingleLineTextFieldSubject.Text;
                    mail.Body = richTextBoxBody.Text;
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("mymusicprodtestemail@gmail.com", "Asd12345qwe");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probléma történt az email küldése során!");
            }
        }
    }
}

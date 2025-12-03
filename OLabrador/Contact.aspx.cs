using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OLabrador
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Send_Click(object sender, EventArgs e)
        {
            // 1. validar os dados obrigatórios
            if (Name.Text.Trim() == "")
            {
                Alert.Text = "Digite seu nome";
            }
            else if (Email.Text.Trim() == "")
            {
                Alert.Text = "Digite seu e-mail";
            }
            else if (Message.Text.Trim() == "")
            {
                Alert.Text = "Digite a mensagem";
            }
            else
            {
                try
                {
                    // Create e-mail
                    MailMessage email = new MailMessage();
                    email.To.Add("contato@seudominio.com.br");
                    MailAddress from = new MailAddress("contato@seudominio.com.br");
                    email.From = from;
                    email.Subject = "E-mail enviado do form de contato";
                    email.Body = "Data: " + System.DateTime.Now.ToString() + "\n";
                    email.Body += "Nome: " + Name.Text + "\n";
                    email.Body += "E-mail: " + Email.Text + "\n";
                    email.Body += "Mensagem: " + Message.Text + "\n";
                    email.IsBodyHtml = false;

                    // Send e-mail
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "seudominio.com.br";
                    smtp.Credentials = new System.Net.NetworkCredential("contato@seudominio.com.br", "suasenha");
                    smtp.Send(email);
                }
                catch (Exception ex)
                {
                    Alert.Text = "Houve um problema ao enviar o e-mail";

                    string caminho = Server.MapPath("~/Exceptions.txt");
                    System.IO.File.AppendAllText(caminho, ex.ToString() + Environment.NewLine);
                }
            }
        }
    }
}
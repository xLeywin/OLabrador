using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OLabrador
{
    public partial class CreateNewAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            if (Nome.Text.Trim() == "")
            {
                Alerta.Text = "Digite o nome de usuário";
            }
            else if (Email.Text.Trim() == "")
            {
                Alerta.Text = "Digite o email";
            }
            else if (Senha.Text.Trim() == "")
            {
                Alerta.Text = "Digite a senha";
            }
            else if (SenhaConfirmar.Text.Trim() == "")
            {
                Alerta.Text = "Confirma a senha digitada";
            }
            else if (Senha.Text != SenhaConfirmar.Text)
            {
                Alerta.Text = "Digite a mesma senha nos dois campos";
            }
            else
            {
                try
                {
                    string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.accdb") + ";Persist Security Info=False;";

                    string sql = "INSERT INTO Usuario (nome, email, senha) VALUES ('" + Nome.Text + "', '" + Email.Text + "', '" + Senha.Text + "');";

                    Datapost.DB.DAO db = new Datapost.DB.DAO();
                    db.ConnectionString = conexao;
                    db.DataProviderName = Datapost.DB.DAO.ProviderName.OleDb;
                    db.Query(sql);

                    Nome.Text = "";
                    Email.Text = "";
                    Senha.Text = "";
                    SenhaConfirmar.Text = "";
                    Alerta.Text = "";
                }
                catch (Exception ex)
                {
                    string caminho = Server.MapPath("~/Exceptions.txt");
                    File.AppendAllText(caminho, ex.ToString() + Environment.NewLine);
                }
            }
        }
    }
}
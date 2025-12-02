using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OLabrador
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Entrar_Click(object sender, EventArgs e)
        {
            try
            {
                string email = Email.Text.Trim();
                string senha = Senha.Text.Trim();

                string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.accdb") + ";Persist Security Info=False;";

                string sql = "SELECT COUNT(*) AS resultado FROM Usuario WHERE email = '" + email + "' AND senha = '" + senha + "';";

                Datapost.DB.DAO db = new Datapost.DB.DAO();
                db.ConnectionString = conexao;
                db.DataProviderName = Datapost.DB.DAO.ProviderName.OleDb;
                DataTable dt = null;
                dt = (DataTable)db.Query(sql);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return; // Se não tiver resultado
                }
                DataRow row = dt.Rows[0];
                int count = Convert.ToInt32(row["resultado"]);

                if (count > 0)
                {
                    //Pegar o nome de usuário
                    conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.accdb") + ";Persist Security Info=False;";

                    sql = "SELECT nome FROM Usuario WHERE email = '" + email + "' AND senha= '" + senha + "';";
                    db.ConnectionString = conexao;
                    db.DataProviderName = Datapost.DB.DAO.ProviderName.OleDb;
                    string nome = Convert.ToString(db.Query(sql));

                    Session["autenticado"] = "";

                    FormsAuthentication.Initialize();

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, nome,
                    DateTime.Now, DateTime.Now.AddMinutes(40), false,
                    FormsAuthentication.FormsCookiePath);

                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(ticket)));

                    Response.Redirect(FormsAuthentication.GetRedirectUrl(nome, false));

                }
                else
                {
                    Alerta.Text = "Email ou senha inválida";
                }
            }
            catch (Exception ex)
            {
                string caminho = Server.MapPath("~/Exceptions.txt");
                System.IO.File.AppendAllText(caminho, ex.ToString() + Environment.NewLine);
            }
        }
    }
}
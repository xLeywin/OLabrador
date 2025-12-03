using Datapost.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OLabrador
{
    public partial class EditPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarDados();
            }
        }

        protected void BuscarDados()
        {
            string codigo = Request.QueryString["c"];

            string sql = "SELECT * FROM Post WHERE Codigo=" + codigo;

            string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.accdb") + ";Persist Security Info=False;";

            DAO db = new DAO();
            db.ConnectionString = conexao;
            db.DataProviderName = DAO.ProviderName.OleDb;
            DataTable dt = (DataTable)db.Query(sql);

            Codigo.Text = dt.Rows[0]["codigo"].ToString();
            Titulo.Text = dt.Rows[0]["titulo"].ToString();
            Subtitulo.Text = dt.Rows[0]["subtitulo"].ToString();
            Lide.Text = dt.Rows[0]["lide"].ToString();
            Conteudo.Text = dt.Rows[0]["conteudo"].ToString();
            Categoria.SelectedValue = dt.Rows[0]["cod_categoria"].ToString();
            Situacao.SelectedValue = dt.Rows[0]["situacao"].ToString();
            Imagem.ImageUrl = ResolveUrl("~/App_Files/" + dt.Rows[0]["imagem"]);
        }


        protected void Gravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Titulo.Text.Trim() == "")
                {
                    Alerta.Text = "Digite um título";
                }
                else if (Subtitulo.Text.Trim() == "")
                {
                    Alerta.Text = "Digite um subtítulo";
                }
                else if (Lide.Text.Trim() == "")
                {
                    Alerta.Text = "Digite um lide";
                }
                else if (Conteudo.Text.Trim() == "")
                {
                    Alerta.Text = "Digite o corpo do texto";
                }
                else if (Categoria.SelectedValue == "0")
                {
                    Alerta.Text = "Selecione uma categoria válida";
                }
                else
                {

                    string imagem = "";
                    if (FileUpload1.FileName != "")
                    {
                        string caminho = Server.MapPath("~/App_Files/");
                        imagem = Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(caminho + imagem);
                    }

                    string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.accdb") + ";Persist Security Info=False;";

                    string sql = "UPDATE Post SET titulo='" + Titulo.Text + "',subtitulo='" + Subtitulo.Text + "',lide= '" + Lide.Text + "', conteudo= '" + Conteudo.Text + "',cod_categoria=" + Categoria.SelectedValue + ",Situacao=" + Situacao.SelectedValue + ",imagem='" + imagem + "' WHERE codigo=" + Codigo.Text + ";";

                    DAO db = new DAO();
                    db.DataProviderName = DAO.ProviderName.OleDb;
                    db.ConnectionString = conexao;
                    db.Query(sql);

                    Response.Redirect("ShowPost.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                string caminho = Server.MapPath("~/Exceptions.txt");
                System.IO.File.AppendAllText(caminho, ex.ToString() + Environment.NewLine);
            }
        }

        protected void Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.accdb") + ";Persist Security Info=False;";

                string sql = "UPDATE Post SET situacao=0 WHERE codigo=" + Codigo.Text;

                DAO db = new DAO();
                db.DataProviderName = DAO.ProviderName.OleDb;
                db.ConnectionString = conexao;
                db.Query(sql);

                Response.Redirect("ShowPost.aspx");
            }
            catch (Exception ex)
            {
                string caminho = Server.MapPath("~/Exceptions.txt");
                System.IO.File.AppendAllText(caminho, ex.ToString() + Environment.NewLine);
            }
        }
    }
}
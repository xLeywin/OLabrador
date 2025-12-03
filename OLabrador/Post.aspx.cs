using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OLabrador
{
    public partial class Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowPost();
        }

        protected void ShowPost()
        {
            string postCode = Request.QueryString["p"];

            // Conection string to database
            // https://www.connectionstrings.com
            string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.accdb") + ";Persist Security Info=False;";
            string sql = @"SELECT Post.*, Categoria.nome AS categoria_nome, Usuario.nome AS autor_nome
                           FROM (Categoria INNER JOIN Post ON Categoria.codigo = Post.cod_categoria)
                           INNER JOIN Usuario ON Usuario.codigo = Post.cod_autor
                           WHERE Post.situacao = -1 AND Post.codigo = " + postCode +
                           " ORDER BY Post.data_postagem";


            Datapost.DB.DAO db = new Datapost.DB.DAO();
            db.ConnectionString = conexao;
            db.DataProviderName = Datapost.DB.DAO.ProviderName.OleDb;

            DataTable dt = null;
            try
            {
                dt = (DataTable)db.Query(sql);
            }
            catch (Exception ex)
            {
                string caminho = Server.MapPath("~/Exceptions.txt");
                File.AppendAllText(caminho, ex.ToString() + Environment.NewLine);
            }

            if (dt == null || dt.Rows.Count == 0) // If it has no results
            {
                Error.Visible = true;
                Error.Text = "Erro ao adquirir a postagem.";
                return; 
            }

            DataRow row = dt.Rows[0];

            TitlePost.Text = row["titulo"].ToString();
            Subtitle.Text = row["subtitulo"].ToString();
            PostDate.Text = "Data de postagem: " + Convert.ToDateTime(row["data_postagem"]).ToString("dd/MM/yyyy");
            Category.Text = "-   Categoria: " + row["categoria_nome"].ToString();
            Author.Text = "Publicado por: " + row["autor_nome"].ToString();
            Content.Text = row["conteudo"].ToString();
            Image.ImageUrl = "~/App_Files/" + row["imagem"].ToString();
        }

        protected void BackTo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
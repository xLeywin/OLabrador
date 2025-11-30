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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowPosts();
            }
        }

        protected void ShowPosts()
        {
            string filter = Request.QueryString["f"];

            // Conection sring to database
            // https://www.connectionstrings.com
            string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.accdb") + ";Persist Security Info=False;";
            string sql = @"SELECT Post.*, Categoria.nome AS categoria_nome, Usuario.nome AS autor_nome
                           FROM (Categoria INNER JOIN Post ON Categoria.codigo = Post.cod_categoria)
                           INNER JOIN Usuario ON Usuario.codigo = Post.cod_autor
                           WHERE Post.situacao = -1
                           ORDER BY Post.data_postagem";
            if (!string.IsNullOrEmpty(filter))
            {
               sql = @"SELECT Post.*, Categoria.nome AS categoria_nome, Usuario.nome AS autor_nome
                       FROM (Categoria INNER JOIN Post ON Categoria.codigo = Post.cod_categoria)
                       INNER JOIN Usuario ON Usuario.codigo = Post.cod_autor
                       WHERE Post.situacao = -1 AND Categoria.nome = '" + filter + "' " +
                       "ORDER BY Post.data_postagem";

                Cancel.Visible = true;
            }

            Datapost.DB.DAO db = new Datapost.DB.DAO();
            db.ConnectionString = conexao;
            db.DataProviderName = Datapost.DB.DAO.ProviderName.OleDb;

            try
            {
                GridViewGaleria.DataSource = db.Query(sql);
            }
            catch (Exception ex)
            {
                string caminho = Server.MapPath("~/Exceptions.txt");
                File.AppendAllText(caminho, ex.ToString() + Environment.NewLine);
            }
            GridViewGaleria.DataBind();
        }

        protected void GridViewGaleria_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }
            // Obtem os itens
            DataRowView rowView = (DataRowView)e.Item.DataItem;

            HyperLink ImageLink = (HyperLink)e.Item.FindControl("LinkImagem");
            Image ImagePost = (Image)e.Item.FindControl("Image");

            ImageLink.NavigateUrl = ResolveUrl("~/App_Files/") + rowView["imagem"].ToString();
            ImagePost.ImageUrl = ResolveUrl("~/App_Files/") + rowView["imagem"].ToString();

            Label Title = (Label)e.Item.FindControl("Title");
            Title.Text = rowView["titulo"].ToString();

            Label Subtitle = (Label)e.Item.FindControl("Subtitle");
            Subtitle.Text = rowView["subtitulo"].ToString();

            Label PostDate = (Label)e.Item.FindControl("PostDate");
            PostDate.Text = rowView["data_postagem"].ToString();

            

            //Label Author = (Label)e.Item.FindControl("Author");
            //Author.Text = "Autor: " + rowView["autor_nome"].ToString();

            //Label Category = (Label)e.Item.FindControl("Category");
            //Category.Text = "Categoria: " + rowView["categoria_nome"].ToString();

            //Label Lead = (Label)e.Item.FindControl("Lead");
            //Lead.Text = rowView["lide"].ToString();

            //Label Content = (Label)e.Item.FindControl("Content");
            //Content.Text = rowView["conteudo"].ToString();
        }

        protected void CatEconomia_Click(object sender, EventArgs e)
        {
            string choice = "Economia";
            Response.Redirect("Default.aspx?f=" + choice);
        }

        protected void CatPolitica_Click(object sender, EventArgs e)
        {
            string choice = "Política";
            Response.Redirect("Default.aspx?f=" + choice);
        }

        protected void CatCultura_Click(object sender, EventArgs e)
        {
            string choice = "Cultura";
            Response.Redirect("Default.aspx?f=" + choice);
        }

        protected void CatEsporte_Click(object sender, EventArgs e)
        {
            string choice = "Esporte";
            Response.Redirect("Default.aspx?f=" + choice);
        }

        protected void CatCienciaTec_Click(object sender, EventArgs e)
        {
            string choice = "Ciência e Tecnologia";
            Response.Redirect("Default.aspx?f=" + choice);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
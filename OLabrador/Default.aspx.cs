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

            // Conection string to database
            // https://www.connectionstrings.com
            string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.accdb") + ";Persist Security Info=False;";
            string sql = @"SELECT Post.*, Categoria.nome AS categoria_nome, Usuario.nome AS autor_nome
                           FROM (Categoria INNER JOIN Post ON Categoria.codigo = Post.cod_categoria)
                           INNER JOIN Usuario ON Usuario.codigo = Post.cod_autor
                           WHERE Post.situacao = -1
                           ORDER BY Post.data_postagem DESC";
            if (!string.IsNullOrEmpty(filter))
            {
               sql = @"SELECT Post.*, Categoria.nome AS categoria_nome, Usuario.nome AS autor_nome
                       FROM (Categoria INNER JOIN Post ON Categoria.codigo = Post.cod_categoria)
                       INNER JOIN Usuario ON Usuario.codigo = Post.cod_autor
                       WHERE Post.situacao = -1 AND Categoria.nome = '" + filter + "' " +
                       "ORDER BY Post.data_postagem DESC";

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
                return;

            DataRowView rowView = (DataRowView)e.Item.DataItem;

            HyperLink postLink = (HyperLink)e.Item.FindControl("PostLink");
            Image imagePost = (Image)e.Item.FindControl("Image");
            Label title = (Label)e.Item.FindControl("Title");
            Label subtitle = (Label)e.Item.FindControl("Subtitle");
            Label postDate = (Label)e.Item.FindControl("PostDate");

            string urlImagem = ResolveUrl("~/App_Files/") + rowView["imagem"].ToString();

            postLink.NavigateUrl = "~/Post.aspx?p=" + rowView["codigo"].ToString();
            imagePost.ImageUrl = urlImagem;

            title.Text = rowView["titulo"].ToString();
            subtitle.Text = rowView["subtitulo"].ToString();
            postDate.Text = Convert.ToDateTime(rowView["data_postagem"]).ToString("dd/MM/yyyy");
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

        protected void CatTecnologia_Click(object sender, EventArgs e)
        {
            string choice = "Tecnologia";
            Response.Redirect("Default.aspx?f=" + choice);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
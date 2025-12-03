using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OLabrador
{
    public partial class ShowPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exibir();
        }

        protected void Exibir()
        {
            try
            {
                string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.accdb") + ";Persist Security Info=False;";

                string sql = "SELECT codigo,titulo,data_postagem,cod_categoria,cod_autor,situacao FROM Post WHERE titulo LIKE '%" + BuscarPostagem.Text + "%' ORDER BY titulo ASC;";

                Datapost.DB.DAO db = new Datapost.DB.DAO();
                db.ConnectionString = conexao;
                db.DataProviderName = Datapost.DB.DAO.ProviderName.OleDb;
                Postagens.DataSource = db.Query(sql);
                Postagens.DataBind();
            }
            catch (Exception ex)
            {
                string caminho = Server.MapPath("~/Exceptions.txt");
                System.IO.File.AppendAllText(caminho, ex.ToString() + Environment.NewLine);
            }

        }

        protected void Inserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPost.aspx");

        }

        protected void Postagens_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigo = Postagens.SelectedRow.Cells[1].Text;
            Response.Redirect("EditPost.aspx?c=" + codigo);

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            BuscarPostagem.Text = "";
            Cancelar.Visible = false;
            Exibir();

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            Exibir();
            Cancelar.Visible = true;
        }
    }
}
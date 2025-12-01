using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OLabrador
{
    public partial class InsertPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Salvar_Click(object sender, EventArgs e)
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
            else if (CorpoDoTexto.Text.Trim() == "")
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
                if (!FileUpload1.HasFile)
                {
                    Alerta.Text = "Adicione uma foto para a postagem";
                }
                else
                {
                    string caminho = Server.MapPath("~/App_Files/");
                    imagem = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(caminho + imagem);
                }
                try
                {

                    string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/DataBase.accdb") + ";Persist Security Info=False;";
                    //falta adicionar o autor
                    string sql = "INSERT INTO Post(titulo, subtitulo, conteudo, lide, data_postagem, situacao, imagem, cod_categoria) VALUES('" + Titulo.Text + "', '" + Subtitulo.Text + "', '" + CorpoDoTexto.Text + "', '" + Lide.Text + "', '" + DateTime.Now.ToString() + "', " + Situacao.SelectedValue + ", '" + imagem + "', '" + Categoria.SelectedValue + "');";

                    Datapost.DB.DAO db = new Datapost.DB.DAO();
                    db.ConnectionString = conexao;
                    db.DataProviderName = Datapost.DB.DAO.ProviderName.OleDb;
                    db.Query(sql);

                    Titulo.Text = "";
                    Subtitulo.Text = "";
                    CorpoDoTexto.Text = "";
                    Lide.Text = "";
                    Situacao.Text = "";
                    Categoria.Text = "";
                }

                catch (Exception ex)
                {
                    string caminho = Server.MapPath("~/Exceptions.txt");
                    System.IO.File.AppendAllText(caminho, ex.ToString() + Environment.NewLine);
                }
            }
        }
    }
}
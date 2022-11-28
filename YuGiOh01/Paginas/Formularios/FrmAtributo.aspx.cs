using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YuGiOh01.DAO;

namespace YuGiOh01.Paginas.Formularios
{
    public partial class FrmAtributo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularLvAtributo(AtributoDAO.ObterAtributos());

            }
        }

        private void PopularLvAtributo(List<Atributo> atributos)
        {
            lvlAtributos.DataSource = atributos;
            lvlAtributos.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            var descricao = txtAtributo.Text;
            var mensagem = "";
            try
            {
                if (descricao == "")
                {
                    mensagem = "Campo vazio";
                }
                else
                {
                    Atributo at = null;


                    if (btnCadastrar.Text.ToLower() == "alterar")
                    {
                        var id = Convert.ToInt32(hfId.Value);
                        at = AtributoDAO.ObterAtributo(id);



                    }
                    else
                    {
                        at = new Atributo();

                    }

                    at.Descricao = descricao;

                    if (btnCadastrar.Text.ToLower() == "alterar")
                    {
                        AtributoDAO.AlterarAtributo(at);
                        mensagem = "Atributo alterado com sucesso!";
                    }
                    else
                    {
                        AtributoDAO.CadastrarAtributo(at);
                        mensagem = "Atributo cadastrado com sucesso!";
                    }

                    PopularLvAtributo(AtributoDAO.ObterAtributos());

                    Response.Redirect("~/Paginas/Formularios/FrmAtributo.aspx");

                }
            }
            catch (Exception)
            {

                throw;
            }

            lblMensagem.InnerText = mensagem;
        }

        protected void btnAcoes_Command(object sender, CommandEventArgs e)
        {
            try
            {
                linkCad.Visible = true;
                lblMensagem.InnerText = "";
                var comando = e.CommandName.ToLower();
                var id = Convert.ToInt32(e.CommandArgument.ToString());

                if (comando == "alterar")
                {

                    AlterarAtributo(id);

                }
                else if (comando == "excluir")
                {
                    ExcluirAtributo(id);
                }
                else if (comando == "visualizar")
                {
                    VisualizarAtributo(id);
                }

            }
            catch (DbUpdateException sqlEx)
            {
                lblMensagem.InnerText = "Esse atributo está em uso!";
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void VisualizarAtributo(int id)
        {
            var atributo = AtributoDAO.ObterAtributo(id);
            txtAtributo.Text = atributo.Descricao.ToString();
            txtAtributo.Enabled = false;
            btnCadastrar.Visible = false;

        }

        private void ExcluirAtributo(int id)
        {
            txtAtributo.Enabled = true;
            btnCadastrar.Visible = true;
            AtributoDAO.ExcluirAtributo(id);
            PopularLvAtributo(AtributoDAO.ObterAtributos());
        }

        private void AlterarAtributo(int id)
        {
            txtAtributo.Enabled = true;
            btnCadastrar.Visible = true;

            var atributo = AtributoDAO.ObterAtributo(id);
            txtAtributo.Text = atributo.Descricao.ToString();

            btnCadastrar.Text = "Alterar";
            h1Titulo.InnerText = "Alterando Atributo";

            hfId.Value = id.ToString();
        }
    }

}
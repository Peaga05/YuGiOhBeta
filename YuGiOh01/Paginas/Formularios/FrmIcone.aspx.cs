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
    public partial class FrmIcone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularLvIcone(IconeDAO.ObterIcones());

            }
        }

        private void PopularLvIcone(List<Icone> tipos)
        {
            lvlIcone.DataSource = tipos;
            lvlIcone.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            var descricao = txtDescricaoIcone.Text;
            var mensagem = "";
            try
            {
                if (descricao == "")
                {
                    mensagem = "Campo vazio";
                }
                else
                {
                    Icone ic = null;


                    if (btnCadastrarIcone.Text.ToLower() == "alterar")
                    {
                        var id = Convert.ToInt32(hfId.Value);
                        ic = IconeDAO.ObterIcone(id);

                    }
                    else
                    {
                        ic = new Icone();

                    }

                    ic.Descricao = descricao;

                    if (btnCadastrarIcone.Text.ToLower() == "alterar")
                    {
                        IconeDAO.AlterarIcone(ic);
                        mensagem = "Ícone alterado com sucesso!";
                    }
                    else
                    {
                        IconeDAO.CadastrarIcone(ic);
                        mensagem = "Ícone cadastrado com sucesso!";
                    }

                    PopularLvIcone(IconeDAO.ObterIcones());

                    Response.Redirect("~/Paginas/Formularios/FrmIcone.aspx");

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

                    AlterarIcone(id);

                }
                else if (comando == "excluir")
                {
                    ExcluirIcone(id);
                }
                else if (comando == "visualizar")
                {
                    VisualizarIcone(id);
                }

            }
            catch (DbUpdateException sqlEx)
            {
                lblMensagem.InnerText = "Esse ícone está em uso!";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void VisualizarIcone(int id)
        {
            var icone = IconeDAO.ObterIcone(id);
            txtDescricaoIcone.Text = icone.Descricao.ToString();
            txtDescricaoIcone.Enabled = false;
            btnCadastrarIcone.Visible = false;

        }

        private void ExcluirIcone(int id)
        {
            IconeDAO.ExcluirIcone(id);
            PopularLvIcone(IconeDAO.ObterIcones());
            Response.Redirect("~/Paginas/Formularios/FrmIcone.aspx")
        }

        private void AlterarIcone (int id)
        {
            txtDescricaoIcone.Enabled = true;
            btnCadastrarIcone.Visible = true;

            var tipo = IconeDAO.ObterIcone(id);
            txtDescricaoIcone.Text = tipo.Descricao.ToString();

            btnCadastrarIcone.Text = "Alterar";
            titulo.InnerText = "Alterado Tipo Carta";

            hfId.Value = id.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using YuGiOh01.DAO;

namespace YuGiOh01.Paginas.Formularios
{
    public partial class FrmArmadilha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularLvArmadilha(ArmadilhaDAO.ObterArmadilhas());

            }
        }

        private void PopularLvArmadilha(List<Armadilha> armadilha)
        {
            lvlArmadilha.DataSource = armadilha;
            lvlArmadilha.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var descricao = txtArmadilha.Text;
            var mensagem = "";
            try
            {
                if (descricao == "")
                {
                    mensagem = "Campo vazio";
                }
                else
                {
                    TipoCarta tc = TipoCartaDAO.ObterTipoCarta("Armadilha");

                    if (tc == null)
                    {
                        mensagem = "Não existe o tipo armadilha cadastrada";
                    }
                    else
                    {
                        Armadilha am = null;


                        if (btnCadastrar.Text.ToLower() == "alterar")
                        {
                            var id = Convert.ToInt32(hfId.Value);
                            am = ArmadilhaDAO.ObterArmadilha(id);
                        }
                        else
                        {
                            am = new Armadilha();

                        }

                        am.Descricao = descricao;
                        am.IdTipoCarta = tc.IdTipoCarta;

                        if (btnCadastrar.Text.ToLower() == "alterar")
                        {
                            ArmadilhaDAO.AlterarArmadilha(am);
                            mensagem = "Armadilha alterado com sucesso!";
                        }
                        else
                        {
                            ArmadilhaDAO.CadastrarArmadilha(am);
                            mensagem = "Armadilha cadastrado com sucesso!";
                        }

                        PopularLvArmadilha(ArmadilhaDAO.ObterArmadilhas());

                        Response.Redirect("~/Paginas/Formularios/FrmArmadilha.aspx");

                    }
                }
                lblMensagem.InnerText = mensagem;
            }
            catch (Exception ex)
            {

                throw ex;
            }
   
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

                    AlterarArmadilha(id);

                }
                else if (comando == "excluir")
                {
                    ExcluirArmadilha(id);
                }
                else if (comando == "visualizar")
                {
                    VisualizarArmadilha(id);
                }

            }
            catch (DbUpdateException sqlEx)
            {
                lblMensagem.InnerText = "Essa armadilha está em uso!";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void VisualizarArmadilha(int id)
        {
            var armadilha = ArmadilhaDAO.ObterArmadilha(id);
            txtArmadilha.Text = armadilha.Descricao.ToString();
            txtArmadilha.Enabled = false;
            btnCadastrar.Visible = false;
        }

        private void ExcluirArmadilha(int id)
        {
            ArmadilhaDAO.ExcluirArmadilha(id);
            PopularLvArmadilha(ArmadilhaDAO.ObterArmadilhas());
            Response.Redirect("~/Paginas/Formularios/FrmArmadilha.aspx");
        }

        private void AlterarArmadilha(int id)
        {
            txtArmadilha.Enabled = true;
            btnCadastrar.Visible = true;

            var tipo = ArmadilhaDAO.ObterArmadilha(id);
            txtArmadilha.Text = tipo.Descricao.ToString();

            btnCadastrar.Text = "Alterar";
            h1Titulo.InnerText = "Alterando Armadilha";

            hfId.Value = id.ToString();
        }
    }
}
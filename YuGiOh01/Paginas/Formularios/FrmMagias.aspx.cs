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
    public partial class FrmMagias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularLvMagias(MagiasDAO.ObterMagias());

            }

        }

        private void PopularLvMagias(List<Magia> magias)
        {
            lvlMagia.DataSource = magias;
            lvlMagia.DataBind();    
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var descricao = txtMagia.Text;
            var mensagem = "";
            try
            {
                if (descricao == "")
                {
                    mensagem = "Campo vazio";
                }
                else
                {
                    TipoCarta tc = TipoCartaDAO.ObterTipoCarta("Magia");

                    if (tc == null)
                    {
                        mensagem = "Não existe o tipo magia cadastrada";
                    }
                    else
                    {
                        Magia mg = null;


                        if (btnCadastrar.Text.ToLower() == "alterar")
                        {
                            var id = Convert.ToInt32(hfId.Value);
                            mg = MagiasDAO.ObterMagia(id);
                        }
                        else
                        {
                            mg = new Magia();

                        }

                        mg.Descricao = descricao;
                        mg.IdTipoCarta = tc.IdTipoCarta;

                        if (btnCadastrar.Text.ToLower() == "alterar")
                        {
                            MagiasDAO.AlterarMagia(mg);
                            mensagem = "Magia alterado com sucesso!";
                        }
                        else
                        {
                            MagiasDAO.CadastrarMagia(mg);
                            mensagem = "Magia cadastrado com sucesso!";
                        }

                        PopularLvMagias(MagiasDAO.ObterMagias());

                        Response.Redirect("~/Paginas/Formularios/FrmMagias.aspx");

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

                    AlterarMagia(id);

                }
                else if (comando == "excluir")
                {
                    ExcluirMagia(id);
                }
                else if (comando == "visualizar")
                {
                    VisualizarMagia(id);
                }

            }
            catch (DbUpdateException sqlEx)
            {
                lblMensagem.InnerText = "Essa magia está em uso!";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void VisualizarMagia(int id)
        {
            var magia = MagiasDAO.ObterMagia(id);
            txtMagia.Text = magia.Descricao.ToString();
            txtMagia.Enabled = false;
            btnCadastrar.Visible = false;
        }

        private void ExcluirMagia(int id)
        {
            txtMagia.Enabled = true;
            btnCadastrar.Visible = true;
            MagiasDAO.ExcluirMagia(id);
            PopularLvMagias(MagiasDAO.ObterMagias());
        }

        private void AlterarMagia(int id)
        {
            txtMagia.Enabled = true;
            btnCadastrar.Visible = true;

            var magia = MagiasDAO.ObterMagia(id);
            txtMagia.Text = magia.Descricao.ToString();

            btnCadastrar.Text = "Alterar";
            h1Titulo.InnerText = "Alterando Mágia";

            hfId.Value = id.ToString();
        }
    }
}
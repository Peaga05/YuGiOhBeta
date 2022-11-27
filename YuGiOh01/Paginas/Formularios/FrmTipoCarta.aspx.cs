using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YuGiOh01.DAO;

namespace YuGiOh01.Paginas.Formularios
{
    public partial class FrmTipoCarta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularLvTipoCarta(TipoCartaDAO.ObterTiposCarta());
            }
        }

        private void PopularLvTipoCarta(List<TipoCarta> tipos)
        {
            lvlTipoCartas.DataSource = tipos;
            lvlTipoCartas.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var descricao = txtTipoCarta.Text;
            var mensagem = "";
            try
            {
                if(descricao == "")
                {
                    mensagem = "Campo vazio";
                }
                else
                {
                    TipoCarta tp = null; 
                   

                    if (btnCadastrar.Text.ToLower() == "alterar")
                    {
                        var id = Convert.ToInt32(hfId.Value);
                        tp = TipoCartaDAO.ObterTipoCarta(id);

                        

                    }
                    else
                    {
                        tp = new TipoCarta();

                    }

                    tp.Descricao = descricao;

                    if (btnCadastrar.Text.ToLower() == "alterar")
                    {
                        TipoCartaDAO.AlterarTipoCarta(tp);
                        mensagem = "Tipo carta alterado com sucesso!";
                    }
                    else
                    {
                        TipoCartaDAO.CadastrarTipoCarta(tp);
                        mensagem = "Tipo carta cadastrado com sucesso!";
                    }

                    PopularLvTipoCarta(TipoCartaDAO.ObterTiposCarta());

                    Response.Redirect("~/Paginas/Formularios/FrmTipoCarta.aspx");
                    
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
                var comando = e.CommandName.ToLower();
                var id = Convert.ToInt32(e.CommandArgument.ToString());

                if(comando == "alterar")
                {
                    AlterarTipoCarta(id);

                }
                else if(comando == "excluir")
                {
                    ExcluirTipoCarta(id);
                }
                else if(comando == "visualizar")
                {
                    VisualizarTipoCarta(id);
                }

            }
            catch(DbUpdateException sqlEx)
            {
                lblMensagem.InnerText = "Esse tipo de carta está em uso!";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void VisualizarTipoCarta(int id)
        {
            var tipoCarta = TipoCartaDAO.ObterTipoCarta(id);
            txtTipoCarta.Text = tipoCarta.Descricao.ToString(); 
            txtTipoCarta.Enabled = false;
            btnCadastrar.Visible = false;
        }

        private void ExcluirTipoCarta(int id)
        {

            TipoCartaDAO.ExcluirTipoCarta(id);
            PopularLvTipoCarta(TipoCartaDAO.ObterTiposCarta());
        }

        private void AlterarTipoCarta(int id)
        {
            var tipo = TipoCartaDAO.ObterTipoCarta(id);
            txtTipoCarta.Text = tipo.Descricao.ToString();

            btnCadastrar.Text = "Alterar";
            h1Titulo.InnerText = "Alterado Tipo Carta";

            hfId.Value = id.ToString();
        }
    }
}
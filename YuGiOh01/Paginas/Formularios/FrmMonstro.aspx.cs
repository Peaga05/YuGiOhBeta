using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YuGiOh01.DAO;

namespace YuGiOh01.Paginas.Formularios
{
    public partial class FrmMonstro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularLvMonstros(DAO.MonstroDAO.ObterMonstros());
            }
        }



        private void PopularLvMonstros(List<Monstro>  monstros)
        {
            lvMonstro.DataSource = monstros;
            lvMonstro.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var mensagem = "";
                var descricao = txtMonstro.Text;
                if (descricao != "")
                {
                    TipoCarta tc = DAO.TipoCartaDAO.ObterTipoCarta("monstro");
                    Monstro monstro = new Monstro();
                    if (tc != null)
                    {
                        monstro.Descricao = descricao;
                        monstro.IdTipoCarta = tc.IdTipoCarta;
                        DAO.MonstroDAO.CadastrarMonstro(monstro);
                        mensagem = "Monstro cadastrado com sucesso!";
                        txtMonstro.Text = "";

                    }
                    else
                    {
                        mensagem = "Ainda não existe o tipo Monstro!";
                    }
                }
                else
                {
                    mensagem = "Por favor, Insira uma descrição!";
                }
                lblMensagem.InnerText = mensagem;
                PopularLvMonstros(DAO.MonstroDAO.ObterMonstros());
            }
            catch (Exception ex)
            {
                lblMensagem.InnerText = "Ocorreu um erro ao realizar a operação " + ex.Message;
            }
        }

        protected void btnAcoes_Command(object sender, CommandEventArgs e)
        {
            try
            {
                lblMensagem.InnerText = "";

                var comando = e.CommandName.ToLower();
                var id = Convert.ToInt32(e.CommandArgument);
                if(comando == "alterar")
                {
                    btnNovoMonstro.Visible = true;
                }
                else if( comando == "visualizar")
                {
                    btnNovoMonstro.Visible = true;
                    VisualizarMonstro(id);
                }
                else if(comando == "excluir")
                {
                    ExcluirMonstro(id);
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void VisualizarMonstro(int id)
        {
            var monstro = MonstroDAO.ObterMonstro(id);
            txtMonstro.Text = monstro.Descricao.ToString();
            txtMonstro.Enabled = false;
            btnCadastrar.Visible = false;

        }

        private void ExcluirMonstro(int id)
        {
            try
            {
                MonstroDAO.ExcluirMonstro(id);
                PopularLvMonstros(MonstroDAO.ObterMonstros());
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
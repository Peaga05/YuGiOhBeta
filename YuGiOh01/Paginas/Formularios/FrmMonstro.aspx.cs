using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
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
                    Monstro monstro = null;
                    if (btnCadastrar.Text.ToLower() == "alterar")
                    {
                        var id = Convert.ToInt32(hfId.Value);
                        monstro = MonstroDAO.ObterMonstro(id);
                    }
                    else
                    {
                         monstro = new Monstro();
                    }
                  
                    
                    if (tc != null)
                    {
                        monstro.Descricao = descricao;
                        monstro.IdTipoCarta = tc.IdTipoCarta;

                        if(btnCadastrar.Text.ToLower() == "alterar")
                        {
                            MonstroDAO.AlterarMonstro(monstro);
                            mensagem = "Monstro Alterado com sucesso!";
                        }
                        else
                        {
                            DAO.MonstroDAO.CadastrarMonstro(monstro);
                            mensagem = "Monstro cadastrado com sucesso!";
                        } 
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
                PopularLvMonstros(MonstroDAO.ObterMonstros());
                Response.Redirect("~/Paginas/Formularios/FrmMonstro.aspx");
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
                    AlterarMonstro(id);
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

            }
            catch (DbUpdateException dbUpEx)
            {
                lblMensagem.InnerText = "Esse monstro não pode ser excluído pois está em uso";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void AlterarMonstro(int id)
        {
            txtMonstro.Enabled = true;
            btnCadastrar.Visible = true;

            var monstro = MonstroDAO.ObterMonstro(id);
            txtMonstro.Text = monstro.Descricao.ToString();
            btnCadastrar.Text = "Alterar";
            h1Titulo.InnerText = "Alterar Monstro";
            hfId.Value = monstro.IdMonstro.ToString();
            

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
            Response.Redirect("~/Paginas/Formularios/FrmMonstro.aspx");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            var login = (String)Session["user"];
            Session["user"] = null;
            LogUsuario log = (LogUsuario)Session["idLog"];
            Util.AtualizarUltimoAcesso(log);
            FormsAuthentication.SetAuthCookie(login, false);
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);
            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
            Response.Redirect("~/Default.aspx");

        }
    }
}
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
    public partial class FrmMonstroEfeito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularLvMonstoEfeito(MonstroEfeitoDAO.ObterMonstrosEfeitos());
            }
        }

        private void PopularLvMonstoEfeito(List<TipoMonstroEfeito> monstrosEfeitos)
        {
            lvMonstroEfeito.DataSource = monstrosEfeitos;
            lvMonstroEfeito.DataBind();
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
                    AlterarMonstroEfeito(id);
                    btnNovoMonstro.Visible = true;
                }else if(comando == "visualizar")
                {
                    VisualizarMonstroEfeito(id);
                    btnNovoMonstro.Visible = true;
                }else if(comando == "excluir")
                {
                    ExcluirMonstroEfeito(id);
                }

            }
            catch(DbUpdateException dbUpEx)
            {
                lblMensagem.InnerText = "Esse monstro de efeito não pode ser excluido pois está em uso";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           

        }

        private void ExcluirMonstroEfeito(int id)
        {
           
            MonstroEfeitoDAO.ExcluirMonstroEfeito(id);
            PopularLvMonstoEfeito(MonstroEfeitoDAO.ObterMonstrosEfeitos());
            Response.Redirect("~/Paginas/Formularios/FrmMonstroEfeito.aspx");
        }

        private void VisualizarMonstroEfeito(int id)
        {
            var tme = MonstroEfeitoDAO.ObterMonstroEfeito(id);
            txtMonstro.Text = tme.Descricao.ToString();
            txtMonstro.Enabled = false;
            btnCadastrar.Visible = false;

        }

        private void AlterarMonstroEfeito(int id)
        {
            txtMonstro.Enabled = true;
            btnCadastrar.Visible = true;

            var tme = MonstroEfeitoDAO.ObterMonstroEfeito(id);
            txtMonstro.Text = tme.Descricao.ToString();
            btnCadastrar.Text = "Alterar";
            h1Titulo.InnerText = "Alterar Monstro de Efeito";
            hfId.Value = tme.IdMonstroEfeito.ToString();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var mensagem = "";
                var descricao = txtMonstro.Text;
                if (descricao == "")
                {
                    mensagem = "Por favor, Insira uma descrição";
                }
                else
                {
                    Monstro monstro = MonstroDAO.ObterMonstro("efeito");
                    if (monstro == null)
                    {
                        mensagem = "O tipo Monstro de efeito ainda não foi adicionado";
                    }
                    else
                    {
                        TipoMonstroEfeito tme = null;
                        if (btnCadastrar.Text.ToLower() == "alterar")
                        {
                            var id = Convert.ToInt32(hfId.Value);
                            tme = MonstroEfeitoDAO.ObterMonstroEfeito(id);
                        }
                        else
                        {
                            tme = new TipoMonstroEfeito();
                        }

                        tme.Descricao = descricao;
                        tme.IdMonstro = monstro.IdMonstro;

                        if (btnCadastrar.Text.ToLower() == "alterar")
                        {
                            MonstroEfeitoDAO.AlterarMonstroEfeito(tme);
                        }
                        else
                        {
                            MonstroEfeitoDAO.CadastrarMonstroEfeito(tme);
                            mensagem = "Monstro de efeito cadastrado com sucesso";
                        }

                        PopularLvMonstoEfeito(MonstroEfeitoDAO.ObterMonstrosEfeitos());
                        txtMonstro.Text = "";
                        Response.Redirect("~/Paginas/Formularios/FrmMonstroEfeito.aspx");

                    }
                }
                lblMensagem.InnerText = mensagem;
            }
            catch (Exception ex)
            {
                lblMensagem.InnerText = "Ocorreu um erro " + ex.Message;
            }
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
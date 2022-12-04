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
    public partial class FrmMonstroPendulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularLvMonstroPendulos(MonstroPenduloDAO.ObterMonstrosPendulos());
            }
        }

        private void PopularLvMonstroPendulos(List<MonstroPendulo> monstrosPendulos )
        {
            lvMonstroPendulos.DataSource = monstrosPendulos;
            lvMonstroPendulos.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var mensagem = "";
                var descricao = txtMonstro.Text;
                if (descricao == "")
                {
                    mensagem = "Por favor, Insira uma descrição!";
                }
                else
                {
                    TipoMonstroEfeito tme = MonstroEfeitoDAO.ObterMonstroEfeito("pêndulo");
                    if(tme== null)
                    {
                        mensagem = "Ainda não foi cadastrado um monstro de efeito";
                    }
                    else
                    {
                        MonstroPendulo mp = null;
                        if(btnCadastrar.Text.ToLower() == "alterar")
                        {
                            var id = Convert.ToInt32(hfId.Value);
                            mp = MonstroPenduloDAO.ObterMonstroPendulo(id);
                        }
                        else
                        {
                            mp = new MonstroPendulo();
                        }

                        mp.Descricao = descricao;
                        mp.IdMonstroEfeito = tme.IdMonstroEfeito;

                        if (btnCadastrar.Text.ToLower() == "alterar")
                        {
                            MonstroPenduloDAO.AlterarMonstroPendulo(mp);
                            mensagem = "Monstro Pêndulo Alterado com sucesso!";
                        }
                        else
                        {
                            MonstroPenduloDAO.CadastrarMonstroPendulo(mp);
                            mensagem = "Monstro Pêndulo cadastrado com sucesso!";

                        }

                        lblMensagem.InnerText = mensagem;
                        txtMonstro.Text = "";
                        Response.Redirect("~/Paginas/Formularios/FrmMonstroPendulo.aspx");
                    }
                }

                lblMensagem.InnerText = mensagem;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAcoes_Command(object sender, CommandEventArgs e)
        {
            try
            {
                lblMensagem.InnerText = "";
                var comando = e.CommandName.ToLower();
                var id = Convert.ToInt32(e.CommandArgument.ToString());
                if(comando == "alterar")
                {
                    btnNovoMonstro.Visible = true;
                    AlterarMonstroPendulo(id);
                }
                else if(comando == "visualizar")
                {
                    btnNovoMonstro.Visible = true;
                    VisualizarMonstroPendulo(id);
                }else if(comando == "excluir")
                {
                    ExcluirMonstroPendulo(id);
                }

            }catch(DbUpdateException dpUpEx)
            {
                lblMensagem.InnerText = "Esse monstro pêndulo não pode ser excluido pois está em uso";
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private void AlterarMonstroPendulo(int id)
        {
            txtMonstro.Enabled = true;
            btnCadastrar.Visible = true;
            var mp = MonstroPenduloDAO.ObterMonstroPendulo(id);
            txtMonstro.Text = mp.Descricao.ToString();
            btnCadastrar.Text = "Alterar";
            h1Titulo.InnerText = "Alterar Monstro Pêndulo";
            hfId.Value = mp.IdMonstroPendulo.ToString();
        }

        private void VisualizarMonstroPendulo(int id)
        {
            var mp = MonstroPenduloDAO.ObterMonstroPendulo(id);
            txtMonstro.Text = mp.Descricao.ToString();
            txtMonstro.Enabled = false;
            btnCadastrar.Visible = false;
        }

        private void ExcluirMonstroPendulo(int id)
        {
            MonstroPenduloDAO.ExcluirMonstroPendulo(id);
            PopularLvMonstroPendulos(MonstroPenduloDAO.ObterMonstrosPendulos());
            Response.Redirect("~/Paginas/Formularios/FrmMonstroPendulo.aspx");
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
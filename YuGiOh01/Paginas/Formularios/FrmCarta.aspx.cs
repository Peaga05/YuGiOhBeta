using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using YuGiOh01.DAO;

namespace YuGiOh01.Paginas.Formularios
{
    public partial class FrmCarta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            { 

                PopularLvCarta(CartaDAO.ObterCartas());

                PopularDdls(
                    AtributoDAO.ObterAtributos(),
                    IconeDAO.ObterIcones(),
                    TipoCartaDAO.ObterTiposCarta(),
                    ArmadilhaDAO.ObterArmadilhas(),
                    MagiasDAO.ObterMagias(),
                    MonstroDAO.ObterMonstros(),
                    MonstroEfeitoDAO.ObterMonstrosEfeitos(),
                    MonstroPenduloDAO.ObterMonstrosPendulos()
                );
            }
            
                
        }

        private void PopularLvCarta(List<Carta> cartas)
        {
            lvCarta.DataSource = cartas;
            lvCarta.DataBind();
        }

        private void PopularDdls(List<Atributo> atributos, List<Icone> icones, List<TipoCarta> tipoCartas, List<Armadilha> armadilhas, List<Magia> magias, List<Monstro> monstros, List<TipoMonstroEfeito> tipoMonstroEfeitos, List<MonstroPendulo> monstroPendulos)
        {
            PopularDdlAtributo(atributos);
            PopularDdlTipoCarta(tipoCartas);
            PopularDdlArmadilha(armadilhas);
            PopularDdlIcones(icones);
            PopularDdlMagia(magias);
            PopularDdlMonstro(monstros);
            PopularDdlMonstroEfeito(tipoMonstroEfeitos);
            PopularDdlMonstroPendulo(monstroPendulos);
        }

        private void PopularDdlAtributo(List<Atributo> atributos)
        {
            ddlAtributo.DataSource = atributos.OrderBy(x => x.Descricao);
            ddlAtributo.DataTextField = "Descricao";
            ddlAtributo.DataValueField = "IdAtributo";
            ddlAtributo.DataBind();
            ddlAtributo.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlIcones(List<Icone> icones)
        {
            ddlIcone.DataSource = icones.OrderBy(x => x.Descricao);
            ddlIcone.DataTextField = "Descricao";
            ddlIcone.DataValueField = "IdIcone";
            ddlIcone.DataBind();
            ddlIcone.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlTipoCarta(List<TipoCarta> tiposcartas)
        {
            ddlTipoCarta.DataSource = tiposcartas.OrderBy(x => x.Descricao);
            ddlTipoCarta.DataTextField = "Descricao";
            ddlTipoCarta.DataValueField = "IdTipoCarta";
            ddlTipoCarta.DataBind();
            ddlTipoCarta.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlMagia(List<Magia> magias)
        {
            ddlMagias.DataSource = magias.OrderBy(x => x.Descricao);
            ddlMagias.DataTextField = "Descricao";
            ddlMagias.DataValueField = "IdMagias";
            ddlMagias.DataBind();
            ddlMagias.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlArmadilha(List<Armadilha> armadilhas)
        {
            ddlArmadilha.DataSource = armadilhas.OrderBy(x => x.Descricao);
            ddlArmadilha.DataTextField = "Descricao";
            ddlArmadilha.DataValueField = "IdArmadilha";
            ddlArmadilha.DataBind();
            ddlArmadilha.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlMonstro(List<Monstro> monstros)
        {
            ddlMonstro.DataSource = monstros.OrderBy(x => x.Descricao);
            ddlMonstro.DataTextField = "Descricao";
            ddlMonstro.DataValueField = "IdMonstro";
            ddlMonstro.DataBind();
            ddlMonstro.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlMonstroEfeito(List<TipoMonstroEfeito> monstrosEfeitos)
        {
            ddlMonstroEfeito.DataSource = monstrosEfeitos.OrderBy(x => x.Descricao);
            ddlMonstroEfeito.DataTextField = "Descricao";
            ddlMonstroEfeito.DataValueField = "IdMonstroEfeito";
            ddlMonstroEfeito.DataBind();
            ddlMonstroEfeito.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlMonstroPendulo(List<MonstroPendulo> monstroPendulos)
        {
            ddlMonstroPendulo.DataSource = monstroPendulos.OrderBy(x => x.IdMonstroPendulo);
            ddlMonstroPendulo.DataTextField = "Descricao";
            ddlMonstroPendulo.DataValueField = "IdMonstroPendulo";
            ddlMonstroPendulo.DataBind();
            ddlMonstroPendulo.Items.Insert(0, "Selecione ...");
        }


        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            try
            {
                var mensagem = "";
                Carta carta = null;
                CartaTipoCarta ctc = null;
                if (btnCadastrar.Text.ToLower() == "alterar")
                {
                    var id = Convert.ToInt32(hfIdCarta.Value);
                    carta = CartaDAO.ObterCarta(id);
                    ctc = CartaTipoCartaDAO.ObterCartaTipoCarta(id);
                }
                else
                {
                    carta = new Carta();
                    ctc = new CartaTipoCarta();
                }

                if(txtNomeCard.Text != "")
                {
                    carta.Nome = txtNomeCard.Text;
                }
                else
                {
                    mensagem = "Preencha o campo nome da carta</br>";
                }
                if(txtNumeroCarta.Text != "")
                {
                    carta.NumeroCard = txtNumeroCarta.Text;
                }
                else
                {
                    mensagem += "Preencha o campo numero da carta</br>";
                }
                if (txtDescricao.Text != "")
                {
                    carta.Descricao = txtDescricao.Text;
                }
                else
                {
                    mensagem  += "Preencha o campo descricão</br>";
                }

                if (txtNivel.Text != "")
                {
                    carta.Nivel = Convert.ToInt32(txtNivel.Text);
                }
                if(txtPontoAtaque.Text != "")
                {
                    carta.PontosAtaque = Convert.ToInt32(txtPontoAtaque.Text);
                }
                if(txtPontoDefesa.Text != "")
                {
                    carta.PontosDefesa = Convert.ToInt32(txtPontoDefesa.Text);
                }
                var idx = Convert.ToInt32(ddlTipoCarta.SelectedIndex);
                if(idx > 0)
                {
                    carta.IdTipoCarta = Convert.ToInt32(ddlTipoCarta.SelectedValue);
                }
                else
                {
                    mensagem += "Selecione o tipo da carta</br>";
                }

                idx = Convert.ToInt32(ddlAtributo.SelectedIndex);
                if (idx > 0)
                {
                    carta.IdAtributo = Convert.ToInt32(ddlAtributo.SelectedValue);
                    
                }

                idx = Convert.ToInt32(ddlIcone.SelectedIndex);
                if(idx > 0)
                {
                    carta.IdIcone = Convert.ToInt32(ddlIcone.SelectedValue);
                }


                if (ddlTipoCarta.SelectedItem.Text.ToLower() == "monstro")
                {
                    idx = Convert.ToInt32(ddlMonstro.SelectedIndex);
                    if (idx > 0)
                    {
                        ctc.IdMonstro = Convert.ToInt32(ddlMonstro.SelectedValue);
                        ctc.IdMonstroEfeito = null;
                        ctc.IdMonstroPendulo = null;
                        ctc.IdMagia = null;
                        ctc.IdArmadilha = null;

                        if (ddlMonstro.SelectedItem.Text.ToLower() == "efeito")
                        {
                            idx = Convert.ToInt32(ddlMonstroEfeito.SelectedIndex);
                            if (idx > 0)
                            {
                                ctc.IdMonstroEfeito = Convert.ToInt32(ddlMonstroEfeito.SelectedValue);
                                ctc.IdMonstroPendulo = null;

                                if (ddlMonstroEfeito.SelectedItem.Text.ToLower() == "pêndulo")
                                {
                                    idx = Convert.ToInt32(ddlMonstroPendulo.SelectedIndex);
                                    if(idx > 0)
                                    {
                                        ctc.IdMonstroPendulo = Convert.ToInt32(ddlMonstroPendulo.SelectedValue);
                                    }
                                    else
                                    {
                                        mensagem += "Selecione um monstro pêndulo</br>";
                                    }   
                                }
                            }
                            else
                            {
                                mensagem += "Selecione um monstro de efeito</br>";
                            }                            
                        }
                    }
                    else
                    {
                        mensagem += "Selecione um monstro</br>";
                    }
                }

                if (ddlTipoCarta.SelectedItem.Text.ToLower() == "magias")
                {
                    idx = Convert.ToInt32(ddlMagias.SelectedIndex);
                    if (idx > 0)
                    {
                        ctc.IdMagia = Convert.ToInt32(ddlMagias.SelectedValue);
                        ctc.IdMonstroEfeito = null;
                        ctc.IdMonstroPendulo = null;
                        ctc.IdMonstro = null;
                        ctc.IdArmadilha = null;
                    }
                    else
                    {
                        mensagem += "selecione um tipo de magia</br>";
                    }
                    
                }

                if (ddlTipoCarta.SelectedItem.Text.ToLower() == "armadilha")
                {
                    idx = Convert.ToInt32(ddlArmadilha.SelectedIndex);
                    if (idx > 0)
                    {
                        ctc.IdArmadilha = Convert.ToInt32(ddlArmadilha.SelectedValue);
                        ctc.IdMonstroEfeito = null;
                        ctc.IdMonstroPendulo = null;
                        ctc.IdMagia = null;
                        ctc.IdMonstro = null;
                    }
                    else
                    {
                        mensagem += "selecione um tipo de armadilha</br>";
                    }
                   
                }
                if (!fuImagem.HasFile)
                {
                    mensagem += "Cadastre uma imagem para a carta</br>";
                }

                if(mensagem == "")
                {
                    if (btnCadastrar.Text.ToLower() == "alterar")
                    {
                        carta = CartaDAO.AlterarCarta(carta);
                    }
                    else
                    {
                        carta = CartaDAO.CadastrarCarta(carta);
                    }

                    var arquivo = fuImagem.PostedFile;
                    var map = MapPath("~/");
                    var caminho = map + "Assets/Upload\\" + carta.IdCarta + ".png";
                    arquivo.SaveAs(caminho);

                    ctc.IdCarta = carta.IdCarta;
                    ctc.IdTipoCarta = carta.IdTipoCarta;


                    if (btnCadastrar.Text.ToLower() == "alterar")
                    {
                        CartaTipoCartaDAO.AlterarCartaTipoCarta(ctc);
                    }
                    else
                    {
                        CartaTipoCartaDAO.CadastrarCartaTipoCarta(ctc);

                    }

                    PopularLvCarta(CartaDAO.ObterCartas());
                    Response.Redirect("~/Paginas/Formularios/FrmCarta.aspx");
                }
                else
                {
                    lblMensagem.InnerHtml = mensagem;
                }

               

            }
            catch (DbUpdateException dbUpEx)
            {
                lblMensagem.InnerHtml += "<b>Por favor preencha os campos obrigatórios!</b>";
            }
            catch(Exception ex)
            {
                lblMensagem.InnerText += "Ocorreu um erro ao realizar a operação " + ex.Message;
            }

            PopularLvCarta(CartaDAO.ObterCartas());

        }

        protected void btnAcoes_Command(object sender, CommandEventArgs e)
        {
            var comando = e.CommandName.ToLower();
            var id = Convert.ToInt32(e.CommandArgument);
            if(comando == "alterar")
            {

                AlterarCarta(id);
                btnNovaCarta.Visible = true;
                ddlAcoes_SelectedIndexChanged(sender, e);

            }
            else if(comando == "visualizar")
            {

            }else if(comando == "excluir")
            {
                ExcluirImagemCarta(id);
                ExcluirCarta(id);
                lblMensagem.InnerText = "Carta excluída com sucesso!";
                Response.Redirect("~/Carta");
            }
        }

        private void ExcluirImagemCarta(int id)
        {
            try
            {
                FileInfo TheFile = new FileInfo(MapPath("~/") + "Assets/Upload\\" + id + ".png");
                if (TheFile.Exists)
                {
                    File.Delete(MapPath("~/") + "Assets/Upload\\"+ id + ".png");
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {
                lblMensagem.InnerText += "Ocorreu um erro ao realizar a operação " + ex.Message;
            }

        }

        private void ExcluirCarta(int id)
        {
            CartaTipoCartaDAO.ExcluirCartaTipoCarta(id);
            CartaDAO.ExcluirCarta(id);
            PopularLvCarta(CartaDAO.ObterCartas());
        }

        private void AlterarCarta(int id)
        {
            

            var carta = CartaDAO.ObterCarta(id);
            var cartaTipoCarta = CartaTipoCartaDAO.ObterCartaTipoCarta(id);
            PreencherDados(carta, cartaTipoCarta);
            btnCadastrar.Text = "Alterar";
            h1Titulo.InnerText = "Alterar Carta";
            hfIdCarta.Value = carta.IdCarta.ToString();
        }

        private void PreencherDados(Carta carta, CartaTipoCarta cartaTipoCarta)
        {
            txtNomeCard.Text = carta.Nome.ToString();
            ddlTipoCarta.SelectedValue = carta.IdTipoCarta.ToString();
            txtNumeroCarta.Text = carta.NumeroCard.ToString();
            txtDescricao.Text = carta.Descricao.ToString();

            if (carta.Nivel.HasValue)
            {
                txtNivel.Text = carta.Nivel.ToString();
            }
            if (carta.IdAtributo.HasValue)
            {
                ddlAtributo.SelectedValue = carta.IdAtributo.ToString();
            }
            if (carta.PontosDefesa.HasValue)
            {
                txtPontoDefesa.Text = carta.PontosDefesa.ToString();
            }
            if (carta.PontosAtaque.HasValue)
            {
                txtPontoAtaque.Text = carta.PontosAtaque.ToString();
            }
            if (carta.IdIcone.HasValue)
            {
                ddlIcone.Text = carta.IdIcone.ToString();
            }

            if (cartaTipoCarta.IdMagia.HasValue)
            {
                ddlMagias.SelectedValue = cartaTipoCarta.IdMagia.ToString();
            }
            if (cartaTipoCarta.IdArmadilha.HasValue)
            {
                ddlArmadilha.SelectedValue = cartaTipoCarta.IdArmadilha.ToString();
            }
            if (cartaTipoCarta.IdMonstro.HasValue)
            {
                ddlMonstro.SelectedValue = cartaTipoCarta.IdMonstro.ToString();
            }
            if (cartaTipoCarta.IdMonstroEfeito.HasValue)
            {
                ddlMonstroEfeito.SelectedValue = cartaTipoCarta.IdMonstroEfeito.ToString();
            }
            if (cartaTipoCarta.IdMonstroPendulo.HasValue)
            {
                ddlMonstroPendulo.SelectedValue = cartaTipoCarta.IdMonstroPendulo.ToString();
            }
        }

        protected void ddlAcoes_SelectedIndexChanged(object sender, EventArgs e)
        {

            var idx = Convert.ToInt32(ddlTipoCarta.SelectedIndex);

            if (idx > 0)
            {
                if (ddlTipoCarta.SelectedItem.Text.ToLower() == "magias")
                {
                    slMagias.Attributes.CssStyle.Value = "display:block";
                    slMonstro.Attributes.CssStyle.Value = "display:none";
                    slArmadilha.Attributes.CssStyle.Value = "display:none";
                    slMonstroEfeito.Attributes.CssStyle.Value = "display:none";
                    slMonstroPendulo.Attributes.CssStyle.Value = "display:none";
                    ddlMonstro.SelectedIndex = 0;
                    ddlArmadilha.SelectedIndex = 0;
                    ddlMonstroEfeito.SelectedIndex = 0;
                    ddlMonstroPendulo.SelectedIndex = 0;

                }
                if (ddlTipoCarta.SelectedItem.Text.ToLower() == "armadilha" )
                {
                    slArmadilha.Attributes.CssStyle.Value = "display:block";
                    slMonstro.Attributes.CssStyle.Value = "display:none";
                    slMagias.Attributes.CssStyle.Value = "display:none";
                    slMonstroEfeito.Attributes.CssStyle.Value = "display:none";
                    slMonstroPendulo.Attributes.CssStyle.Value = "display:none";
                    ddlMonstro.SelectedIndex = 0;
                    ddlMagias.SelectedIndex = 0;
                    ddlMonstroEfeito.SelectedIndex = 0;
                    ddlMonstroPendulo.SelectedIndex = 0;
                }
                if (ddlTipoCarta.SelectedItem.Text.ToLower() == "monstro")
                {
                    slMonstro.Attributes.CssStyle.Value = "display:block";
                    if (ddlMonstro.SelectedItem.Text.ToLower() == "efeito")
                    {
                        slMonstroEfeito.Attributes.CssStyle.Value = "display:block";
                        if (ddlMonstroEfeito.SelectedItem.Text.ToLower() == "pêndulo")
                        {
                            slMonstroPendulo.Attributes.CssStyle.Value = "display:block";
                        }
                        else
                        {
                            slMonstroPendulo.Attributes.CssStyle.Value = "display:none";
                        }
                    }
                    else
                    {
                        slMagias.Attributes.CssStyle.Value = "display:none";
                        slArmadilha.Attributes.CssStyle.Value = "display:none";
                        slMonstroEfeito.Attributes.CssStyle.Value = "display:none";
                        slMonstroPendulo.Attributes.CssStyle.Value = "display:none";
                        ddlMagias.SelectedIndex = 0;
                        ddlArmadilha.SelectedIndex = 0;
                        ddlMonstroEfeito.SelectedIndex = 0;
                        ddlMonstroPendulo.SelectedIndex = 0;
                    }
                    slMagias.Attributes.CssStyle.Value = "display:none";
                    slArmadilha.Attributes.CssStyle.Value = "display:none";
                    ddlMagias.SelectedIndex = 0;
                    ddlArmadilha.SelectedIndex = 0;
                    

                }


                if (ddlTipoCarta.SelectedItem.Text.ToLower() == "magias" || ddlTipoCarta.SelectedItem.Text.ToLower() == "armadilha")
                {
                    slIcone.Attributes.CssStyle.Value = "display:block";
                }
                else
                {
                    slIcone.Attributes.CssStyle.Value = "display:none";
                    ddlIcone.SelectedIndex = 0;
                }
            }
            else
            {
                slMagias.Attributes.CssStyle.Value = "display:none";
                slIcone.Attributes.CssStyle.Value = "display:none";
                slArmadilha.Attributes.CssStyle.Value = "display:none";
                slMonstro.Attributes.CssStyle.Value = "display:none";
                slMonstroEfeito.Attributes.CssStyle.Value = "display:none";
                slMonstroPendulo.Attributes.CssStyle.Value = "display:none";
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
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
            ddlAtributo.DataSource = atributos.OrderBy(x => x.IdAtributo);
            ddlAtributo.DataTextField = "Descricao";
            ddlAtributo.DataValueField = "IdAtributo";
            ddlAtributo.DataBind();
            ddlAtributo.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlIcones(List<Icone> icones)
        {
            ddlIcone.DataSource = icones.OrderBy(x => x.IdIcone);
            ddlIcone.DataTextField = "Descricao";
            ddlIcone.DataValueField = "IdIcone";
            ddlIcone.DataBind();
            ddlIcone.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlTipoCarta(List<TipoCarta> tiposcartas)
        {
            ddlTipoCarta.DataSource = tiposcartas.OrderBy(x => x.IdTipoCarta);
            ddlTipoCarta.DataTextField = "Descricao";
            ddlTipoCarta.DataValueField = "IdTipoCarta";
            ddlTipoCarta.DataBind();
            ddlTipoCarta.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlMagia(List<Magia> magias)
        {
            ddlMagias.DataSource = magias.OrderBy(x => x.IdMagias);
            ddlMagias.DataTextField = "Descricao";
            ddlMagias.DataValueField = "IdMagias";
            ddlMagias.DataBind();
            ddlMagias.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlArmadilha(List<Armadilha> armadilhas)
        {
            ddlArmadilha.DataSource = armadilhas.OrderBy(x => x.IdArmadilha);
            ddlArmadilha.DataTextField = "Descricao";
            ddlArmadilha.DataValueField = "IdArmadilha";
            ddlArmadilha.DataBind();
            ddlArmadilha.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlMonstro(List<Monstro> monstros)
        {
            ddlMonstro.DataSource = monstros.OrderBy(x => x.IdMonstro);
            ddlMonstro.DataTextField = "Descricao";
            ddlMonstro.DataValueField = "IdMonstro";
            ddlMonstro.DataBind();
            ddlMonstro.Items.Insert(0, "Selecione ...");
        }

        private void PopularDdlMonstroEfeito(List<TipoMonstroEfeito> monstrosEfeitos)
        {
            ddlMonstroEfeito.DataSource = monstrosEfeitos.OrderBy(x => x.IdMonstroEfeito);
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
                    var id = Convert.ToInt32(hfId.Value);

                }
                else
                {
                    carta = new Carta();
                    ctc = new CartaTipoCarta();
                }

                carta.Nome = txtNomeCard.Text;
                carta.NumeroCard = Convert.ToInt32(txtNumeroCarta.Text);
                carta.Descricao = txtDescricao.Text;

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
                    carta.IdTipoCarta = Convert.ToInt32(ddlTipoCarta.SelectedIndex);
                }

                idx = Convert.ToInt32(ddlAtributo.SelectedIndex);
                if (idx > 0)
                {
                    carta.IdAtributo = Convert.ToInt32(ddlAtributo.SelectedIndex);
                    
                }

                idx = Convert.ToInt32(ddlIcone.SelectedIndex);
                if(idx > 0)
                {
                    carta.IdIcone = Convert.ToInt32(ddlIcone.SelectedIndex);
                }

                

                
                if (btnCadastrar.Text.ToLower() == "alterar")
                {

                }
                else
                {
                    carta = CartaDAO.CadastrarCarta(carta);
                    

                }

                ctc.IdCarta = carta.IdCarta;
                ctc.IdTipoCarta = carta.IdTipoCarta;
                

                if(ddlTipoCarta.SelectedItem.Text.ToLower() == "monstro")
                {
                    ctc.IdEspecifico = Convert.ToInt32(ddlMonstro.SelectedIndex);

                    if (ddlMonstro.SelectedItem.Text.ToLower() == "efeito")
                    {
                        ctc.IdMonstroEfeito = Convert.ToInt32(ddlMonstroEfeito.SelectedIndex);

                        if (ddlMonstroEfeito.SelectedItem.Text.ToLower() == "pêndulo")
                        {
                            ctc.IdMonstroPendulo = Convert.ToInt32(ddlMonstroPendulo.SelectedIndex);
                        }
                    }
                }

                if (ddlTipoCarta.SelectedItem.Text.ToLower() == "magias")
                {
                    ctc.IdEspecifico = Convert.ToInt32(ddlMagias.SelectedIndex);
                }

                if (ddlTipoCarta.SelectedItem.Text.ToLower() == "armadilha")
                {
                    ctc.IdEspecifico = Convert.ToInt32(ddlArmadilha.SelectedIndex);
                }


                if (btnCadastrar.Text.ToLower() == "alterar")
                {

                }
                else
                {
                    CartaTipoCartaDAO.CadastrarCartaTipoCarta(ctc);


                }

            }
            catch (DbUpdateException dbUpEx)
            {
                lblMensagem.InnerHtml = "<b>Por favor preencha os campos obrigatórios!</b>";
            }
            catch(Exception ex)
            {
                lblMensagem.InnerText = "Ocorreu um erro ao realizar a operação " + ex.Message;
            }

            PopularLvCarta(CartaDAO.ObterCartas());

        }

        protected void btnAcoes_Command(object sender, CommandEventArgs e)
        {

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
                }
                if (ddlTipoCarta.SelectedItem.Text.ToLower() == "armadilha")
                {
                    slArmadilha.Attributes.CssStyle.Value = "display:block";
                    slMonstro.Attributes.CssStyle.Value = "display:none";
                    slMagias.Attributes.CssStyle.Value = "display:none";
                    slMonstroEfeito.Attributes.CssStyle.Value = "display:none";
                    slMonstroPendulo.Attributes.CssStyle.Value = "display:none";
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
                    }
                    slMagias.Attributes.CssStyle.Value = "display:none";
                    slArmadilha.Attributes.CssStyle.Value = "display:none";

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
    }
}
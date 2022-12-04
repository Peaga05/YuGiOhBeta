using System;
using System.Linq;
using System.Web.UI.WebControls.WebParts;

namespace YuGiOh01.DAO
{
    public class CartaTipoCartaDAO
    {
		internal static void AlterarCartaTipoCarta(CartaTipoCarta ctcAlterada)
		{
			try
			{
				using(var ctx = new YuGiOhBDEntities())
				{
					var ctc = ctx.CartasTipoCartas.FirstOrDefault(x => x.IdCarta == ctcAlterada.IdCarta);
					ctc.TipoCarta = ctcAlterada.TipoCarta;
                    ctc.IdCarta = ctcAlterada.IdCarta;

                    //txtNomeCard.Text = carta.Nome.ToString();
                    //ddlTipoCarta.SelectedValue = carta.IdTipoCarta.ToString();
                    //txtNumeroCarta.Text = carta.NumeroCard.ToString();
                    //txtDescricao.Text = carta.Descricao.ToString();

                    //if (carta.Nivel.HasValue)
                    //{
                    //    txtNivel.Text = carta.Nivel.ToString();
                    //}
                    //if (carta.IdAtributo.HasValue)
                    //{
                    //    ddlAtributo.SelectedValue = carta.IdAtributo.ToString();
                    //}
                    //if (carta.PontosDefesa.HasValue)
                    //{
                    //    txtPontoDefesa.Text = carta.PontosDefesa.ToString();
                    //}
                    //if (carta.PontosAtaque.HasValue)
                    //{
                    //    txtPontoAtaque.Text = carta.PontosAtaque.ToString();
                    //}
                    //if (carta.IdIcone.HasValue)
                    //{
                    //    ddlIcone.Text = carta.IdIcone.ToString();
                    //}
                    //if (cartaTipoCarta.IdMagia.HasValue)
                    //{
                    //    ddlMagias.SelectedValue = cartaTipoCarta.IdMagia.ToString();
                    //}
                    //if (cartaTipoCarta.IdArmadilha.HasValue)
                    //{
                    //    ddlArmadilha.SelectedValue = cartaTipoCarta.IdArmadilha.ToString();
                    //}
                    //if (cartaTipoCarta.IdMonstro.HasValue)
                    //{
                    //    ddlMonstro.SelectedValue = cartaTipoCarta.IdMonstro.ToString();
                    //}
                    //if (cartaTipoCarta.IdMonstroEfeito.HasValue)
                    //{
                    //    ddlMonstroEfeito.SelectedValue = cartaTipoCarta.IdMonstroEfeito.ToString();
                    //}
                    //if (cartaTipoCarta.IdMonstroPendulo.HasValue)
                    //{
                    //    ddlMonstroPendulo.SelectedValue = cartaTipoCarta.IdMonstroPendulo.ToString();
                    //}
                }
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		internal static void CadastrarCartaTipoCarta(CartaTipoCarta x)
        {
			try
			{
				using(var ctx = new YuGiOhBDEntities())
				{
					ctx.CartasTipoCartas.Add(x);
					ctx.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        internal static CartaTipoCarta ObterCartaTipoCarta(int id)
        {
			CartaTipoCarta ctc = null;
			try
			{
				using (var ctx = new YuGiOhBDEntities())
				{
					ctc = ctx.CartasTipoCartas.FirstOrDefault(x => x.IdCarta == id);
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return ctc;
        }
    }
}
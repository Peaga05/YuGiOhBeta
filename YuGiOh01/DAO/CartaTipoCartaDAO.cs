using System;
using System.Data.Entity.Infrastructure;
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
					ctc.IdTipoCarta = ctcAlterada.IdTipoCarta;
                    ctc.IdCarta = ctcAlterada.IdCarta;
                    ctc.IdMagia = ctcAlterada.IdMagia;
                    ctc.IdArmadilha = ctcAlterada.IdArmadilha;
                    ctc.IdMonstro = ctcAlterada.IdMonstro;
                    ctc.IdMonstroEfeito = ctcAlterada.IdMonstroEfeito;
                    ctc.IdMonstroPendulo = ctcAlterada.IdMonstroPendulo;
					ctx.SaveChanges();
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

        internal static void ExcluirCartaTipoCarta(int id)
        {
            try
            {

                using (var ctx = new YuGiOhBDEntities())
                {
                    var cartaTipoCarta = ctx.CartasTipoCartas.FirstOrDefault(
                            x => x.IdCartaTipoCarta == id
                        );

                    ctx.CartasTipoCartas.Remove(cartaTipoCarta);
                    ctx.SaveChanges();
                }
            }
            catch (DbUpdateException sqlEx)
            {
                throw new DbUpdateException(sqlEx.Message);
            }
            catch (Exception ex)
            {

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
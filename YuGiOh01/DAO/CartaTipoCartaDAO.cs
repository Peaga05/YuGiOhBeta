using System;

namespace YuGiOh01.DAO
{
    public class CartaTipoCartaDAO
    {
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
    }
}
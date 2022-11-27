using System;
using System.Linq;

namespace YuGiOh01.DAO
{
    public class TipoCartaDAO
    {
        public static TipoCarta ObterTipoCarta(string v)
        {
            TipoCarta tipoCarta = null;
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    tipoCarta = ctx.TipoCartas.FirstOrDefault(x => x.Descricao.ToLower() == v);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tipoCarta;
        }
    }
}
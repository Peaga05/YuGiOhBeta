using System;
using System.Collections.Generic;
using System.Linq;

namespace YuGiOh01.DAO
{
    public class CartaDAO
    {
        internal static Carta CadastrarCarta(Carta carta)
        {
            Carta cartaCadastrada = null;
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    cartaCadastrada = ctx.Cartas.Add(carta);
                    ctx.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return cartaCadastrada;
        }

        internal static List<Carta> ObterCartas()
        {
            List<Carta> cartas = null;
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    cartas = ctx.Cartas.OrderBy(x => x.Nome).ToList();
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cartas;
        }
    }
}
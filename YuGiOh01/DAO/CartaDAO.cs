using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace YuGiOh01.DAO
{
    public class CartaDAO
    {
        internal static Carta AlterarCarta(Carta cartaAlterada)
        {
            Carta carta = null;
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    carta = ctx.Cartas.FirstOrDefault(x => x.IdCarta == cartaAlterada.IdCarta);
                    carta.Nome = cartaAlterada.Nome;
                    carta.IdTipoCarta = cartaAlterada.IdTipoCarta;
                    carta.NumeroCard = cartaAlterada.NumeroCard;
                    carta.Descricao = cartaAlterada.Descricao;
                    carta.Nivel = cartaAlterada.Nivel;
                    carta.IdAtributo = cartaAlterada.IdAtributo;
                    carta.PontosDefesa = cartaAlterada.PontosDefesa;
                    carta.PontosAtaque = cartaAlterada.PontosAtaque;
                    carta.IdIcone = cartaAlterada.IdIcone;
                    ctx.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return carta;
        }

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

        internal static void ExcluirCarta(int id)
        {
            try
            {
                
                using (var ctx = new YuGiOhBDEntities())
                {
                    var carta = ctx.Cartas.FirstOrDefault(
                            x => x.IdCarta == id
                        );

                    ctx.Cartas.Remove(carta);
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

        internal static Carta ObterCarta(int id)
        {
            Carta carta = null;
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    carta = ctx.Cartas.FirstOrDefault(x => x.IdCarta == id);
                }

            }catch(Exception ex)
            {
                throw ex;
            }
            return carta;
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
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace YuGiOh01.DAO
{
    public class MonstroPenduloDAO
    {
        internal static void AlterarMonstroPendulo(MonstroPendulo mp)
        {
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    var mpAlterado = ctx.MonstrosPendulos.FirstOrDefault(x => x.IdMonstroPendulo == mp.IdMonstroPendulo);
                    mpAlterado.Descricao = mp.Descricao;
                    ctx.SaveChanges();

                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        internal static void CadastrarMonstroPendulo(MonstroPendulo mp)
        {
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    ctx.MonstrosPendulos.Add(mp);
                    ctx.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        internal static void ExcluirMonstroPendulo(int id)
        {
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    var mp = ctx.MonstrosPendulos.FirstOrDefault(x => x.IdMonstroPendulo == id);
                    ctx.MonstrosPendulos.Remove(mp);
                    ctx.SaveChanges();
                }
            }catch(DbUpdateException dbUpEx)
            {
                throw dbUpEx;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        internal static MonstroPendulo ObterMonstroPendulo(int id)
        {
            MonstroPendulo mp = null;
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    mp = ctx.MonstrosPendulos.FirstOrDefault(x => x.IdMonstroPendulo == id);
                }

            }catch(Exception ex)
            {
                throw ex;
            }
            return mp;
        }

        internal static List<MonstroPendulo> ObterMonstrosPendulos()
        {
            List<MonstroPendulo> monstrosPendulos = null;
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    monstrosPendulos = ctx.MonstrosPendulos.OrderBy(x => x.Descricao).ToList();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return monstrosPendulos;
        }
    }
}
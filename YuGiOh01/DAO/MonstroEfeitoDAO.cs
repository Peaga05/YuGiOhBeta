using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace YuGiOh01.DAO
{
    public class MonstroEfeitoDAO
    {
        public static List<TipoMonstroEfeito> ObterMonstrosEfeitos()
        {
            List<TipoMonstroEfeito> monstrosEfeitos = null;
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    monstrosEfeitos = ctx.TipoMonstrosEfeitos.OrderBy(x => x.Descricao).ToList();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return monstrosEfeitos;
        }

        internal static void AlterarMonstroEfeito(TipoMonstroEfeito tme)
        {
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    var tmeAlterado = ctx.TipoMonstrosEfeitos.FirstOrDefault(x => x.IdMonstroEfeito == tme.IdMonstroEfeito);
                    tmeAlterado.Descricao = tme.Descricao;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void CadastrarMonstroEfeito(TipoMonstroEfeito tme)
        {
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    ctx.TipoMonstrosEfeitos.Add(tme);
                    ctx.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        internal static void ExcluirMonstroEfeito(int id)
        {
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    var tme = ctx.TipoMonstrosEfeitos.FirstOrDefault(x => x.IdMonstroEfeito == id);
                    ctx.TipoMonstrosEfeitos.Remove(tme);
                    ctx.SaveChanges();
                }
            }catch(DbUpdateException dpUpEx)
            {
                throw dpUpEx;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        internal static TipoMonstroEfeito ObterMonstroEfeito(int id)
        {
            TipoMonstroEfeito tme = null;
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    tme = ctx.TipoMonstrosEfeitos.FirstOrDefault(x => x.IdMonstroEfeito == id);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return tme;
        }

        internal static TipoMonstroEfeito ObterMonstroEfeito(string v)
        {
            TipoMonstroEfeito tme = null;
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    tme = ctx.TipoMonstrosEfeitos.FirstOrDefault(x => x.Descricao.ToLower() == v);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tme;
        }
    }
}
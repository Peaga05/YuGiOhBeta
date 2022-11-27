using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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

        public static TipoCarta ObterTipoCarta(int v)
        {
            TipoCarta tipoCarta = null;
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    tipoCarta = ctx.TipoCartas.FirstOrDefault(x => x.IdTipoCarta == v);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tipoCarta;
        }

        internal static void AlterarTipoCarta(TipoCarta tp)
        {

            try
            {

                using (var ctx = new YuGiOhBDEntities())
                {
                    var tipoCartaAlterado = ctx.TipoCartas.FirstOrDefault(
                            x => x.IdTipoCarta == tp.IdTipoCarta
                        ); 

                    tipoCartaAlterado.Descricao = tp.Descricao;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static void CadastrarTipoCarta(TipoCarta tp)
        {
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    ctx.TipoCartas.Add(tp);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        internal static void ExcluirTipoCarta(int id)
        {
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    var tipoCarta = ctx.TipoCartas.FirstOrDefault(
                            x => x.IdTipoCarta == id
                        );

                    ctx.TipoCartas.Remove( tipoCarta );
                    ctx.SaveChanges();
                }
            }
            catch (DbUpdateException sqlEx)
            {
                throw new DbUpdateException(sqlEx.Message);
            }
            catch(Exception ex)
            {

            }
        }

        internal static List<TipoCarta> ObterTiposCarta()
        {
            List<TipoCarta> tipos = null;
            try
            {
                
                using(var ctx = new YuGiOhBDEntities())
                {
                    tipos = ctx.TipoCartas.OrderBy(x => x.Descricao).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tipos;
        }
    }
}
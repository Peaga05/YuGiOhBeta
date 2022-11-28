using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;

namespace YuGiOh01.DAO
{
    public class MonstroDAO
    {
        public static void CadastrarMonstro(Monstro monstro)
        {
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    ctx.Monstros.Add(monstro);
                    ctx.SaveChanges();
                }

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entidade do tipo \"{0}\" com estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Propriedade: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AlterarMonstro(Monstro monstro)
        {
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    var monstroAlterado = ctx.Monstros.FirstOrDefault(x => x.IdMonstro == x.IdMonstro);
                    monstroAlterado.Descricao = monstro.Descricao;
                    ctx.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void ExcluirMonstro(int id)
        {
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    var monstro = ctx.Monstros.FirstOrDefault(x => x.IdMonstro == id);
                    ctx.Monstros.Remove(monstro);
                    ctx.SaveChanges();
                }
            }catch(DbUpdateException dbUpEx)
            {
                throw dbUpEx;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static Monstro ObterMonstro(int id)
        {
            Monstro monstro = null;
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    monstro = ctx.Monstros.FirstOrDefault(x => x.IdMonstro == id);
                }
            }catch( Exception ex)
            {
                throw ex;
            }
            return monstro;
        }

        public static List<Monstro> ObterMonstros()
        {
            List<Monstro> monstros = null;
            try
            {
                using(var ctx = new YuGiOhBDEntities())
                {
                    monstros = ctx.Monstros.OrderBy(x => x.Descricao).ToList();
                }
            }catch(Exception ex)
            {
                throw;
            }
            return monstros;
        }

        internal static Monstro ObterMonstro(string v)
        {
            Monstro monstro = null;
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    monstro = ctx.Monstros.FirstOrDefault(x => x.Descricao.ToLower() == v);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return monstro;
        }
    }
}
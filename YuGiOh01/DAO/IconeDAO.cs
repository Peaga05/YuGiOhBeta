using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace YuGiOh01.DAO
{
    public class IconeDAO
    {

        public static void CadastrarIcone(Icone icone)
        {
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    ctx.Icones.Add(icone);
                    ctx.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Icone ObterIcone(string v)
        {
            Icone icone = null;
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    icone = ctx.Icones.FirstOrDefault(x => x.Descricao.ToLower() == v);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return icone;
        }

        public static Icone ObterIcone(int v)
        {
            Icone icone = null;
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    icone = ctx.Icones.FirstOrDefault(x => x.IdIcone == v);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return icone;
        }

        internal static void AlterarIcone(Icone ic)
        {

            try
            {

                using (var ctx = new YuGiOhBDEntities())
                {
                    var iconeAlterado = ctx.Icones.FirstOrDefault(
                            x => x.IdIcone == ic.IdIcone
                        ) ;

                    iconeAlterado.Descricao = ic.Descricao;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static void ExcluirIcone(int id)
        {
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    var icone = ctx.Icones.FirstOrDefault(
                            x => x.IdIcone == id
                        );

                    ctx.Icones.Remove(icone);
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

        internal static List<Icone> ObterIcones()
        {
            List<Icone> icones = null;
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    icones = ctx.Icones.OrderBy(x => x.IdIcone).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return icones;
        }
    }
}
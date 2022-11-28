using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace YuGiOh01.DAO
{
    public class AtributoDAO
    {

        public static Atributo ObterAtributo(string v)
        {
            Atributo atributo = null;
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    atributo = ctx.Atributos.FirstOrDefault(x => x.Descricao.ToLower() == v);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return atributo;
        }

        public static Atributo ObterAtributo(int v)
        {
            Atributo atributo = null;
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    atributo = ctx.Atributos.FirstOrDefault(x => x.IdAtributo == v);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return atributo;
        }

        internal static void AlterarAtributo(Atributo at)
        {

            try
            {

                using (var ctx = new YuGiOhBDEntities())
                {
                    var AtributoAlterado = ctx.Atributos.FirstOrDefault(
                            x => x.IdAtributo == at.IdAtributo
                        );

                    AtributoAlterado.Descricao = at.Descricao;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static void CadastrarAtributo(Atributo at)
        {
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    ctx.Atributos.Add(at);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        internal static void ExcluirAtributo(int id)
        {
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    var atributo = ctx.Atributos.FirstOrDefault(
                            x => x.IdAtributo == id
                        );

                    ctx.Atributos.Remove(atributo);
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

        internal static List<Atributo> ObterAtributos()
        {
            List<Atributo> atributos = null;
            try
            {

                using (var ctx = new YuGiOhBDEntities())
                {
                    atributos = ctx.Atributos.OrderBy(x => x.Descricao).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return atributos;
        }
    }
}
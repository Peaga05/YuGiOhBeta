using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace YuGiOh01.Paginas.Formularios
{
    internal class MagiasDAO
    {
        internal static void AlterarMagia(Magia mg)
        {
            try
            {

                using (var ctx = new YuGiOhBDEntities())
                {
                    var tipoMagiaAlterado = ctx.Magias.FirstOrDefault(
                            x => x.IdMagias == mg.IdMagias
                        );

                    tipoMagiaAlterado.Descricao = mg.Descricao;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static void CadastrarMagia(Magia mg)
        {
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    ctx.Magias.Add(mg);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        internal static void ExcluirMagia(int id)
        {
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    var magia = ctx.Magias.FirstOrDefault(
                            x => x.IdMagias == id
                        );

                    ctx.Magias.Remove(magia);
                    ctx.SaveChanges();
                }
            }
            catch (DbUpdateException sqlEx)
            {
                throw new DbUpdateException(sqlEx.Message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        internal static Magia ObterMagia(int id)
        {
            Magia magia = null;

            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    magia = ctx.Magias.FirstOrDefault(
                            x => x.IdMagias == id
                        );
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return magia;
        }

        internal static List<Magia> ObterMagias()
        {
            List<Magia> magias = null;
            try
            {
                using (var ctx = new YuGiOhBDEntities())
                {
                    magias = ctx.Magias.OrderBy(x => x.Descricao).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return magias;
        }
    }
}
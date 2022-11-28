using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace YuGiOh01.Paginas.Formularios
{
    internal class ArmadilhaDAO
    {
        internal static void AlterarArmadilha(Armadilha am)
        {
			try
			{
				using (var ctx = new YuGiOhBDEntities())
				{
					var armadilha = ctx.Armadilhas.FirstOrDefault(
							x => x.IdArmadilha == am.IdArmadilha
						);

					armadilha.Descricao = am.Descricao;
					ctx.SaveChanges();
				}
			}
			catch (Exception ex)
			{

                throw new Exception(ex.Message);
            }
        }

        internal static void CadastrarArmadilha(Armadilha am)
        {
			try
			{
				using (var ctx = new YuGiOhBDEntities())
				{
					ctx.Armadilhas.Add(am);
					ctx.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw;
            }
        }

        internal static List<Armadilha> ObterArmadilhas()
        {
			List<Armadilha> armadilhas = null;
			try
			{
				using(var ctx = new YuGiOhBDEntities())
				{
					armadilhas = ctx.Armadilhas.OrderBy(x => x.Descricao).ToList();
				}
			}
			catch (Exception ex)
			{

                throw new Exception(ex.Message);
            }

			return armadilhas;
        }

        internal static Armadilha ObterArmadilha(int id)
        {
			Armadilha armadilha = null;

			try
			{
                using (var ctx = new YuGiOhBDEntities())
                {
					armadilha = ctx.Armadilhas.FirstOrDefault(
							x => x.IdArmadilha == id
						);
                }
            }
			catch (Exception ex)
			{

                throw new Exception(ex.Message);
            }

			return armadilha;
        }

        internal static void ExcluirArmadilha(int id)
        {
			try
			{
				using (var ctx = new YuGiOhBDEntities())
				{
					var armadilha = ctx.Armadilhas.FirstOrDefault(
							x => x.IdArmadilha == id
						);

					ctx.Armadilhas.Remove(armadilha);
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
    }
}
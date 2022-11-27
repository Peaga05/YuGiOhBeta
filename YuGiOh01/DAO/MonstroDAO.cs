using System;
using System.Data.Entity.Validation;

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
    }
}
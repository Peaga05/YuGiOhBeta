using System;
using System.Linq;

namespace YuGiOh01.DAO
{
    public class UsuarioDAO
    {
        public static void CadastrarUsuario(Usuario user)
        {
			try
			{
				using(var ctx = new YuGiOhBDEntities())
				{
					ctx.Usuarios.Add(user);
					ctx.SaveChanges();
				}
			}
			catch (Exception ex)
			{

			}
        }

        internal static void CadastrarLog(LogUsuario log)
        {
			try
			{
				using(var ctx = new YuGiOhBDEntities())
				{
					ctx.LogUsuarios.Add(log);
					ctx.SaveChanges();
				}
			}
			catch (Exception ex)
			{
			}
        }

        internal static Usuario VetificarLogin(String login)
        {

            Usuario usuario = null;
            try
			{
				using(var ctx = new YuGiOhBDEntities())
				{

                   usuario = ctx.Usuarios.FirstOrDefault(
							x => x.Login == login
						);

				}
			}
			catch (Exception ex)
			{
			}
			return usuario;
        }
    }
}
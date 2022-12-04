using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuGiOh01.DAO;

namespace YuGiOh01
{
    public class Util
    {
        public static void AtualizarUltimoAcesso(LogUsuario log)
        {
            if (log != null)
            {
                var ultimoAcesso = DateTime.Now;
                log.DataSaida = ultimoAcesso;
                UsuarioDAO.AtualizarLogAcesso(log);
            }
        }
    }
}
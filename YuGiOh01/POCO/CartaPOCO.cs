using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuGiOh01.DAO;

namespace YuGiOh01
{
    public partial class Carta
    {

        public string TipoCartaCarta
        {
            get
            {
                var TipoCarta = TipoCartaDAO.ObterTipoCarta(IdTipoCarta);

                return TipoCarta.Descricao;
            }
        }

    }
}
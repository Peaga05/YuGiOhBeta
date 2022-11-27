using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YuGiOh01.Paginas.Formularios
{
    public partial class FrmMonstro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var mensagem = "";
                var descricao = txtMonstro.Text;
                if (descricao != "")
                {
                    TipoCarta tc = DAO.TipoCartaDAO.ObterTipoCarta("monstro");
                    Monstro monstro = new Monstro();
                    if (tc != null)
                    {
                        monstro.Descricao = descricao;
                        monstro.IdTipoCarta = tc.IdTipoCarta;
                        DAO.MonstroDAO.CadastrarMonstro(monstro);
                        mensagem = "Monstro cadastrado com sucesso!";
                        txtMonstro.Text = "";

                    }
                    else
                    {
                        mensagem = "Ainda não existe o tipo Monstro!";
                    }
                }
                else
                {
                    mensagem = "Por favor, Insira uma descrição!";
                }
                lblMensagem.InnerText = mensagem;
            }
            catch (Exception ex)
            {
                lblMensagem.InnerText = "Ocorreu um erro ao realizar a operação " + ex.Message;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YuGiOh01
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            var mensagem = "";
            var login = txtUser.Text;
            var senha = txtSenha.Text;

            if(login == "" || senha == "")
            {
                mensagem = "Preencha todos os campos!";
            }

            if(mensagem == "")
            {
                
                Usuario user = new Usuario();
                user.Login = login;
                Usuario userValido = DAO.UsuarioDAO.VetificarLogin(login);

                if(userValido != null)
                {
                    var senhaCripto = FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "SHA1");
                    user.Senha = senhaCripto;
                    if (userValido.Senha == user.Senha) {
                        FormsAuthentication.SetAuthCookie(login, true);
                        LogUsuario log = new LogUsuario();
                        log.IdUsuario = userValido.IdUsuario;
                        log.DataEntrada = DateTime.Now;

                        DAO.UsuarioDAO.CadastrarLog(log);
                        Session["idLog"] = log;
                        Session["user"] = login;
                        Response.Redirect("~/Home");
                    }
                }
            }

            lblMensagem.InnerText = mensagem;   
            
        }
    }
}
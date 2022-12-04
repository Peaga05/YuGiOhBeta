using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YuGiOh01.Paginas.Formularios
{
    public partial class FrmUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var mensagem = "";
            var usuario = txtUser.Text;
            var senha = txtSenha.Text;

            if(usuario == "")
            {
                mensagem += " Digite o nome do usuario";
            }

            if(senha == "")
            {
                mensagem += " Digite a senha do usuario";
            }

            if(mensagem == "")
            {   
                Usuario user = new Usuario();
                user.Login = usuario;
                var senhaCripto = FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "SHA1");
                user.Senha = senhaCripto;
                DAO.UsuarioDAO.CadastrarUsuario(user);
                txtSenha.Text = "";
                txtUser.Text = "";
                mensagem = "Usuário cadastrado com sucesso";
                linkLogin.Visible = true;
            }
            
            lblMensagem.InnerText = mensagem;

        }
    }
}
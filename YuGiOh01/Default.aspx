<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YuGiOh01.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
</head>
<body>

    <form runat="server">
        <div class="container w-50 mt-4">
            <div class="mt-4">
                <h1 class="text-center">Login</h1>
            </div>
            <div class="mb-3">
                <label for="txtUser" class="form-label">Usuário</label>
                <asp:TextBox runat="server" class="form-control" ID="txtUser" />
            </div>

            <div class="mb-3">
                <label for="txtSenha" class="form-label">Senha</label>
                <asp:TextBox TextMode="Password" runat="server" class="form-control" ID="txtSenha" />
            </div>
            <div class="mb-3 text-center">
                <a href="~/Paginas/Formularios/FrmUsuario.aspx" runat="server" id="linkRegistrar">Registra-se</a>
            </div>
            <asp:Button Text="Entrar" id="btnEntrar" runat="server" class="btn btn-primary w-100" OnClick="btnEntrar_Click" />

            <div class="mb-3 text-center">
                <label id="lblMensagem" runat="server"></label>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>

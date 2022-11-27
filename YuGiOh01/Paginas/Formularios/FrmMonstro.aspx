<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmMonstro.aspx.cs" Inherits="YuGiOh01.Paginas.Formularios.FrmMonstro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastrar Monstro</title>
</head>
<body>
    <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
        <div class="navbar-brand ps-2">Home</div>

        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#myNav">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse justify-content-end pe-1" id="myNav">
            <ul class="navbar-nav" runat="server">
                <li class="nav-item">
                    <a class="nav-link" href="~/"  runat="server">Home</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="" data-toggle="tab">Cadastrar</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="" data-toggle="tab">Listar</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="~/Paginas/Formularios/FrmMonstro.aspx" runat="server">Gerenciar Monstro</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="" data-toggle="tab">Sair</a>
                </li>
            </ul>
        </div>
    </nav>
    <form runat="server">
        <div class="container w-50 mt-4">
            <div class="mt-4">
                <h1 class="text-center">Cadastrar Monstro</h1>
            </div>
            <div class="mb-3">
                <label for="txtMonstro" class="form-label" runat="server">Descrição</label>
                <asp:TextBox runat="server" class="form-control" ID="txtMonstro" />
            </div>

            <div class="mb-3">
                <asp:Button Text="Cadastrar" ID="btnCadastrar" runat="server" class="btn btn-primary w-100" OnClick="btnCadastrar_Click" />
            </div>

            <div class="mb-3 text-center">
                <label id="lblMensagem" runat="server"></label>
                <a href="~/Paginas/Formularios/FrmMonstro.aspx" visible="false" id="btnNovoMonstro" runat="server">Cadastrar novo monstro</a>
            </div>

            <div>
                <h3>Monstros cadastrados</h3>
                <table class="table table-striped" style="text-align: center">
                    <thead>
                        <tr>
                            <th scope="col">Código</th>
                            <th scope="col">Descrição</th>
                            <th scope="col" colspan="3">Ações</th>
                        </tr>
                    </thead>
                    <asp:ListView runat="server" ID="lvMonstro">
                        <ItemTemplate>
                            <tr>
                                <th scope="row"><%#Eval("IdMonstro") %></th>
                                <td><%#Eval("Descricao") %></td>
                                <td>
                                    <asp:ImageButton ImageUrl="" runat="server"
                                        ID="btnVisualizar"
                                        ToolTip="Visualizar"
                                        OnCommand="btnAcoes_Command"
                                        CommandArgument='<%#Eval("IdMonstro") %>'
                                        CommandName="Visualizar" />
                                </td>
                                <td>
                                    <asp:ImageButton ImageUrl="" runat="server"
                                        ID="btnAlterar"
                                        ToolTip="Alterar"
                                        OnCommand="btnAcoes_Command"
                                        CommandArgument='<%#Eval("IdMonstro") %>'
                                        CommandName="Alterar" />
                                </td>
                                <td>
                                    <asp:ImageButton ImageUrl="" runat="server"
                                        ID="btnExcluir"
                                        ToolTip="Excluir"
                                        OnCommand="btnAcoes_Command"
                                        CommandArgument='<%#Eval("IdMonstro") %>'
                                        CommandName="Excluir" />
                                </td>

                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <b>Ainda não foi cadastrado nenhum monstro</b>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </table>

            </div>
        </div>
    </form>


    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>

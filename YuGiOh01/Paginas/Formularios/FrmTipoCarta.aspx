<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmTipoCarta.aspx.cs" Inherits="YuGiOh01.Paginas.Formularios.FrmTipoCarta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa"
        crossorigin="anonymous"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gerenciar Tipo Carta</title>
</head>
<body>
    <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
        <div class="navbar-brand ps-2">Gerenciar Tipo Carta</div>

        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#myNav">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse justify-content-end pe-1" id="myNav">
            <ul class="navbar-nav">

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Gerenciar
                    </a>
                    <ul class="dropdown-menu">
                        <li><a class="dropdown-item" runat="server" href="~/Paginas/Formularios/FrmMonstro.aspx">Gerenciar Monstro</a></li>
                        <li><a class="dropdown-item" runat="server" href="~/Paginas/Formularios/FrmTipoCarta.aspx">Gerenciar Tipo Carta</a></li>
                        <li><a class="dropdown-item" href="#">Something else here</a></li>
                    </ul>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="~/Paginas/Home.aspx" runat="server">Home</a>
                </li>


                <li class="nav-item">
                    <a class="nav-link" href="~/"  runat="server">Sair</a>
                </li>
            </ul>

        </div>
    </nav>
    <form id="form1" runat="server">
        <div class="container w-50 mt-4">
            <div class="mt-4">
                <h1 runat="server" id="h1Titulo" class="text-center">Cadastrar Tipo Carta</h1>
            </div>
            <div class="mb-3">
                <label for="txtUser" class="form-label" runat="server">Descrição</label>
                <asp:TextBox runat="server" class="form-control" ID="txtTipoCarta" />
            </div>

            <div class="mb-3">
                <asp:Button Text="Cadastrar" ID="btnCadastrar" runat="server" class="btn btn-primary w-100" OnClick="btnCadastrar_Click" />
            </div>

            <div class="mb-3 text-center">
                <label id="lblMensagem" runat="server"></label>
                <a href="~/Paginas/Formularios/FrmTipoCarta.aspx" id="linkCad" runat="server" visible="false">Cadastrar novo tipo de carta</a>
            </div>

            <div class="container mt-4">

                <h3 class="text-center mb-2">Tipos de Cartas Cadastradas</h3>

                <table class="table m-auto table-hover table-bordered text-center m-auto">
                    <thead class="thead-dark">
                        <tr>
                            <td><b>Código</b></td>
                            <td><b>Descrição</b></td>
                            <td colspan="3"><b>Ações</b></td>
                        </tr>
                    </thead>
                    <asp:ListView ID="lvlTipoCartas" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("IdTipoCarta")%></td>
                                <td><%# Eval("Descricao")%></td>

                                <td>
                                    <asp:ImageButton
                                        runat="server"
                                        ID="btnVisualizar"
                                        ImageUrl="../../Assets/Images/search.png"
                                        ToolTip="Visualizar"
                                        OnCommand="btnAcoes_Command"
                                        Style="width: 20px;"
                                        CommandArgument='<%# Eval("IdTipoCarta")%>'
                                        CommandName="Visualizar" />
                                </td>

                                <td>
                                    <asp:ImageButton
                                        runat="server"
                                        ID="btnAlterar"
                                        ImageUrl="../../Assets/Images/update.png"
                                        ToolTip="Alterar"
                                        OnCommand="btnAcoes_Command"
                                        Style="width: 20px;"
                                        CommandArgument='<%# Eval("IdTipoCarta")%>'
                                        CommandName="Alterar" />
                                </td>

                                <td>
                                    <asp:ImageButton
                                        runat="server"
                                        ID="btnExcluir"
                                        ImageUrl="~/Assets/Images/delete.png"
                                        ToolTip="Excluir"
                                        OnCommand="btnAcoes_Command"
                                        Style="width: 20px;"
                                        CommandArgument='<%# Eval("IdTipoCarta")%>'
                                        CommandName="Excluir" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            Não existe tipo de carta cadastrada!
                        </EmptyDataTemplate>
                    </asp:ListView>

                </table>
            </div>

        </div>

        <asp:HiddenField ID="hfId" runat="server" />

    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmIcone.aspx.cs" Inherits="YuGiOh01.Paginas.Formularios.FrmIcone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gerenciar Icone</title>
</head>
<body>
    <form id="formIcone" runat="server">
        <div class="container w-50 mt-4">
            <div class="mt-4">
                <h1 runat="server" id="titulo" class="text-center">Cadastrar Icone</h1>
            </div>
            <div class="mb-3">
                <label for="txtDescricaoIcone" class="form-label" runat="server">Descrição do Ícone</label>
                <asp:TextBox runat="server" class="form-control" ID="txtDescricaoIcone" />
            </div>

            <div class="mb-3">
                <asp:Button Text="Cadastrar Icone" ID="btnCadastrarIcone" runat="server" class="btn btn-primary w-100" OnClick="btnCadastrar_Click" />
            </div>

            <div class="mb-3 text-center">
                <label id="lblMensagem" runat="server"></label>
                <a href="~/Paginas/Formularios/FrmIcone.aspx" id="linkCad" runat="server" visible="false">Cadastrar novo tipo de icone</a>
            </div>

            <div class="container mt-4">

                <h3 class="text-center mb-2">Tipos de Ícones Cadastrados</h3>

                <table class="table m-auto table-hover table-bordered text-center m-auto">
                    <thead class="thead-dark">
                        <tr>
                            <td><b>Código</b></td>
                            <td><b>Descrição</b></td>
                            <td colspan="3"><b>Ações</b></td>
                        </tr>
                    </thead>
                    <asp:ListView ID="lvlIcone" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("IdIcone")%></td>
                                <td><%# Eval("Descricao")%></td>

                                <td>
                                    <asp:ImageButton
                                        runat="server"
                                        ID="btnVisualizar"
                                        ImageUrl="../../Assets/Images/search.png"
                                        ToolTip="Visualizar"
                                        OnCommand="btnAcoes_Command"
                                        Style="width: 20px;"
                                        CommandArgument='<%# Eval("IdIcone")%>'
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
                                        CommandArgument='<%# Eval("IdIcone")%>'
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
                                        CommandArgument='<%# Eval("IdIcone")%>'
                                        CommandName="Excluir" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            Não existe ícone cadastrado!
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

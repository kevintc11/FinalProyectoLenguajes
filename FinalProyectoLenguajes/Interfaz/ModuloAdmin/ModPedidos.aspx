<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModPedidos.aspx.cs" Inherits="Interfaz.ModuloAdmin.ModPedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title>Lista De Pedidos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
<br />
                    Lista De Pedidos Actuales<br />
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
            <br />
                    Pedido ID<br />
                    <asp:TextBox ID="tbPedidoID" runat="server"></asp:TextBox>
            <br />
                    <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
            <br />
                    Estado Pedido<asp:RadioButtonList ID="rblStatus" runat="server">
                        <asp:ListItem Selected="True" Value="1">A Tiempo</asp:ListItem>
                        <asp:ListItem Value="2">Sobre Tiempo</asp:ListItem>
                        <asp:ListItem Value="3">Demorado</asp:ListItem>
                        <asp:ListItem Value="4">Anulado</asp:ListItem>
                        <asp:ListItem Value="5">Entregado</asp:ListItem>
                    </asp:RadioButtonList>
            <br />
                    <asp:Button ID="btModify" runat="server" CssClass="btn btn-primary" Height="38px" OnClick="btModify_Click" Text="Actualizar" Width="120px" />
            <br />
            <br />
                    <asp:Button ID="btBack" runat="server" CssClass="btn btn-warning" Height="35px" OnClick="btBack_Click" Text="Volver" Width="70px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>

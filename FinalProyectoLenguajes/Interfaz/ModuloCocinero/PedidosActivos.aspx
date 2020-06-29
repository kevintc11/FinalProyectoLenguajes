<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PedidosActivos.aspx.cs" Inherits="Interfaz.ModuloCocinero.PedidosActivos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Pedidos Activos</div>
        <asp:GridView ID="dgPedidos" runat="server" OnSelectedIndexChanged="dgPedidos_SelectedIndexChanged">
        </asp:GridView>
        <br />
        Para cambiar el estado de la orden, digite el pedidoID<br />
        <br />
        <asp:TextBox ID="tbPedidoID" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnCambiarEstado" runat="server" OnClick="btnCambiarEstado_Click" Text="Cambiar estado de orden" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDeshacer" runat="server" OnClick="btnDeshacer_Click" Text="Deshacer" />
    </form>
</body>
</html>

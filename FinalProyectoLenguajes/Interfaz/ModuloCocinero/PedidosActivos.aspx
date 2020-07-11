<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PedidosActivos.aspx.cs" Inherits="Interfaz.ModuloCocinero.PedidosActivos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    Pedidos Activos<asp:GridView ID="dgPedidos" runat="server" OnSelectedIndexChanged="dgPedidos_SelectedIndexChanged">
                    </asp:GridView>
                    <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick1">
                    </asp:Timer>
                    <asp:Label ID="lbMensaje" runat="server" Text="Espere unos segundos para que la página se actualice"></asp:Label>
                    <br />
                    <br />
                    Para cambiar el estado de la orden, digite el pedidoID<br />
                    <asp:TextBox ID="tbPedidoID" runat="server" Width="140px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnCambiarEstado" runat="server" CssClass="btn btn-primary" Height="35px" OnClick="btnCambiarEstado_Click" Text="Cambiar estado de orden" Width="210px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDeshacer" runat="server" CssClass="btn btn-primary" Height="35px" OnClick="btnDeshacer_Click" Text="Deshacer" />
                    <br />
                    <asp:Button ID="btSalir" runat="server" CssClass="btn btn-warning" Height="35px" OnClick="btSalir_Click" Text="Salir" Width="70px" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lbError" runat="server" ForeColor="Red"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>

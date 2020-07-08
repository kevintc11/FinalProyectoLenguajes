<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="Interfaz.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title>Menu Administrador</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div>
            Menú Administrador<br />
            Bienvenido
            <br />
            <br />
            <asp:Button ID="btDishes" runat="server" Height="35px" Text="Administrar Platos" Width="170px" CssClass="btn btn-primary" OnClick="btDishes_Click" />
&nbsp;&nbsp;
            <asp:Button ID="btUsers" runat="server" Height="35px" Text="Administrar Usuarios" Width="170px" CssClass="btn btn-primary" OnClick="btUsers_Click" />
            <br />
            <br />
            <asp:Button ID="btClient" runat="server" Height="35px" Text="Bloquear Clientes" Width="170px" CssClass="btn btn-primary" OnClick="btClient_Click" />
&nbsp;&nbsp;
            <asp:Button ID="btPed" runat="server" Height="35px" Text="Administrar Pedidos" Width="170px" CssClass="btn btn-primary" OnClick="btPed_Click" />
            <br />
            <br />
            <asp:Button ID="btModPedidos" runat="server" Height="35px" Text="Gestionar Pedidos" Width="170px" CssClass="btn btn-primary" OnClick="btModPedidos_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="btModEstados" runat="server" Height="35px" Text="Modificar Estados" Width="170px" CssClass="btn btn-primary" OnClick="btModEstados_Click" />
            <br />
            &nbsp;<br />
            <asp:Button ID="btBack" runat="server" Text="Salir" Width="70px" CssClass="btn btn-warning" OnClick="btBack_Click" Height="35px" />
        </div>
    </form>
</body>
</html>

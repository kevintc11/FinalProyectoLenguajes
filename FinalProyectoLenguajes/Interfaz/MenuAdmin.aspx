<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="Interfaz.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div>
            Menú Administrador<br />
            Bienvenido
            <asp:Label ID="lbName" runat="server" Text="*Nombre*"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="btDishes" runat="server" Height="35px" Text="Administrar Platos" Width="140px" />
&nbsp;&nbsp;
            <asp:Button ID="btUsers" runat="server" Height="35px" Text="Administrar Usuarios" Width="140px" />
            <br />
            <br />
            <asp:Button ID="btClient" runat="server" Height="35px" Text="Bloquear Clientes" Width="140px" />
&nbsp;&nbsp;
            <asp:Button ID="btPed" runat="server" Height="35px" Text="Administrar Pedidos" Width="140px" />
            <br />
            <br />
            <asp:Button ID="btBack" runat="server" Text="Salir" />
        </div>
    </form>
</body>
</html>

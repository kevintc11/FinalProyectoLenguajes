<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio Sesion.aspx.cs" Inherits="Interfaz.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            Bievenidos Al Restaurante Pochotón<br />
            <br />
            Usuario<br />
            <asp:TextBox ID="TextBox2" runat="server" Width="180px"></asp:TextBox>
            <br />
            Contraseña<br />
            <asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btSign" runat="server" Text="Iniciar Sesion" />
&nbsp; O&nbsp;
            <asp:Button ID="btRegist" runat="server" Text="Registrarse" />
        </div>
    </form>
</body>
</html>

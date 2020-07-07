﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="Interfaz.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title>Inicio De Sesión</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center" id="txtPassword">
            Bievenidos Al Restaurante Pochotón<br />
            <br />
            Usuario<br />
            <asp:TextBox ID="txNick" runat="server" Width="180px"></asp:TextBox>
            <br />
            Contraseña<br />
            <asp:TextBox ID="txPass" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btSign" runat="server" Text="Iniciar Sesion" CssClass="btn btn-primary" OnClick="btSign_Click" Height="35px" Width="130px" />
&nbsp; O&nbsp;
            <asp:Button ID="btRegist" runat="server" Text="Registrarse" CssClass="btn btn-primary" Height="35px" OnClick="btRegist_Click" Width="130px" />
        </div>
    </form>
</body>
</html>
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioAgregar.aspx.cs" Inherits="Interfaz.AgregarCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title>Agregar Cliente</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="text-left">
            Agregar Un Nuevo Cliente<br />
            <br />
            Nombre Usuario<br />
            <asp:TextBox ID="tbNick" runat="server"></asp:TextBox>
            <br />
            <br />
            Nombre Completo<br />
            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            <br />
            <br />
            Correo Electrónico<br />
            <asp:TextBox ID="tbMail" runat="server"></asp:TextBox>
            <br />
            <br />
            Dirección<br />
                <asp:TextBox ID="tbAddress" runat="server" AutoCompleteType="HomeStreetAddress" Height="124px" TextMode="MultiLine" Width="219px"></asp:TextBox>
                <br />
            <br />
            Tipo De Usuario<asp:RadioButtonList ID="rblUserT" runat="server">
                <asp:ListItem Value="1">Administrador</asp:ListItem>
                <asp:ListItem Value="2" Selected="True">Cocinero</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            Contraseña<br />
            <asp:TextBox ID="tbPass" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btAdd" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btAdd_Click" Height="38px" Width="90px" />
            <br />
            <br />
            <asp:Button ID="btBack" runat="server" Text="Salir" Width="70px" CssClass="btn btn-warning" OnClick="btBack_Click" Height="35px" />
        </div>
    </form>
</body>
</html>

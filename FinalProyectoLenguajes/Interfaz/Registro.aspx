<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Interfaz.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title>Registro</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="text-left">
            Nuevo Usuario
                <br />
                <br />
                Nombre De Usuario<br />
                <asp:TextBox ID="txUser" runat="server"></asp:TextBox>
                <br />
                <br />
                Nombre Completo<br />
                <asp:TextBox ID="txName" runat="server"></asp:TextBox>
                <br />
                <br />
                Correo Electrónico<br />
                <asp:TextBox ID="txMail" runat="server"></asp:TextBox>
                <br />
                <br />
                <br />
                Tipo De Usuario</div>
            <asp:RadioButtonList ID="rblUserT" runat="server">
                <asp:ListItem Value="1">Administrador</asp:ListItem>
                <asp:ListItem Value="2">Cocinero</asp:ListItem>
                <asp:ListItem Value="3">Cliente</asp:ListItem>
            </asp:RadioButtonList>
            <div class="text-left">
                <br />
                Contraseña<br />
                <asp:TextBox ID="txPassd1" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btRegist" runat="server" OnClick="btRegist_Click" Text="Registrarse" />
                <br />
                <asp:Button ID="btBack" runat="server" CssClass="btn-warning" OnClick="btBack_Click" Text="Volver" />
&nbsp;
            </div>
        </div>
    </form>
</body>
</html>

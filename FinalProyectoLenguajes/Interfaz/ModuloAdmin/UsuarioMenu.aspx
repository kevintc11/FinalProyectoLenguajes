<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioMenu.aspx.cs" Inherits="Interfaz.UsuarioMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title>Menu De Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            Administración De Usuarios<br />
            <br />
            <asp:Button ID="btAdd" runat="server" Height="35px" Text="Agregar Usuario" Width="170px" CssClass="btn btn-primary" OnClick="btPed_Click" />
            <br />
            <asp:Button ID="btSearch" runat="server" Height="35px" Text="Buscar Usuario" Width="170px" CssClass="btn btn-primary" OnClick="btSearch_Click" />
            <br />
            <asp:Button ID="btMod" runat="server" Height="35px" Text="Modificar Usuario" Width="170px" CssClass="btn btn-primary" OnClick="btMod_Click" />
            <br />
            <asp:Button ID="btDel" runat="server" Height="35px" Text="Eliminar Usuario" Width="170px" CssClass="btn btn-primary" OnClick="btDel_Click" />
            <br />
            <br />
            <asp:Button ID="btBack" runat="server" Text="Volver" Width="70px" CssClass="btn btn-warning" OnClick="btBack_Click" Height="35px" />
        </div>
    </form>
</body>
</html>

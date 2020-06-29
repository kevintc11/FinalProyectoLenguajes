<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlatoMod.aspx.cs" Inherits="Interfaz.ModificarPlato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title>Modificar Plato</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="text-left">
            Modificar Plato<br />
            <br />
            PlatoID<br />
            <asp:TextBox ID="tbPlatoID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnComprobar" runat="server" OnClick="btnComprobar_Click1" Text="Comprobar" />
            <br />
            Nombre Del Plato<br />
            <asp:TextBox ID="tbDishName" runat="server"></asp:TextBox>
            <br />
            <br />
            Descripción Del Plato<br />
            <asp:TextBox ID="tbDesc" runat="server"></asp:TextBox>
            <br />
            <br />
            Precio Del Plato<br />
            <asp:TextBox ID="tbPrice" runat="server"></asp:TextBox>
            <br />
            <br />
            Foto Del Plato<br />
            *No Disponible*<br />
            <br />
            Estado<br />
            <asp:RadioButtonList ID="rdEstado" runat="server">
                <asp:ListItem Selected="True" Value="1">Habilitado</asp:ListItem>
                <asp:ListItem Value="0">Desabilitado</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="btMod" runat="server" CssClass="btn btn-primary" Height="38px" Text="Modificar" Width="90px" OnClick="btMod_Click" />
            <br />
            <br />
            <asp:Button ID="btBack" runat="server"  Text="Volver" Width="70px" CssClass="btn btn-warning" OnClick="btBack_Click" Height="35px" />
        </div>
    </form>
</body>
</html>

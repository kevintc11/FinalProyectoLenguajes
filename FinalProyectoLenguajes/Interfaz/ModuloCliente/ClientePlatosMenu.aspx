<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientePlatosMenu.aspx.cs" Inherits="Interfaz.ClienteMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title>Menú</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Menú De Platos<br />
            <asp:GridView ID="gvMenu" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <br />
            Nombre Del Platillo
            <br />
            <asp:TextBox ID="tbFilter" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btFiltrar" runat="server" CssClass="btn-primary" Text="Filtrar" OnClick="btFiltrar_Click" />
            <br />
            -------------------------------------<br />
            Id Del Plato A Mostrar<br />
            <asp:TextBox ID="tbId" runat="server" Width="180px"></asp:TextBox>
            <br />
            <asp:Button ID="btOpen" runat="server" CssClass="btn-primary" Height="35px" Text="Mostrar" OnClick="tbOpen_Click" />
            <br />
            <br />
            Nombre Del Plato<br />
            <asp:Label ID="lbName" runat="server"></asp:Label>
            <br />
            <br />
            Descripción<br />
            <asp:Label ID="lbDesc" runat="server"></asp:Label>
            <br />
            <br />
            Precio<br />
            <asp:Label ID="lbPrice" runat="server"></asp:Label>
            <br />
            <br />
            Foto<br />
            <asp:Image ID="Image1" runat="server" Height="80px" Width="80px" />
            <br />
            <br />
            <br />
            <asp:Button ID="btBack" runat="server" CssClass="btn-warning" Height="35px" Text="Volver" />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioBuscar.aspx.cs" Inherits="Interfaz.ClienteBuscar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title>Buscar Usuario</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="text-left">
            Busqueda De Cliente<br />
            <asp:GridView ID="dgClientes" runat="server" BorderStyle="Double" CellPadding="4" EmptyDataText="Vacio" ForeColor="#333333" GridLines="Vertical" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="454px">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <br />
            Nickname Del Usuario<br />
            <asp:TextBox ID="tbNick" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btSearch" runat="server" CssClass="btn-primary" Text="Buscar" Height="30px" OnClick="btSearch_Click" Width="90px" />
            <br />
            <br />
            <asp:Button ID="btBack" runat="server" CssClass="btn-warning" Text="Volver" OnClick="btBack_Click" Height="35px" Width="70px" />
        </div>
    </form>
</body>
</html>

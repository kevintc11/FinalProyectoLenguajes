<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlatoBuscar.aspx.cs" Inherits="Interfaz.BuscarPlatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title>Buscar Plato</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="text-left">
            Buscar Un Plato<br />
            <asp:GridView ID="dgPlato" runat="server" BorderStyle="Double" CellPadding="4" EmptyDataText="Vacio" ForeColor="#333333" GridLines="Vertical" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="454px">
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
            ID Del Plato<br />
            <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btSearch" runat="server" CssClass="btn btn-primary" Height="38px" Text="Buscar" Width="90px" OnClick="btSearch_Click" />
            <br />
            <br />
            <asp:Button ID="btBack" runat="server" Text="Volver" Width="70px" CssClass="btn btn-warning" OnClick="btBack_Click" Height="35px" />
        </div>
    </form>
</body>
</html>

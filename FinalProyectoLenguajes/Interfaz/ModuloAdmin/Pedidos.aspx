<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Interfaz.ModuloAdmin.Pedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

  <meta name="viewport" content="width=device-width, initial-scale=1"> 

  <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>

  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <title>Lista De Pedidos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Lista De Pedidos Actuales<br />
            <br />
            <br />
            <asp:GridView ID="dgPedidos" runat="server" BorderStyle="Double" CellPadding="4" EmptyDataText="Vacio" ForeColor="#333333" GridLines="Vertical" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="454px">
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
            Filtro<br />
            <asp:CheckBoxList ID="cblFilter" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                <asp:ListItem Value="1">ClienteID</asp:ListItem>
                <asp:ListItem Value="2">Rango De Fechas</asp:ListItem>
                <asp:ListItem Value="3">Estado</asp:ListItem>
            </asp:CheckBoxList>
            <br />
            ClienteID A Filtrar<br />
            <asp:TextBox ID="txName" runat="server" Width="188px"></asp:TextBox>
            <br />
            <br />
            Fecha Inicio
            <br />
            <asp:TextBox ID="txDate1" runat="server" TextMode="DateTime"></asp:TextBox>
&nbsp;Formato(y-m-d)<br />
            Fecha Fin<br />
            <asp:TextBox ID="txDate2" runat="server" TextMode="DateTime"></asp:TextBox>
&nbsp;Formato(y-m-d)<br />
            <br />
            Filtro Estado<br />
            <asp:RadioButtonList ID="rblStatus" runat="server">
                <asp:ListItem Selected="True" Value="1">A Tiempo</asp:ListItem>
                <asp:ListItem Value="2">Sobre Tiempo</asp:ListItem>
                <asp:ListItem Value="3">Demorado</asp:ListItem>
                <asp:ListItem Value="4">Anulado</asp:ListItem>
                <asp:ListItem Value="5">Entregado</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Button ID="btSearch" runat="server" CssClass="btn-primary"  Text="Refrescar" OnClick="btSearch_Click" />
            <br />
            <br />
            <asp:Button ID="btBack" runat="server" CssClass="btn-warning" Text="Atras" Height="35px" Width="70px" OnClick="btBack_Click" />
        </div>
    </form>
</body>
</html>

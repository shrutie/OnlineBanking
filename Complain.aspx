<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Complain.aspx.cs" Inherits="Complain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    
        <form id="form1" runat="server">

    
        <br /><br />
    
    
    <p style="background-color: #800000; color: #FFFFFF">
              <marquee onMouseOver="this.stop();" onMouseOut="this.start();" scrollamount="10">Complain</marquee>
            </p>
    <br /><br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

<table align="center">
    <tr class="text-primary" style="font-size:x-large">
        <td>Account ID:</td>
        <td>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td class="text-primary" style="font-size:x-large">Write Complain:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Height="80px" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
    </tr>
    <tr colspan="2">
        <td>
            <asp:Button ID="Button1" runat="server" Text="Raise Complain" class="btn btn-primary" OnClick="Button1_Click" Width="225px"/></td>
    </tr>
</table>
    <br />
            <asp:GridView ID="GridView1" runat="server" align="center" CellPadding="4" ForeColor="#333333" GridLines="None" Height="156px" Width="356px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
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
            <br<hr />

    
        </form>
</asp:Content>


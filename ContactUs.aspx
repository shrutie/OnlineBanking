<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">




    <form id="form1" runat="server">
        <br />
           <p style="background-color: #800000; color: #FFFFFF">
              <marquee onMouseOver="this.stop();" onMouseOut="this.start();" scrollamount="10">Contact Us</marquee>
            </p>
        <br />
        <hr />
        <br /><br />
        <div>
        <asp:DataList ID="DataList1" runat="server" BackColor="White" RepeatColumns="4" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Horizontal" >
            <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="200px" ImageUrl='<%# Eval("img") %>' Width="250px" class="img-circle"/>
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankConnectionString %>" SelectCommand="SELECT * FROM [contact]"></asp:SqlDataSource>
    
    <br />
        <br />
        <br />
        <table align="center">
            <tr>
                <td><p class="bg-info">I am happy to say that i am the owner of this bank.This bank will provide you and your account a high security.</p></td>
                <td><p class="bg-info">I am happy to say that i am the owner of this bank.This bank will provide you and your account a high security.</p></td>
                <td><p class="bg-info">I am happy to say that i am the owner of this bank.This bank will provide you and your account a high security.</p></td>
                <td><p class="bg-info">I am happy to say that i am the owner of this bank.This bank will provide you and your account a high security.</p></td>
            </tr>
        </table>
            </div>
    </form>




</asp:Content>


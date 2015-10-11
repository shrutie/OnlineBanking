<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserStatement.aspx.cs" Inherits="UserStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">




    <form id="form1" runat="server">




    <br /><br /><br /><br /><p class="text-primary" style="font-size:x-large">Transaction Details of your Account</p><br /><br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="280px" Width="854px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Transaction_ID" HeaderText="Transaction_ID" SortExpression="Transaction_ID" />
                <asp:BoundField DataField="Transfer_to" HeaderText="Transfer_to" SortExpression="Transfer_to" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                <asp:BoundField DataField="Available_Balance" HeaderText="Available_Balance" SortExpression="Available_Balance" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineBankConnectionString %>" SelectCommand="SELECT [Transaction_ID], [Transfer_to], [Amount], [Date], [Available_Balance], [Status] FROM [transactions] WHERE ([Transfer_from] = @Transfer_from)">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="Transfer_from" SessionField="user_id" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br /><br /><br /><p style="align-content:center">
            &nbsp;</p>
        <p style="align-content:center">
            &nbsp;</p>
        <p style="align-content:center">
            <input id="Button1" type="button" class="btn btn-primary" value="Print" onclick="print();"/>
        </p>
    </form>
</asp:Content>


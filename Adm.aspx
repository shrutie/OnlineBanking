<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Adm.aspx.cs" Inherits="Adm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <form id="form1" runat="server">

        <asp:GridView ID="GridView1" runat="server" align="center" CellPadding="4" DataKeyNames="username" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowDeleting="delete_reg" ForeColor="#333333" GridLines="None" Height="195px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="489px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
<asp:TemplateField HeaderText="UserName">
<EditItemTemplate>
<asp:Label ID="usrnm" runat="server" Text='<%#Eval("username") %>'/>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="User_name" runat="server" Text='<%#Eval("username") %>'/>
</ItemTemplate>
<FooterTemplate>
<asp:TextBox ID="TextBox1" runat="server"/>
</FooterTemplate> 
</asp:TemplateField>

 <asp:TemplateField HeaderText="DOB">
 <EditItemTemplate>
 <asp:TextBox ID="textdob" runat="server" Text='<%#Eval("dateofbirth") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lbldob" runat="server" Text='<%#Eval("dateofbirth") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtdob" runat="server"/>
 </FooterTemplate>
 </asp:TemplateField>

                <asp:TemplateField HeaderText="Email ID">
 <EditItemTemplate>
 <asp:TextBox ID="textemail" runat="server" Text='<%#Eval("email") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lblemail" runat="server" Text='<%#Eval("email") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtemail" runat="server"/>
  <asp:RequiredFieldValidator ID="rfemail" runat="server" ControlToValidate="txtemail" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>

 <asp:TemplateField HeaderText="Mobile Number">
 <EditItemTemplate>
 <asp:TextBox ID="textmobile" runat="server" Text='<%#Eval("mobile") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("mobile") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtmobile" runat="server"/>
  <asp:RequiredFieldValidator ID="rfmobile" runat="server" ControlToValidate="txtmobile" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>

<asp:TemplateField HeaderText="Account Type">
 <EditItemTemplate>
 <asp:TextBox ID="textacctype" runat="server" Text='<%#Eval("accounttype") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lblacctype" runat="server" Text='<%#Eval("accounttype") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtacctype" runat="server"/>
  <asp:RequiredFieldValidator ID="rfacctype" runat="server" ControlToValidate="txtacctype" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>

 <asp:TemplateField HeaderText="Profile Pics">
 <EditItemTemplate>
     <asp:Image ID="img1" runat="server"  ImageUrl='<%#Eval("image") %>' Height="60px" Width="70px"/>
 </EditItemTemplate>
 <ItemTemplate>
     <asp:Image ID="img" runat="server"  ImageUrl='<%#Eval("image") %>' Height="60px" Width="70px"/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtimage" runat="server"/>
  <asp:RequiredFieldValidator ID="rfimage" runat="server" ControlToValidate="txtimage" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>

<asp:TemplateField HeaderText="Account Id">
 <EditItemTemplate>
 <asp:TextBox ID="textaccid" runat="server" Text='<%#Eval("accountid") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lblaccid" runat="server" Text='<%#Eval("accountid") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtaccid" runat="server"/>
  <asp:RequiredFieldValidator ID="rfacctid" runat="server" ControlToValidate="txtaccid" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>



                <asp:CommandField ShowDeleteButton="True" DeleteImageUrl="~/Img/delete.jpg"/>
                <asp:CommandField ButtonType="Image" UpdateImageUrl="~/Img/update.jpg" CancelImageUrl="~/Img/Cancel.jpg" DeleteImageUrl="~/Img/delete.jpg" EditImageUrl="~/Img/Edit.jpg" ShowEditButton="True" />
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
        <br />
        <br />
    </form>
</asp:Content>


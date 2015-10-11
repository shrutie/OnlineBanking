<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Admin Home</title>
    <script type="text/javascript">
        function ConfirmationBox(username) {

            var result = confirm('Are you sure you want to delete ' + username + ' Details?');
            if (result) {

                return true;
            }
            else {
                return false;
            }
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ADMIN&nbsp;&nbsp; SECTION<br />
        <br />
        <marquee>
        Registration Details:</marquee><br />
        <br />
<div>
<asp:GridView ID="gvDetails" DataKeyNames="username" runat="server" 
        AutoGenerateColumns="false" CssClass="Gridview" HeaderStyle-BackColor="#61A6F8" 
ShowFooter="true" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" 
        onrowcancelingedit="gvDetails_RowCancelingEdit" 
        onrowdeleting="gvDetails_RowDeleting" onrowediting="gvDetails_RowEditing" 
        onrowupdating="gvDetails_RowUpdating" 
        onrowcommand="gvDetails_RowCommand" OnSelectedIndexChanged="gvDetails_SelectedIndexChanged">
     
<Columns>
<asp:TemplateField>
<EditItemTemplate>
<asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Img/update.jpg" ToolTip="Update" Height="20px" Width="20px" />
<asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Img/Cancel.jpg" ToolTip="Cancel" Height="20px" Width="20px" />

</EditItemTemplate>
<ItemTemplate>
<asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Img/Edit.jpg" ToolTip="Edit" Height="20px" Width="20px" />
<asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server" ImageUrl="~/Img/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
</ItemTemplate>
<FooterTemplate>
<asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/Img/AddNewitem.jpg" CommandName="AddNew" Width="30px" Height="30px" ToolTip="Add new User" ValidationGroup="validaiton" />

</FooterTemplate>
 </asp:TemplateField>
<asp:TemplateField HeaderText="UserName">
<EditItemTemplate>
<asp:Label ID="lbleditusr" runat="server" Text='<%#Eval("username") %>'/>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="lblitemUsr" runat="server" Text='<%#Eval("username") %>'/>
</ItemTemplate>
<FooterTemplate>
<asp:TextBox ID="txtusername" runat="server"/>
<asp:RequiredFieldValidator ID="rfusername" runat="server" ControlToValidate="txtusername" Text="*" ValidationGroup="validaiton"/>
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
 <asp:RequiredFieldValidator ID="rfdob" runat="server" ControlToValidate="txtdob" Text="*" ValidationGroup="validaiton"/>
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
 <asp:TextBox ID="txtimage" runat="server" placeHolder=""/>
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

 </Columns>
</asp:GridView>

    </div>
<div>
<asp:Label ID="lblresult" runat="server"></asp:Label>
</div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <marquee>Transaction Deatils:</marquee></p>
        <p>
            <asp:GridView ID="GridViewTtansaction" runat="server" DataKeyNames="Transaction_ID"
                AutoGenerateColumns="false" CssClass="Gridview" HeaderStyle-BackColor="#61A6F8" 
ShowFooter="true" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" 
        OnRowCancelingEdit="GridViewTtansaction_RowCancelingEdit" 
        OnRowDeleting="GridViewTtansaction_RowDeleting" OnRowEditing="GridViewTtansaction_RowEditing"
        OnRowUpdating="GridViewTtansaction_RowUpdating" 
        OnRowCommand="GridViewTtansaction_RowCommand">
<Columns>
<asp:TemplateField>
<EditItemTemplate>
<asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Img/update.jpg" ToolTip="Update" Height="20px" Width="20px" />
<asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Img/Cancel.jpg" ToolTip="Cancel" Height="20px" Width="20px" />

</EditItemTemplate>
<ItemTemplate>
<asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Img/Edit.jpg" ToolTip="Edit" Height="20px" Width="20px" />
<asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server" ImageUrl="~/Img/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
</ItemTemplate>
<FooterTemplate>
<asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/Img/AddNewitem.jpg" CommandName="AddNew1" Width="30px" Height="30px" ToolTip="Add new User" ValidationGroup="validaiton" />
</FooterTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Transaction ID">
<EditItemTemplate>
<asp:Label ID="lbltid" runat="server" Text='<%#Eval("Transaction_ID") %>'/>
</EditItemTemplate>
<ItemTemplate>
<asp:Label ID="lbltid" runat="server" Text='<%#Eval("Transaction_ID") %>'/>
</ItemTemplate>
<FooterTemplate>
<asp:TextBox ID="txttid" runat="server"/>
<asp:RequiredFieldValidator ID="rftid" runat="server" ControlToValidate="txttid" Text="*" ValidationGroup="validaiton"/>
</FooterTemplate> 
</asp:TemplateField>

<asp:TemplateField HeaderText="Transfer To">
 <EditItemTemplate>
 <asp:TextBox ID="texttto" runat="server" Text='<%#Eval("Transfer_to") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lbltto" runat="server" Text='<%#Eval("Transfer_to") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txttto" runat="server"/>
 <asp:RequiredFieldValidator ID="rftto" runat="server" ControlToValidate="txttto" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>

<asp:TemplateField HeaderText="Transfer From">
 <EditItemTemplate>
 <asp:TextBox ID="texttfrom" runat="server" Text='<%#Eval("Transfer_from") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lbltfrom" runat="server" Text='<%#Eval("Transfer_from") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txttfrom" runat="server"/>
 <asp:RequiredFieldValidator ID="rftfrom" runat="server" ControlToValidate="txttfrom" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>

<asp:TemplateField HeaderText="Amount">
 <EditItemTemplate>
 <asp:TextBox ID="textamt" runat="server" Text='<%#Eval("Amount") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lblamt" runat="server" Text='<%#Eval("Amount") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtamt" runat="server"/>
 <asp:RequiredFieldValidator ID="rfamt" runat="server" ControlToValidate="txtamt" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>

<asp:TemplateField HeaderText="Date">
 <EditItemTemplate>
 <asp:TextBox ID="textdate" runat="server" Text='<%#Eval("Date") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtdate" runat="server"/>
 <asp:RequiredFieldValidator ID="rfdate" runat="server" ControlToValidate="txtdate" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>

 <asp:TemplateField HeaderText="Available Balance">
 <EditItemTemplate>
 <asp:TextBox ID="textabal" runat="server" Text='<%#Eval("Available_Balance") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lblabal" runat="server" Text='<%#Eval("Available_Balance") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtabal" runat="server"/>
 <asp:RequiredFieldValidator ID="rfabal" runat="server" ControlToValidate="txtabal" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>

 <asp:TemplateField HeaderText="Status">
 <EditItemTemplate>
 <asp:TextBox ID="textstatus" runat="server" Text='<%#Eval("Status") %>'/>
 </EditItemTemplate>
 <ItemTemplate>
 <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("Status") %>'/>
 </ItemTemplate>
 <FooterTemplate>
 <asp:TextBox ID="txtstatus" runat="server"/>
 <asp:RequiredFieldValidator ID="rfstatus" runat="server" ControlToValidate="txtstatus" Text="*" ValidationGroup="validaiton"/>
 </FooterTemplate>
 </asp:TemplateField>


</Columns>
            </asp:GridView>
        </p>
        <p>
            <asp:Label ID="lbltrans" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>

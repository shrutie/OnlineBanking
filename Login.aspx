<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
    <form id="form1" runat="server">
    <p>
        &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        
        <br />

    <table align="center" >
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
<br />
                    <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/LoginImage.xml" />
<br />
                    <asp:Timer ID="Timer1" runat="server" Interval="5000">
                    </asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
            <td style="width:120px"></td>
            <td style="align-self:auto;">

                <span class="label label-primary" style="font-size:larger;">User Name:</span>&nbsp;<asp:TextBox ID="TextBox1" runat="server" class="form-control" ToolTip="Username" PlaceHolder="Username" Width="181px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*Please Fill" ForeColor="Red"></asp:RequiredFieldValidator>

                <br />

                <br />
                <span class="label label-primary" style="font-size:larger;">Password:</span>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" PlaceHolder="Password" class="form-control" TextMode="Password" ToolTip="Password" Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*Please Fill" ForeColor="Red"></asp:RequiredFieldValidator>
               
                <br />
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" class="btn btn-primary" Text="Log In" ToolTip="Log in" />
                <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <b style="font-size:20px;color:black;"><i><asp:CheckBox ID="CheckBox1" runat="server" Text="Keep me logged in" OnCheckedChanged="CheckBox1_CheckedChanged" /></i>
                    <br />New User</b>
               <b style="font-size:20px;color:black;"><i> <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">SignUp</asp:LinkButton>
                <br />
                <br />
&nbsp; </i>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" ToolTip="Forget Password">Forget Password</asp:LinkButton>
                </b>

                <br />
                <br />

            </td>
        </tr>
    </table> 
    
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
    
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OTP.aspx.cs" Inherits="OTP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <form id="form1" runat="server">
    <br />
    <br />
    <br /><table align="center">
        <tr>
        <td><p class="text-primary" style="font-size:x-large">&nbsp;Enter OTP : </p>
            </td>
        <td><p class="text-primary" style="font-size:x-large"><asp:TextBox ID="TextBox1" runat="server" placeHolder="Enter OTP" Width="178px" class="form-control"></asp:TextBox></p></td>
        </tr>
        
    <tr colspan="2" style="align-content:center">
    <th><asp:Button ID="Button1" runat="server" Text="SUBMIT" OnClick="Button1_Click" Width="150px" class="btn btn-success"/></th>
        </tr>
        </table>
        </form>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function validate(e)
        {
            var keynum;
            if (e.which) {
                keynum = e.which;
            }

            keychar = String.fromCharCode(keynum);

            numbercheck = /\d/;
            return numbercheck.test(keychar);

        }

        function word(e) {
            var keynum;
            if (e.which)
            {
                keynum = e.which;
            }

            keychar = String.fromCharCode(keynum);

            numbercheck = /\d/;
            return !numbercheck.test(keychar);
            

        }

        function checkmobile()
        {
            var x = document.getElementById('TextBox4').value;
            var y = x.toString().length;

            if (y < 10)
            {
                document.getElementById('TextBox4').style.color = "red";
            }

            else if (x.charAt(0) != 9)
            {
                alert("Mobile Number should start with 9 only");
                document.getElementById('TextBox4').style.color = "red";
                document.myform.mnumber.focus();
            }

            else
            {
                document.getElementById('TextBox4').style.color = "white";
            }
        }
    </script>
    <form id="form1" runat="server" name="myform">
    
    <p>
        <br />
    </p>
        <p style="background-color:#800000; color: #FFFFFF; height:20px; width: 1235px;">
<marquee onMouseOver="this.stop();" onMouseOut="this.start();" scrollamount="12" style="width: 1372px; margin-left: 22px; margin-bottom: 0px;"><b style="font-size:18px"> Welcome to Registration Page</b></marquee>
    </p>
   
    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <table style="align-self:auto">
      <tr>
          <td style="width: 778px">
<asp:Image ImageUrl="~/images/register1.jpg" runat="server" ImageAlign="Top" Height="210px" Width="620px" align="center" />
          </td>
&nbsp;<td>
        <table align="center" style="background-color:aliceblue;background-image:radial-gradient();border:dotted;" class="form-group">
           
         <tr>
             <td style="width: 198px"><b style="font-size:20px;color:black;">User Name:</b></td>
             <td>
                 <asp:TextBox ID="TextBox1" runat="server" ToolTip="First name" onKeyPress="return word(event);" class="form-control" PlaceHolder="Example:Ritesh" Width="170px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="First Name is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
             </td>
         </tr>
          <tr>
             <td style="height: 20px; width: 198px;"><b style="font-size:20px;color:black;">DOB:</b></td>
             <td>
                 <asp:TextBox ID="TextBox2" runat="server" ToolTip="DOB" class="form-control" placeHolder="Example:01/12/1994" Width="170px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="DOB is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
              </td>
         </tr>
         <tr>
             <td style="width: 198px"><b style="font-size:20px;color:black;">Email Id:</b></td>
             <td>
                 <asp:TextBox ID="TextBox3" runat="server" TextMode="Email" class="form-control" PlaceHolder="Example:xyz@gmail.com" ToolTip="Email ID" Width="170px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email Id Required" ForeColor="#CC0000" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="Email Id not valid" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
             </td>
         </tr>
         <tr>
             <td style="width: 198px"><b style="font-size:20px;color:black;" >Mobile No.</b></td>
             <td>
                 <asp:TextBox ID="TextBox4" runat="server" MaxLength="10" onKeyPress="return validate(event);" onSubmit="checkmobile();" class="form-control" PlaceHolder="Example:9876543210" ToolTip="Mobile number" Width="170px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Mobile number is required" ForeColor="Red" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
             </td>
         </tr>
            <tr>
                <td style="width: 198px"><b style="font-size:20px;color:black;">Account Type:</b></td>
                <td>
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="accounttype" Text="Saving" ToolTip="saving account" Checked="True" Font-Bold="True" Font-Names="Arial Black" ForeColor="Black" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="accounttype" Text="Current" ToolTip="current account" Font-Bold="True" Font-Italic="False" Font-Names="Arial Black" ForeColor="Black" />
                </td>
            </tr>
         <tr>
             <td style="width: 198px"><b style="font-size:20px;color:black;">User Image:</b></td>
             <td>
                 <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="upload profile pic" Font-Bold="True" Font-Names="Arial Black" ForeColor="Black" />
             &nbsp;
                 <asp:Label ID="Label1" runat="server" class="text-danger"></asp:Label>
                 </td>
         </tr>
          
             
         <tr>
             
             <td colspan="2" style="align-content:center">
                 <br />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="Button1" runat="server" Text="SUBMIT" class="btn btn-primary" OnClick="Button1_Click" /></td>
         </tr>         
        </table>
    </td>
    
     </tr>
    </table>
        </form>
</asp:Content>


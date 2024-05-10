<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="signup.aspx.vb" Inherits="WebApplication1.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
          h2{
              
              margin-left:25px;
              
              font-style:normal;
          }
           .card{
               margin-top:50px;
               
               
           }
           .margin{
               margin-top:5px;
           }
           .pindot{
               /*margin-left:90px;*/
           }
      </style>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
<link href="css/bootstrap.css" rel="stylesheet" />
    <link href="bootstrap-icons-1.11.3/font/bootstrap-icons.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container d-flex align-items-center justify-content-center">
    
    <div class="card" style="width: 18rem;">
          <h2>Sign up</h2>
          <div class="card-body">
              <div class="form-floating mb-3">
                    <asp:TextBox runat="server" ID="tbx_username" CssClass="form-control" placeholder="name@example.com" required></asp:TextBox>
                    <label for="tbx_username">Email address</label>
              </div>

              <div class="form-floating">
                    <asp:TextBox runat="server" ID="tbx_password" TextMode="Password" CssClass="form-control" placeholder="Password" required></asp:TextBox>
                    <label for="tbx_password">Password</label>
                </div>

              <div class="form-floating mb-3">
              </div>
              <div class="form-floating mb-3">
                      
                        <asp:TextBox ID="tbx_firstname" runat="server" CssClass="form-control" placeholder="Firstname" required></asp:TextBox>
                        <label for="tbx_firstname">First Name</label>
                </div>
                <div class="form-floating">
                    <asp:TextBox ID="tbx_lastname" runat="server" CssClass="form-control" placeholder="Lastname" required ></asp:TextBox>
                    <label for="tbx_lastname">Last Name</label>
                </div>

              <div class="form-floating mb-3"></div>
              <div class="pindot">
              <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="btn btn-success" OnClick="btnCreate_Click" />

              </div>
              <div class="margin">
                  Already have an account?<a href="signin.aspx">Sign In</a>
              </div>

              
         </div>
    </div>
</div>
  


     <script src="js/bootstrap.js"></script>
 <script src="js/bootstrap.min.js"></script>


</asp:Content>

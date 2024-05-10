<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="signin.aspx.vb" Inherits="WebApplication1.signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .container{
    display: flex;
    align-items: center;
    justify-content: center;
    min-height: 90vh;
}
.box{
    background: #fdfdfd;
    display: flex;
    flex-direction: column;
    padding: 25px 25px;
    border-radius: 20px;
    box-shadow: 0 0 128px 0 rgba(0, 0, 0, 0.1),
                0 32px 64px -48px rgba(0, 0, 0, 0.5);
}
.form-box{
    width: 450px;
    margin: 0px 10px;
}
.form-box header{
    font-size: 25px;
    font-weight: 600;
    padding-bottom: 10px;
    border-bottom: 1px solid #e6e6e6;
    margin-bottom: 10px;
}
.form-box .form .field{
    display: flex;
    margin-bottom: 10px;
    flex-direction: column;
}
.form-box .form .input input{
    height: 40px;
    width: 100%;
    font-size: 16px;
    padding: 0 10px;
    border-radius: 15px;
    border: 1px solid #ccc;
    outline: none;
}
.signin{
    height: 35px;
    background:blue;
    border: 0;
    border-radius: 15px;
    color: #fff;
    font-size: 15px;
    cursor: pointer;
}
.signin:hover{
    opacity: 0.82;
}
.submit{
    width: 100%;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container " >
        <div class="box form-box">
            <header>Login</header>
            <div class="form">
                <div class="field input">
                    <label for="username">Username</label>
                    <asp:TextBox runat="server" ID="username_login" TextMode="SingleLine" CssClass="form-control" required="required"></asp:TextBox>
                </div>
                <div class="field input">
                    <label for="username">Password</label>
                    <asp:TextBox runat="server" ID="password_login" TextMode="Password" CssClass="form-control" required="required"></asp:TextBox>

                </div>
                <div class="field">
                    <asp:Button runat="server" ID="btnLogin" CssClass="signin" Text="Login" OnClick="btnLogin_Click" />

                </div>
                <div class="links">
                    Don't have account?<a href="signup.aspx">Sign Up</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

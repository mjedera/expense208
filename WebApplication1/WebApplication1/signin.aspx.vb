Public Class signin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = username_login.Text
        Dim password As String = password_login.Text

        Dim loggedIn As Boolean = ConnectionDB.Login(username, password)

        If loggedIn Then
            ' Redirect to successful login page or perform any other action
            Session("username") = username
            'create("INSERT INTO `budget`(`username`, `budget`) VALUES ('" & username & "','0')")
            Response.Redirect("Dashboard.aspx")
        Else
            ' Display error message if login fails
            'lblMessage.Text = "Invalid username or password."
            MsgBox("Invalid username or password.")
        End If
    End Sub

End Class
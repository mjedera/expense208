Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCreate_Click(sender As Object, e As EventArgs)
        Dim username As String = tbx_username.Text
        Dim password As String = tbx_password.Text
        Dim firstName As String = tbx_firstname.Text
        Dim lastName As String = tbx_lastname.Text

        If CheckUserIfExists(username) Then
            MsgBox("Username already exists. Please choose a different username.")
        Else
            create("INSERT INTO users (`username`, `password`, `firstname`, `lastname`) VALUES ('" & username & "','" & password & "','" & firstName & "','" & lastName & "')")

        End If
        clear()


    End Sub

    Public Sub clear()
        tbx_firstname.Text = ""
        tbx_lastname.Text = ""
        tbx_password.Text = ""
        tbx_username.Text = ""
    End Sub
    Protected Sub btnSignIn_Click(sender As Object, e As EventArgs)
        Response.Redirect("signin.aspx")
    End Sub
End Class
Public Class SetBudget
    Inherits System.Web.UI.Page
    Dim username As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user As String = Session("username").ToString()
        username = user
        user_ID.Text = user
        user_ID.Visible = False

    End Sub

    Protected Sub addBudget_Click(sender As Object, e As EventArgs) Handles submitButton.Click



        If CheckUserIfExistsSetBudget(username) Then
            updates("UPDATE `budget` SET `budget`= `budget` + '" & budget.Text & "' WHERE `username` = '" & username & "'")
        Else
            create("INSERT INTO `budget`(`username`, `budget`) VALUES ('" & user_ID.Text & "','" & budget.Text & "')")
        End If






        clear()

    End Sub

    Private Sub clear()
        budget.Text = ""
    End Sub
End Class
Public Class addexpenses
    Inherits System.Web.UI.Page

    Dim users As String
    Dim userbalance As Integer
    Dim cost As Integer
    Dim newbalance As Integer
    Dim dateExpense As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        user_ID.Visible = False
        user_balance.Visible = False
        Dim user As String = Session("username").ToString()
        Dim balance As Integer = Session("sum")
        If Integer.TryParse(costofitem.Text, cost) Then
            ' Parsing successful, cost now holds the integer value from the textbox
        Else
            ' Parsing failed, handle error here
        End If

        user_ID.Text = user
        users = user_ID.Text
        user_balance.Text = balance
        userbalance = user_balance.Text
        'user_ID.Visible = False
        dateExpense = Request.Form("dateexpense")

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (userbalance > cost) Then
            newbalance = userbalance - cost
            create("INSERT INTO `expense`(`username`, `balance`, `cost`, `item`,`date`) VALUES ('" & user_ID.Text & "','" & newbalance & "','" & costofitem.Text & "','" & item.Text & "','" & dateExpense & "')")
            updates("UPDATE `budget` SET `budget`='" & newbalance & "' WHERE `username` = '" & users & "'")
        Else
            MsgBox("Not enough balance")
        End If

    End Sub

    Public Sub clear()
        costofitem.Text = ""
        item.Text = ""
    End Sub

End Class
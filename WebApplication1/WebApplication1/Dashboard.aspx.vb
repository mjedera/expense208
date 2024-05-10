Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class Dashboard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim user As String = Session("username").ToString()

        user_ID.Text = user
        user_ID.Visible = False



        'PopulateExpenseTextBox("SELECT `budget` FROM `budget` WHERE `username` = '" & user_ID.Text & "'", expenses)
        If Not IsPostBack Then
            ' Retrieve and display timestamp data from MySQL database in XAMPP
            expenses1.Text = GetTimestamp()

            yesterday.Text = GetTimestampFromYesterday()

            week.Text = GetTimestampForLastWeek()

            a_month.Text = GetTimestampForLastMonth()

            total_cost.Text = ConnectionDB.GetTotalCost()


            Dim sql As String = "SELECT SUM(budget) FROM budget WHERE `username` = '" & user_ID.Text & "'"
            ' Call the method to retrieve and display the budget sum
            GetBudgetSum(GetBudgetSumFromDatabase(sql))


            Session("sum") = expenses.Text


        End If


    End Sub

    Public Sub GetBudgetSum(ByVal budgetSum As String)
        Try
            ' Check if budget sum is not empty
            If Not String.IsNullOrEmpty(budgetSum) Then
                ' Set the text of the expenses TextBox
                expenses.Text = budgetSum
                ' Display the budget sum value in a message box

            Else
                expenses.Text = budgetSum
                ' Notify if no budget data found

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function GetBudgetSumFromDatabase(ByVal sql As String) As String
        Dim budgetSum As String = ""
        Try
            ' Open the connection
            con.Open()
            ' Set up the command
            cmd.Connection = con
            cmd.CommandText = sql
            ' Execute the query and retrieve the result
            Dim result = cmd.ExecuteScalar()
            ' Check if result is not null and convert it to string
            If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                budgetSum = result.ToString()
            Else
                budgetSum = "0"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ' Close the connection
            con.Close()
        End Try
        ' Return the budget sum value
        Return budgetSum
    End Function


    Public Function GetTimestamp() As String
        Dim timestamp As String = ""
        Dim con As New MySqlConnection("server=localhost;user id=root;database=208l_exam") ' Use connection string directly '
        Try
            con.Open()
            Dim query As String = "SELECT SUM(`cost`) AS total_expenses FROM `expense` WHERE DATE(`date`) = CURDATE() AND username = '" & user_ID.Text & "'"

            Dim cmd As New MySqlCommand(query, con)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                timestamp = reader("total_expenses").ToString()
            Else
                timestamp = "No Expenses."
            End If
            reader.Close()
        Catch ex As Exception
            timestamp = ex.Message
        Finally
            con.Close()
        End Try
        Return timestamp
    End Function

    Public Function GetTimestampFromYesterday() As String
        Dim timestamp As String = ""
        Dim con As New MySqlConnection("server=localhost;user id=root;database=208l_exam") ' Use connection string directly '
        Try
            con.Open()
            Dim query As String = "SELECT SUM(`cost`) AS total_expenses FROM `expense` WHERE DATE(`date`) = CURDATE() - INTERVAL 1 DAY AND username = '" & user_ID.Text & "'"

            Dim cmd As New MySqlCommand(query, con)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                timestamp = reader("total_expenses").ToString()
            Else
                timestamp = "No Expenses."
            End If
            reader.Close()
        Catch ex As Exception
            timestamp = ex.Message
        Finally
            con.Close()
        End Try
        Return timestamp
    End Function

    Public Function GetTimestampForLastWeek() As String
        Dim timestamp As String = ""
        Dim con As New MySqlConnection("server=localhost;user id=root;database=208l_exam") ' Use connection string directly '
        Try
            con.Open()
            Dim query As String = "SELECT SUM(`cost`) AS total_expenses FROM `expense` WHERE `date` >= DATE_SUB(CURDATE(), INTERVAL 7 DAY) AND `date` < CURDATE() AND username = '" & user_ID.Text & "'"

            Dim cmd As New MySqlCommand(query, con)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                timestamp = reader("total_expenses").ToString()
            Else
                timestamp = "No Expenses."
            End If
            reader.Close()
        Catch ex As Exception
            timestamp = ex.Message
        Finally
            con.Close()
        End Try
        Return timestamp
    End Function

    Public Function GetTimestampForLastMonth() As String
        Dim timestamp As String = ""
        Dim con As New MySqlConnection("server=localhost;user id=root;database=208l_exam") ' Use connection string directly '
        Try
            con.Open()
            Dim query As String = "SELECT SUM(`cost`) AS total_expenses FROM `expense` WHERE `date` >= DATE_SUB(CURDATE(), INTERVAL 1 MONTH) AND `date` < CURDATE() AND username = '" & user_ID.Text & "'"

            Dim cmd As New MySqlCommand(query, con)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                timestamp = reader("total_expenses").ToString()
            Else
                timestamp = "No Expenses."
            End If
            reader.Close()
        Catch ex As Exception
            timestamp = ex.Message
        Finally
            con.Close()
        End Try
        Return timestamp
    End Function

End Class

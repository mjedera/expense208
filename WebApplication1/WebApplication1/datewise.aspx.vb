Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Web.Script.Serialization

Public Class datewise
    Inherits System.Web.UI.Page
    Dim date_from, date_to As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim user As String = Session("username").ToString()
        user_ID.Text = user
        user_ID.Visible = False
        user_balance.Visible = False

        date_from = Request.Form("date_from")
        date_to = Request.Form("date_to")

        'If Not IsPostBack Then
        '    PopulateExpenseTable()
        'End If
        show()

    End Sub

    Public Sub show()
        Table_Expense.Visible = False
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PopulateExpenseTable()
        Table_Expense.Visible = True
    End Sub



    Private Sub PopulateExpenseTable()
        Using connection As MySqlConnection = ConnectionDB.mysqlconnection()
            ' Write your SQL query to fetch data
            Dim query As String = "SELECT `balance`, `cost`, `item`, `date` FROM `expense` WHERE date >= '" & date_from & "' AND username = '" & user_ID.Text & "'  "
            Using command As New MySqlCommand(query, connection)
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Loop through the result set and populate the table
                    While reader.Read()
                        Dim balance As String = reader("Balance").ToString()
                        Dim cost As String = reader("Cost").ToString()
                        Dim item As String = reader("Item").ToString()
                        Dim [date] As String = reader("Date").ToString()

                        ' Create a new row for the table
                        Dim row As New HtmlTableRow()

                        ' Create cells for the row
                        Dim balanceCell As New HtmlTableCell()
                        balanceCell.InnerText = balance
                        row.Cells.Add(balanceCell)

                        Dim costCell As New HtmlTableCell()
                        costCell.InnerText = cost
                        row.Cells.Add(costCell)

                        Dim itemCell As New HtmlTableCell()
                        itemCell.InnerText = item
                        row.Cells.Add(itemCell)

                        Dim dateCell As New HtmlTableCell()
                        dateCell.InnerText = [date]
                        row.Cells.Add(dateCell)

                        ' Add the row to the table
                        Table_Expense.Rows.Add(row)
                    End While
                End Using
            End Using
        End Using
    End Sub

End Class

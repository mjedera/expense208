Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Module ConnectionDB
    'Setting up connection'
    Public Function mysqlconnection() As MySqlConnection
        Return New MySqlConnection("server=localhost;user id=root;database=208l_exam")
    End Function

    Public con As MySqlConnection = mysqlconnection()

    'delclaring a string'
    Public result As String

    'declaring the class

    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable

    'for inserting the data to the database'

    Public Sub create(ByVal sql As String)
        Try
            ''open the connection
            con.Open()
            ''holds the data
            With cmd
                .Connection = con
                .CommandText = sql

                ''execute the data
                result = cmd.ExecuteNonQuery


                If result = 0 Then
                    MsgBox("no data saved", MsgBoxStyle.Information)
                Else
                    MsgBox("data saved to the database", MsgBoxStyle.Information)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    'for holding the data to retrieve
    Public Sub reload(ByVal sql)
        Try
            dt = New DataTable
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
        da.Dispose()
    End Sub

    'filling the table and retrieb=ving the data to the data to the datagridview from the database

    Public Sub filltable(ByVal dtg As GridView)
        Try
            con.Open()

            da.SelectCommand = cmd
            da.Fill(dt)
            dtg.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        con.Close()
        da.Dispose()
    End Sub


    'updating the dat from the database
    Public Sub updates(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery

                If result = 0 Then
                    MsgBox("No updated data", MsgBoxStyle.Information)
                Else
                    MsgBox("data in the database has been updated")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        con.Close()
    End Sub



    'deleting the data from the database
    Public Sub delete(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql

                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox("Error query for deleting a data", MsgBoxStyle.Critical)
                Else
                    MsgBox("data in the database has been deleted")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()

        End Try
    End Sub

    ''check if username exist
    Public Function CheckUserIfExists(username As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM users WHERE username = @Username"
        Dim count As Integer = 0

        Using connection As MySqlConnection = mysqlconnection()
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Username", username)
                Try
                    connection.Open()
                    count = Convert.ToInt32(command.ExecuteScalar())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        Return count > 0
    End Function

    Public Function Login(ByVal username As String, ByVal password As String) As Boolean
        Dim success As Boolean = False
        Dim query As String = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password"
        Using connection As MySqlConnection = mysqlconnection()
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)
                Try
                    connection.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        success = True
                    End If
                Catch ex As Exception
                    MsgBox("Error: " & ex.Message)
                End Try
            End Using
        End Using
        Return success
    End Function

    Public Sub PopulateExpenseTextBox(ByVal sql As String, ByVal textBox As TextBox)
        Try
            ' Open the connection
            con.Open()

            ' Set up the command
            With cmd
                .Connection = con
                .CommandText = sql
            End With

            ' Retrieve data
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                ' Assuming the data is in the first column, change the index accordingly
                Dim expenseData As String = reader.GetString(0)

                ' Populate the TextBox with the retrieved data
                textBox.Text = expenseData

                'MsgBox("Data retrieved successfully", MsgBoxStyle.Information)
            Else
                ' Handle case where no data is retrieved
                'textBox.Text = "No data found"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ' Close the connection
            con.Close()
        End Try
    End Sub



    'Public Function GetTimestampFromYesterday() As String
    '    Dim timestamp As String = ""
    '    Try
    '        con.Open()
    '        Dim query As String = "SELECT `date` FROM `expense` WHERE `date` = CURDATE() - INTERVAL 1 DAY"
    '        Using cmd As New MySqlCommand(query, con)
    '            Dim reader As MySqlDataReader = cmd.ExecuteReader()
    '            If reader.Read() Then
    '                timestamp = reader("date").ToString()
    '            Else
    '                timestamp = "No expenses."
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        timestamp = ex.Message
    '    Finally
    '        con.Close()
    '    End Try
    '    Return timestamp
    'End Function

    'Public Function GetTimestampForLastWeek() As String
    '    Dim timestamp As String = ""
    '    Try
    '        con.Open()
    '        Dim query As String = "SELECT `date` FROM `expense` WHERE `date` >= CURDATE() - INTERVAL 7 DAY"
    '        Using cmd As New MySqlCommand(query, con)
    '            Dim reader As MySqlDataReader = cmd.ExecuteReader()
    '            If reader.Read() Then
    '                timestamp = reader("date").ToString()
    '            Else
    '                timestamp = "No expenses."
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        timestamp = ex.Message
    '    Finally
    '        con.Close()
    '    End Try
    '    Return timestamp
    'End Function

    Public Function GetTimestampForLastMonth() As String
        Dim timestamp As String = ""
        Try
            con.Open()
            Dim query As String = "SELECT `date` FROM `expense` WHERE `date` >= CURDATE() - INTERVAL 1 MONTH"
            Using cmd As New MySqlCommand(query, con)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    timestamp = reader("`date`").ToString()
                Else
                    timestamp = "No expenses."
                End If
            End Using
        Catch ex As Exception
            timestamp = ex.Message
        Finally
            con.Close()
        End Try
        Return timestamp
    End Function

    Public Function GetTotalCost() As String
        Dim totalCost As String = ""
        Try
            con.Open()
            Dim query As String = "SELECT SUM(`cost`) AS total_cost FROM `expense`"
            Using cmd As New MySqlCommand(query, con)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    If Not IsDBNull(reader("total_cost")) Then
                        totalCost = reader("total_cost").ToString()
                    Else
                        totalCost = "No expenses"
                    End If
                Else
                    totalCost = "00.00"
                End If
            End Using
        Catch ex As Exception
            totalCost = ex.Message
        Finally
            con.Close()
        End Try
        Return totalCost
    End Function

    Public Sub expenses_tbl(ByVal sql As String)
        Try
            ''open the connection
            con.Open()
            ''holds the data
            With cmd
                .Connection = con
                .CommandText = sql

                ''execute the data
                result = cmd.ExecuteNonQuery


                If result = 0 Then

                Else

                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Public Function CheckUserIfExistsSetBudget(username As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM budget WHERE username = @Username"
        Dim count As Integer = 0

        Using connection As MySqlConnection = mysqlconnection()
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Username", username)
                Try
                    connection.Open()
                    count = Convert.ToInt32(command.ExecuteScalar())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        Return count > 0
    End Function


End Module



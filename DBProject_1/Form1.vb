Imports MySql.Data.MySqlClient

Public Class Form1
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server = localhost;userid = root;password = 08133973657;database = mydb"
        Try
            MySqlConn.Open()
            MessageBox.Show("Connection Successful")
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server = localhost;userid = root;password = 08133973657;database = mydb"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from mydb.connpractice where user_name ='" & TextBox1.Text & "'and password = '" & TextBox2.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            If count = 1 Then
                MessageBox.Show("Username and password is correct")
                Form2.Show()
                Me.Hide()
            ElseIf count > 1 Then
                MessageBox.Show("Username and password is Duplicate")

            Else
                MessageBox.Show("Username and password is not correct")
                TextBox2.Text = ""
                TextBox1.Text = ""
            End If
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub
End Class

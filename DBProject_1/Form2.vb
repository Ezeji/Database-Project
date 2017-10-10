Imports MySql.Data.MySqlClient
Public Class Form2
    Dim gender As String
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim dbDataSet As New DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server = localhost;userid = root;password = 08133973657;database = mydb"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "insert into mydb.connpractice(eid,name,surname,age,gender,DOB)values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & gender & "','" & DateTimePicker1.Text & "')"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            MessageBox.Show("Data Saved")
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
        load_table()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server = localhost;userid = root;password = 08133973657;database = mydb"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "update mydb.connpractice set eid ='" & TextBox1.Text & "',name ='" & TextBox2.Text & "',surname ='" & TextBox3.Text & "',age ='" & TextBox4.Text & "' where eid ='" & TextBox1.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            MessageBox.Show("Data Updated")
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
        load_table()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server = localhost;userid = root;password = 08133973657;database = mydb"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "delete from mydb.connpractice where eid = '" & TextBox1.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            MessageBox.Show("Data Deleted")
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
        load_table()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server = localhost;userid = root;password = 08133973657;database = mydb"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from mydb.connpractice"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Dim sName = READER.GetString("name")
                ComboBox1.Items.Add(sName)
                ListBox1.Items.Add(sName)
            End While
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server = localhost;userid = root;password = 08133973657;database = mydb"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from mydb.connpractice where name = '" & ComboBox1.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                TextBox1.Text = READER.GetInt32("Eid")
                TextBox2.Text = READER.GetString("name")
                TextBox3.Text = READER.GetString("surname")
                TextBox4.Text = READER.GetInt32("age")
            End While
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server = localhost;userid = root;password = 08133973657;database = mydb"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from mydb.connpractice where name = '" & ListBox1.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                TextBox1.Text = READER.GetInt32("Eid")
                TextBox2.Text = READER.GetString("name")
                TextBox3.Text = READER.GetString("surname")
                TextBox4.Text = READER.GetInt32("age")
            End While
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub
    Private Sub load_table()
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server = localhost;userid = root;password = 08133973657;database = mydb"
        Dim SDA As MySqlDataAdapter

        Dim bsource As New BindingSource
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select eid as 'Employee ID',name as 'First Name',surname as 'Last Name',age as 'Age' from mydb.connpractice"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            SDA = New MySqlDataAdapter
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bsource.DataSource = dbDataSet
            DataGridView1.DataSource = bsource
            SDA.Update(dbDataSet)
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server = localhost;userid = root;password = 08133973657;database = mydb"
        Dim SDA As MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bsource As New BindingSource
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select eid,name,surname,age from mydb.connpractice"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            SDA = New MySqlDataAdapter
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bsource.DataSource = dbDataSet
            DataGridView1.DataSource = bsource
            SDA.Update(dbDataSet)
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow
        If e.RowIndex >= 0 Then
            row = Me.DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("eid").Value.ToString
            TextBox2.Text = row.Cells("name").Value.ToString
            TextBox3.Text = row.Cells("surname").Value.ToString
            TextBox4.Text = row.Cells("age").Value.ToString
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Dim DV As New DataView(dbDataSet)
        DV.RowFilter = String.Format("name Like '%{0}%'", TextBox5.Text)
        DataGridView1.DataSource = DV
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server = localhost;userid = root;password = 08133973657;database = mydb"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from mydb.connpractice "
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Chart1.Series("NAME_VS_AGE").Points.AddXY(READER.GetString("name"), READER.GetInt32("age"))
            End While
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to close the app", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        gender = "Male"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        gender = "Female"
    End Sub
End Class
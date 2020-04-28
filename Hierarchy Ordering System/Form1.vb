Imports System.Data.OleDb

Public Class Form1

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button7_Click_1(sender As System.Object, e As System.EventArgs) Handles Button7.Click


        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\HierarchyDb.accdb")
        Dim cmd As OleDbCommand = New OleDbCommand(
                   "SELECT * FROM admin WHERE username = '" &
                   Hierarchy_Cashier_Form.Usname & "' AND [password] = '" & TextBox1.Text & "' ", con)
        con.Open()
        Dim sdr As OleDbDataReader = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            Hierarchy_Admin_Form.TabControl2.SelectTab(1)
            Hierarchy_Admin_Form.Label8.Text = "ADMIN"
            Me.Close()
            Hierarchy_Admin_Form.Panel36.Visible = True
            Hierarchy_Admin_Form.Panel37.Visible = False
        Else
            Label1.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
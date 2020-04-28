Imports System.Data.OleDb
Public Class LoadingForm

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Anchor = AnchorStyles.None

        Loadtimer.Start()
    End Sub

    Private loadcount As Integer = 0

    Private Sub Loadtimer_Tick(sender As Object, e As EventArgs) Handles Loadtimer.Tick
        loadcount += 1
        If loadcount = 6 Then
            Loadtimer.Stop()
            Animate.Start()
            PictureBox1.Visible = False
            PictureBox2.Visible = False
            'Animate.Start()
            'Hierarchy_Cashier_Form.Show()
            Panel1.Show()
        End If

    End Sub
    Private Sub login()

    End Sub
    Private Sub cnter()

    End Sub

    Private Sub CenterButton()
        PictureBox1.Top = (Me.ClientSize.Height / 2) - (PictureBox1.Height / 2)
        PictureBox1.Left = (Me.ClientSize.Width / 2) - (PictureBox1.Width / 2)

        PictureBox2.Top = ((Me.ClientSize.Height / 3) - (PictureBox2.Height / 3)) + ((Me.ClientSize.Height / 3) - (PictureBox2.Height / 3))
        PictureBox2.Left = (Me.ClientSize.Width / 2) - (PictureBox2.Width / 2)

        Panel1.Top = (Me.ClientSize.Height / 2) - (Panel1.Height / 2)
        Panel1.Left = (Me.ClientSize.Width / 2) - (Panel1.Width / 2)

    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        CenterButton()
    End Sub

    Private Sub Animate_Tick(sender As Object, e As EventArgs) Handles Animate.Tick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\HierarchyDb.accdb")
        Dim cmd As OleDbCommand = New OleDbCommand(
                   "SELECT * FROM cashier WHERE username = '" &
                   username.Text & "' AND [password] = '" & password.Text & "' ", con)
        con.Open()
        Dim sdr As OleDbDataReader = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            Hierarchy_Cashier_Form.Usname = username.Text
            Hierarchy_Cashier_Form.Show()
            Me.Close()
        Else
            logininfoerror.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\HierarchyDb.accdb")
        Dim cmd As OleDbCommand = New OleDbCommand(
                   "SELECT * FROM admin WHERE username = '" &
                   username.Text & "' AND [password] = '" & password.Text & "' ", con)
        con.Open()
        Dim sdr As OleDbDataReader = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            Me.Hide()
            Hierarchy_Cashier_Form.Usname = username.Text
            Hierarchy_Admin_Form.Show()
        Else
            logininfoerror.Show()
        End If
    End Sub

    Private Sub username_TextChanged(sender As Object, e As EventArgs) Handles username.TextChanged
        logininfoerror.Hide()
        acctypelblerr.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged
        logininfoerror.Hide()
        acctypelblerr.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class

Public Class Hierarchy_Admin_Form


    Private Sub Hierarchy_Admin_Form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'InfoDataSet.info' table. You can move, or remove it, as needed.
        Me.InfoTableAdapter.Fill(Me.InfoDataSet.info)
        'TODO: This line of code loads data into the 'HierarchyHistoryDbDataSet.SALEHISTORY' table. You can move, or remove it, as needed.
        Me.SALEHISTORYTableAdapter1.Fill(Me.HierarchyHistoryDbDataSet.SALEHISTORY)
        'TODO: This line of code loads data into the 'HierarchyHistoryDbDataSet.SALEHISTORY' table. You can move, or remove it, as needed.
        Me.SALEHISTORYTableAdapter1.Fill(Me.HierarchyHistoryDbDataSet.SALEHISTORY)
        'TODO: This line of code loads data into the 'HierarchyDbDataSet.admin' table. You can move, or remove it, as needed.
        Me.AdminTableAdapter.Fill(Me.HierarchyDbDataSet.admin)
        'TODO: This line of code loads data into the 'HierarchyDbDataSet.cashier' table. You can move, or remove it, as needed.
        Me.CashierTableAdapter.Fill(Me.HierarchyDbDataSet.cashier)
        'TODO: This line of code loads data into the 'HierarchyDbDataSet.products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.HierarchyDbDataSet.products)
        'TODO: This line of code loads data into the 'HierarchyDbDataSet.salehistory' table. You can move, or remove it, as needed.
        Me.SalehistoryTableAdapter.Fill(Me.HierarchyDbDataSet.salehistory)
        Panel1.Visible = True
        TabControl1.SelectedTab = TabPage1
        Label8.Text = "CASHIER"
        tax.Text = My.Settings.TAX
        discount.Text = My.Settings.discount
        moneyearn.Text = My.Settings.money
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        Panel1.Visible = True

    End Sub
    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint, Panel9.Paint, Panel8.Paint, Panel7.Paint, Panel11.Paint, Panel10.Paint, Panel12.Paint, Panel14.Paint, Panel21.Paint, Panel20.Paint, Panel19.Paint, Panel18.Paint, Panel17.Paint, Panel22.Paint, Panel23.Paint, Panel24.Paint, Panel28.Paint, Panel27.Paint, Panel29.Paint, Panel13.Paint, Panel32.Paint, Panel31.Paint, Panel37.Paint, Panel36.Paint, Panel26.Paint, Panel25.Paint

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Panel1.Visible = True
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        TabControl1.SelectedTab = TabPage1
        Label8.Text = "CASHIER"

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Panel1.Visible = False
        Panel3.Visible = True
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        TabControl1.SelectedTab = TabPage2
        Label8.Text = "CASHIER"
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Panel37.Visible = True
        Panel36.Visible = False
        Panel1.Visible = False
        Panel3.Visible = False
        Panel4.Visible = True
        Panel5.Visible = False
        Panel6.Visible = False
        TabControl1.SelectedTab = TabPage3
        TabControl2.SelectedTab = TabPage6
        Label8.Text = "CASHIER"
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Panel1.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = True
        Panel6.Visible = False
        TabControl1.SelectedTab = TabPage4
        Label8.Text = "CASHIER"
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = True
        TabControl1.SelectedTab = TabPage5
        Panel1.Visible = False
        Label8.Text = "CASHIER"
    End Sub

    Private Sub SalehistoryBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.SalehistoryBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.HierarchyDbDataSet)

    End Sub

    Private Sub SalehistoryDataGridView_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub ProductsDataGridView_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Panel16_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel16.Paint

    End Sub
    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Panel1.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = True
        TabControl1.SelectedTab = TabPage5
    End Sub

    Private Sub Button6_Click_1(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        ProductsBindingSource.AddNew()
    End Sub
    Private Sub Button9_Click_1(sender As System.Object, e As System.EventArgs) Handles Button9.Click

        ProductsBindingSource.EndEdit()
        ProductsTableAdapter.Update(HierarchyDbDataSet.products)
    End Sub

    Private Sub IDser()
        TextBox1.Clear()
        SALEHISTORYTableAdapter1.Adapter.SelectCommand.CommandText = "Select * from  SALEHISTORY where datesold like '%" & TextBox2.Text & "%'"
        Me.SALEHISTORYTableAdapter1.Fill(Me.HierarchyHistoryDbDataSet.SALEHISTORY)
    End Sub

    Private Sub REser()
        TextBox2.Clear()
        SALEHISTORYTableAdapter1.Adapter.SelectCommand.CommandText = "Select * from  SALEHISTORY where receiptno like '%" & TextBox1.Text & "%'"
        Me.SALEHISTORYTableAdapter1.Fill(Me.HierarchyHistoryDbDataSet.SALEHISTORY)
    End Sub



    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim theText As String = TextBox1.Text
        Dim Letter As String
        Dim notallowed As String = "'"
        For x As Integer = 0 To TextBox1.Text.Length - 1
            Letter = TextBox1.Text.Substring(x, 1)
            If notallowed.Contains(Letter) Then
                TextBox1.Clear()
            End If
        Next
        REser()
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        Dim theText As String = TextBox2.Text
        Dim Letter As String
        Dim notallowed As String = "'"
        For x As Integer = 0 To TextBox2.Text.Length - 1
            Letter = TextBox2.Text.Substring(x, 1)
            If notallowed.Contains(Letter) Then
                TextBox2.Clear()
            End If
        Next

        IDser()
    End Sub


    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        ProductsBindingSource.RemoveCurrent()
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        Form1.Show()
    End Sub

    Private Sub Button7_Click_1(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Panel37.Visible = True
        Panel36.Visible = False
        TabControl2.SelectedTab = TabPage6
        Label8.Text = "CASHIER"


    End Sub

    Private Sub TabPage3_Click(sender As System.Object, e As System.EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        CashierBindingSource.EndEdit()
        CashierTableAdapter.Update(HierarchyDbDataSet.cashier)
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        CashierBindingSource.AddNew()
      
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        CashierBindingSource.RemoveCurrent()

    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        AdminBindingSource.EndEdit()
        AdminTableAdapter.Update(HierarchyDbDataSet.admin)
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        AdminBindingSource.AddNew()
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        AdminBindingSource.RemoveCurrent()
        AdminTableAdapter.Update(HierarchyDbDataSet.admin)
    End Sub

    Private Sub Panel2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label12_Click(sender As System.Object, e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click

        InfoBindingSource.EndEdit()
        InfoTableAdapter.Update(InfoDataSet.info)

    End Sub
    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs)

        InfoBindingSource.AddNew()

    End Sub

    Private Sub TabPage2_Click(sender As System.Object, e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Button18_Click_1(sender As System.Object, e As System.EventArgs) Handles Button18.Click


        If discount.Text = "" Or tax.Text = "" Then
            MsgBox("fill the blanks")
        ElseIf discount.Text >= 0 Or tax.Text >= 0 Then
            My.Settings.TAX = tax.Text
            My.Settings.discount = discount.Text
            My.Settings.Save()
        Else
            MsgBox("input valid number")
        End If

    End Sub

    Private Sub discount_TextChanged(sender As System.Object, e As System.EventArgs) Handles discount.TextChanged

    End Sub

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        Me.Close()
        LoadingForm.Close()
        Hierarchy_Cashier_Form.Close()

    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
        LoadingForm.Show()
        Me.Close()
    End Sub

    Private Sub TabPage6_Click(sender As Object, e As EventArgs) Handles TabPage6.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click


    End Sub
End Class
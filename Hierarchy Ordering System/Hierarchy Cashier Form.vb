Public Class Hierarchy_Cashier_Form
    Private Sub Hierarchy_Cashier_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'InfoDataSet.info' table. You can move, or remove it, as needed.
        Me.InfoTableAdapter.Fill(Me.InfoDataSet.info)
        'TODO: This line of code loads data into the 'HierarchyHistoryDbDataSet.SALEHISTORY' table. You can move, or remove it, as needed.
        Me.SALEHISTORYTableAdapter2.Fill(Me.HierarchyHistoryDbDataSet.SALEHISTORY)
        'TODO: This line of code loads data into the 'HierarchyDbDataSet.salehistory' table. You can move, or remove it, as needed.
        Me.SalehistoryTableAdapter.Fill(Me.HierarchyDbDataSet.salehistory)
        'TODO: This line of code loads data into the 'HierarchyDbDataSet.products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.HierarchyDbDataSet.products)
        Timer1.Start()
        ProductsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None
        Username.Text = Usname
    End Sub

    Public Usname As String = ""

    Private Sub ProductsBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.HierarchyDbDataSet)
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        For i = 0 To ProductsDataGridView.Rows.Count - 1
            ProductsDataGridView.Rows(i).Height = 30
        Next
        totalpanel.Width = (Panel3.Width / 2) - 8
        Panel7.Width = (Panel3.Width / 2) - 15
        Datelbl.Text = System.DateTime.Now.ToShortDateString & "  " & System.DateTime.Now.ToLongTimeString
        Dim coldiv = ProductsDataGridView.Width / 4
        DataGridViewTextBoxColumn2.Width = coldiv
        DataGridViewTextBoxColumn3.Width = coldiv
        DataGridViewTextBoxColumn4.Width = coldiv
        DataGridViewTextBoxColumn5.Width = coldiv
        itempriceval.Text = PriceTextBox.Text
        Item.Text = ItemsTextBox.Text
        itemtotalvaltop.Text = Val(PriceTextBox.Text) * Val(qty.Text)
    End Sub

    Dim totalngprice As Integer = 0
    Dim ilangitem1 As Integer = 0

    Public Sub compute()
        totalngprice = 0
        ilangitem1 = 0

        For c = 0 To ListBox2.Items.Count - 1
            ListBox2.SelectedIndex = c
            totalngprice += Val(ListBox2.SelectedItem)
        Next

        For c = 0 To ListBox3.Items.Count - 1
            ListBox3.SelectedIndex = c
            ilangitem1 += Val(ListBox3.SelectedItem)
        Next

        walapangtax.Text = totalngprice
        ilangitem.Text = ilangitem1
        If pwddiscount.Checked Then
            tax.Text = 0
            discountval.Text = ((Val(My.Settings.pwd) * Val(walapangtax.Text)) / 100)
            totalnglahat.Text = (Val(walapangtax.Text) + Val(tax.Text)) - Val(discountval.Text)
        ElseIf nodiscount.Checked Then
            discountval.Text = Val(My.Settings.discount)
            If discountval.Text > 0 Then
                tax.Text = 0
                Dim ddddd As Integer = (Val(discountval.Text) * (walapangtax.Text)) / 100
                discountval.Text = ddddd
                totalnglahat.Text = (Val(walapangtax.Text) + Val(tax.Text)) - ddddd
            Else
                tax.Text = (Val(walapangtax.Text) * Val(My.Settings.TAX)) / 100
                totalnglahat.Text = (Val(walapangtax.Text) + Val(tax.Text))
            End If
        End If
        bayad2.Text = bayad1.Text
        totalnglahat2.Text = totalnglahat.Text
        sukli.Text = Val(bayad2.Text) - Val(totalnglahat2.Text)
        totalngprice = 0
        ilangitem1 = 0


        printo()
    End Sub

    Private Sub barsearchtxtbox_TextChanged(sender As System.Object, e As System.EventArgs) Handles barsearchtxtbox.TextChanged, barsearchtxtbox.Click
        ranchpanelhide()
        Dim theText As String = barsearchtxtbox.Text
        Dim Letter As String
        Dim notallowed As String = "'"
        For x As Integer = 0 To barsearchtxtbox.Text.Length - 1
            Letter = barsearchtxtbox.Text.Substring(x, 1)
            If notallowed.Contains(Letter) Then
                barsearchtxtbox.Clear()
            End If
        Next
        searbar()
    End Sub

    Private Sub itemsearchtxtbox_TextChanged(sender As System.Object, e As System.EventArgs) Handles itemsearchtxtbox.TextChanged
        ranchpanelhide()
        Dim theText As String = itemsearchtxtbox.Text
        Dim Letter As String
        Dim notallowed As String = "'"
        For x As Integer = 0 To itemsearchtxtbox.Text.Length - 1
            Letter = itemsearchtxtbox.Text.Substring(x, 1)
            If notallowed.Contains(Letter) Then
                itemsearchtxtbox.Clear()
            End If
        Next
        isear()
    End Sub

    Private Sub ranchpanelhide()
        hiddenranchpanel.Hide()
    End Sub

    Private Sub searbar()
        itemsearchtxtbox.Clear()
        ProductsTableAdapter.Adapter.SelectCommand.CommandText = "Select * from products where barcode like '%" & barsearchtxtbox.Text & "%'"
        Me.ProductsTableAdapter.Fill(Me.HierarchyDbDataSet.products)
    End Sub

    Private Sub isear()
        barsearchtxtbox.Clear()
        ProductsTableAdapter.Adapter.SelectCommand.CommandText = "Select * from products where items like '%" & itemsearchtxtbox.Text & "%'"
        Me.ProductsTableAdapter.Fill(Me.HierarchyDbDataSet.products)
    End Sub

    Private Sub ItemsTextBox_TextChanged(sender As Object, e As EventArgs) Handles ItemsTextBox.TextChanged
        Item.Text = ItemsTextBox.Text
        itemtotalvaltop.Text = Val(PriceTextBox.Text) * Val(qty.Text)
    End Sub

    Private Sub Item_TextChanged(sender As Object, e As EventArgs) Handles Item.TextChanged, itempriceval.TextChanged
        ranchpanelhide()

    End Sub

    Private Sub qty_TextChanged(sender As Object, e As EventArgs) Handles qty.TextChanged
        ranchpanelhide()
        Item.Text = ItemsTextBox.Text
        itemtotalvaltop.Text = Val(PriceTextBox.Text) * Val(qty.Text)
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ranchpanelhide()
        ListBox2.SelectedIndex = ListBox1.SelectedIndex
        ListBox3.SelectedIndex = ListBox1.SelectedIndex
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        ranchpanelhide()
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
        ListBox3.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        ranchpanelhide()
        ListBox2.SelectedIndex = ListBox3.SelectedIndex
        ListBox1.SelectedIndex = ListBox3.SelectedIndex
    End Sub


    Private Sub dagdagitem_Click(sender As Object, e As EventArgs) Handles dagdagitem.Click
        ranchpanelhide()
        If Item.Text = "" Then
            MsgBox("Nothing to add")
        Else

            If qty.Text = "" Or qty.Text = "0" Then
                ' MsgBox("Quantity Should Not Be Empty!")
            Else
                If ListBox1.Items.Count <= 0 Then
                    ListBox1.Items.Add(Item.Text)
                    ListBox2.Items.Add(itemtotalvaltop.Text)
                    ListBox3.Items.Add(qty.Text)
                    itemremovedlbl.Text = "ITEM ADDED"
                    tmrno2 = 0
                    totalngprice = 0
                    compute()
                    printo()
                    writetoimage()
                    toads()
                Else
                    finduplicate()
                End If
            End If
        End If
    End Sub

    Private Sub toads()
        Dim pricevaltextitem As String = ListBox1.SelectedItem & "  Price " & PriceTextBox.Text & "(" & ListBox3.SelectedItem & ") :  " & ListBox2.SelectedItem
        'MsgBox(pricevaltextitem)
        Adsform.itemandprice.Text = "" & ListBox1.SelectedItem & "  Price " & PriceTextBox.Text & " (" & ListBox3.SelectedItem & ") =  " & ListBox2.SelectedItem
        Adsform.Label1.Visible = False
        Adsform.fnlchange.Visible = False
        Adsform.Label5.Visible = True
        Adsform.Label5.Text = "TOTAL: " & totalnglahat2.Text
    End Sub

    Private Sub tohidead()
        Label5.Visible = False
        Adsform.fnlchange.Visible = True
        Adsform.Label2.Visible = True
        Adsform.Label4.Visible = True
        Adsform.fnlchange.Visible = True
        Adsform.Label2.Text = "CASH: " & bayad2.Text
        Adsform.Label4.Text = "TOTAL: " & totalnglahat2.Text
        Adsform.fnlchange.Text = "CHANGE: " & sukli.Text
        Timer2.Start()
    End Sub

    Dim cccount As Integer = 0
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        cccount += 1
        If cccount = 6 Then
            Timer2.Stop()
            Adsform.Label1.Visible = True
            Adsform.Label2.Visible = False
            Adsform.Label4.Visible = False
            Adsform.fnlchange.Visible = False
            Adsform.Label5.Visible = False
            Adsform.itemandprice.Text = ""
        End If
    End Sub

    Dim indexx As Integer
    Dim findnumberqty As Integer

    Private Sub finduplicate()
        Dim tff As Boolean = False
        For u = 0 To ListBox1.Items.Count - 1
            'MsgBox(u)
            ListBox1.SelectedIndex = u
            If ListBox1.SelectedItem = Item.Text Then
                findnumberqty = 0
                indexx = u
                findnumberqty = Val(ListBox3.SelectedItem)
                tff = True
                replace()
                u = ListBox1.Items.Count
            End If
            'MsgBox(":)")
        Next
        If tff = False Then
            add()
            toads()
        End If
    End Sub

    Private Sub add()
        ListBox1.Items.Add(Item.Text)
        ListBox2.Items.Add(itemtotalvaltop.Text)
        ListBox3.Items.Add(qty.Text)
        itemremovedlbl.Text = "ITEM ADDED"
        tmrno2 = 0
        totalngprice = 0
        compute()
        printo()
        writetoimage()
    End Sub

    Private Sub replace()
        ListBox1.Items.RemoveAt(indexx)
        ListBox2.Items.RemoveAt(indexx)
        ListBox3.Items.RemoveAt(indexx)
        'MsgBox("find qty ")
        ListBox1.Items.Add(Item.Text)
        ListBox3.Items.Add(findnumberqty + Val(qty.Text))
        ListBox2.Items.Add((findnumberqty + Val(qty.Text)) * itempriceval.Text)
        totalngprice = 0
        compute()
        printo()
        writetoimage()
    End Sub

    Private Sub tangalitem_Click(sender As Object, e As EventArgs) Handles tangalitem.Click
        ranchpanelhide()
        If ListBox1.Items.Count <= 0 Then
            MsgBox("NOTHING TO REMOVE BITCH LASAGNA! DRINK GFUEL TO KEEP YOU IN FOCUS", vbOK, vbCritical)
        Else
            securitymeasures.Show()
        End If
    End Sub

    Public Sub removeitem()
        Dim msg As MsgBoxResult
        If ListBox1.SelectedIndex = -1 Then
            If ListBox1.Items.Count = 0 Then
                msg = MsgBox("There Are No Items to Delete", vbInformation)
            Else
                msg = MsgBox("Please Select an Item to Delete", vbInformation)
            End If
        Else
            itemremovedlbl.Text = "ITEM REMOVED"
            removeiteminv()
        End If
    End Sub

    Private Sub removeiteminv()
        Dim indexx As Integer = ListBox1.SelectedIndex
        Dim indexxx As Integer = ListBox2.SelectedIndex
        Dim indexxxx As Integer = ListBox3.SelectedIndex
        ListBox1.Items.RemoveAt(indexx)
        ListBox2.Items.RemoveAt(indexxx)
        ListBox3.Items.RemoveAt(indexxxx)
    End Sub

    Dim tmrno2 As Integer = 0


    Private Sub pangburangtransaction_Click(sender As Object, e As EventArgs) Handles pangburangtransaction.Click
        ranchpanelhide()
        If ListBox1.Items.Count <= 0 Then
            MsgBox("NOTHING TO CANCEL BITCH LASAGNA! DRINK GFUEL TO KEEP YOU IN FOCUS", vbOK, vbCritical)
        Else
            securitymeasures2.Show()
        End If

    End Sub

    Public Sub cancel()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
    End Sub

    Private Sub pwddiscount_CheckedChanged(sender As Object, e As EventArgs)
        nodiscount.Checked = False
        pwddiscount.Checked = True
    End Sub


    Private Sub closeform() Handles Me.Closing
        LoadingForm.Close()
    End Sub

    Private Sub bayad1_TextChanged(sender As Object, e As EventArgs) Handles bayad1.TextChanged
        ranchpanelhide()
        totalngprice = 0
        compute()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font As New Font("Arial", 2, FontStyle.Regular)
        e.Graphics.DrawString(RichTextBox1.Text, font, Brushes.Black, 10, 10)
    End Sub

    Private Sub checkoutbtn_Click(sender As Object, e As EventArgs) Handles checkoutbtn.Click
        ranchpanelhide()
        If ListBox1.Items.Count > 0 Then
            If bayad1.Text > 0 Then
                compute()
                tohidead()
                printo()
                PrintDocument1.Print()
                Dim filename As String = Application.StartupPath & "/Reciept/" & My.Settings.recieptcount & ".txt"
                RichTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText)
                writetoimage()
                saveimg()
                addnew()
                savehisto()
                decreasestock()
                My.Settings.money += totalnglahat2.Text
                My.Settings.recieptcount += 1
                My.Settings.Save()
                ListBox1.Items.Clear()
                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                bayad1.Text = 0
                compute()
            Else
                MsgBox("Please Pay")
            End If

        Else
            MsgBox("nothing to checkout!")
        End If
    End Sub

    Private Sub addnew()
        SALEHISTORYBindingSource1.AddNew()
    End Sub

    Private Sub savehisto()
        ReceiptnoTextBox.Text = My.Settings.recieptcount
        DatesoldTextBox.Text = Datelbl.Text
        EmployeenameTextBox.Text = Username.Text
        ItemsoldTextBox.Text = ilangitem.Text
        TotalpriceTextBox.Text = totalnglahat2.Text
        CashTextBox.Text = bayad2.Text
        CashchangeTextBox.Text = sukli.Text
        Me.Validate()
        SALEHISTORYBindingSource1.EndEdit()
        SALEHISTORYTableAdapter2.Update(HierarchyHistoryDbDataSet)
    End Sub

    Private Sub printo()
        RichTextBox1.Clear()
        RichTextBox1.Text += "                                  " & My.Settings.storename &
            Environment.NewLine & "" &
            Environment.NewLine &
            "                              Store owned and operated" & Environment.NewLine &
            "                                       by LIMUEL D" & Environment.NewLine &
            "                              Lot 1A BLK 69 Bristol ST." & Environment.NewLine &
            "                            Fairview North, Quezon City" & Environment.NewLine

        RichTextBox1.Text += Environment.NewLine & "                                " & Datelbl.Text & Environment.NewLine & Environment.NewLine & "RCPT # " & My.Settings.recieptcount & Environment.NewLine & "                 " &
             "STORE #" & My.Settings.storename & Environment.NewLine &
             "STAFF # " & Username.Text & Environment.NewLine &
             "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ " & Environment.NewLine & Environment.NewLine


        If ListBox1.Items.Count > 0 Then
            For i = 0 To ListBox1.Items.Count - 1
                ListBox1.SelectedIndex = i
                Dim unangword As String = ListBox1.SelectedItem & "(" & ListBox3.SelectedItem & ")"
                Dim price As String = ListBox2.SelectedItem
                Dim spacecoun As Integer = 40
                Dim unacount As Integer = unangword.Length()
                Dim pangalawacount As Integer = price.Length()
                Dim pricelength = ListBox2.SelectedItem

                spacecoun = spacecoun - unacount
                ' MsgBox(spacecoun)
                RichTextBox1.Text += ListBox1.SelectedItem & "(" & ListBox3.SelectedItem & ")"
                For counter1 = 0 To spacecoun
                    RichTextBox1.Text += "-"
                    'MsgBox("added space" & counter1)
                Next
                RichTextBox1.Text += ListBox2.SelectedItem & Environment.NewLine
            Next
        End If
        Dim space As Integer = 40
        Dim vatablle As String = "VATable"
        Dim taxx As String = "TAX"
        Dim total As String = "TOTAL"
        Dim cash As String = "CASH"
        Dim change As String = "CHANGE"

        RichTextBox1.Text += Environment.NewLine & "_________________________________________________" & Environment.NewLine
        RichTextBox1.Text += "VATable                                        "
        'computespace(space, vatablle)
        RichTextBox1.Text += walapangtax.Text & Environment.NewLine
        RichTextBox1.Text += "TAX                                               "
        'computespace(space, taxx)
        RichTextBox1.Text += tax.Text & Environment.NewLine
        RichTextBox1.Text += "TOTAL                                          "
        ' computespace(space, total)
        RichTextBox1.Text += totalnglahat2.Text & Environment.NewLine
        RichTextBox1.Text += "CASH                                           "
        'computespace(space, cash)
        RichTextBox1.Text += bayad1.Text & Environment.NewLine
        RichTextBox1.Text += Environment.NewLine & "_________________________________________________" & Environment.NewLine
        RichTextBox1.Text += "CHANGE                                   "
        'computespace(space, change)
        RichTextBox1.Text += sukli.Text
        RichTextBox1.Text += Environment.NewLine & "_________________________________________________" & Environment.NewLine

        RichTextBox1.Text += LocationTextBox.Text & Environment.NewLine
        RichTextBox1.Text += ContactTextBox.Text & Environment.NewLine
        RichTextBox1.Text += CompanyTextBox.Text & Environment.NewLine
        RichTextBox1.Text += Message1TextBox.Text & Environment.NewLine
        RichTextBox1.Text += Massage2TextBox.Text & Environment.NewLine
    End Sub

    Private Sub computespace(a As Integer, b As String)
        Dim lengthh As Integer = a
        lengthh = lengthh - Val(b)
        For ii = 0 To lengthh
            RichTextBox1.Text += " "
            'MsgBox("fuck")
        Next
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ranchpanelhide()
        PrintPreviewDialog1 = New PrintPreviewDialog
        PrintPreviewDialog1.Document = PrintDocument1

        Dim sizengresibo As New System.Drawing.Printing.PaperSize("Custom Paper Size", 100, 300)
        PrintDocument1.DefaultPageSettings.PaperSize = sizengresibo
        PrintPreviewDialog1.Height = printdiaheight
        PrintPreviewDialog1.Width = printdiawidth
        PrintPreviewDialog1.Show()
    End Sub


    Private Sub pwddiscount_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles pwddiscount.CheckedChanged
        ranchpanelhide()
        compute()
    End Sub

    Private Sub nodiscount_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles nodiscount.CheckedChanged
        compute()
        ranchpanelhide()
    End Sub

    Dim printdiawidth As Integer = 400
    Dim printdiaheight As Integer = 600

    Public Sub writetoimage()
        printdiaheight += 15
        receiptoimage.Height += 20
        Dim b As New Drawing.Bitmap(printdiawidth, printdiaheight)
        Dim f As Graphics = Graphics.FromImage(b)
        f.Clear(Color.White)

        Dim font As New Font("Arial", 12, FontStyle.Regular)
        f.DrawString(RichTextBox1.Text, font, Brushes.Black, 1, 1)
        receiptoimage.Image = b
    End Sub

    Private Sub saveimg()
        receiptoimage.Image.Save(Application.StartupPath & "/Reciept/" & My.Settings.recieptcount & ".jpg")
    End Sub

    Private Sub qty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles qty.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub bayad1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bayad1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        hiddenranchpanel.Hide()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        hiddenranchpanel.Show()
    End Sub

    Dim qtybefore As Integer = 0

    Private Sub decreasestock()
        For ranchcounter = 0 To ListBox1.Items.Count - 1
            'MsgBox("The qty is cleared" & qtybefore)
            ListBox1.SelectedIndex = ranchcounter
            ranchsearch.Text = ListBox1.SelectedItem
            isear2()
            qtybefore = StockTextBox.Text
            'MsgBox("The qty is now " & qtybefore)
            StockTextBox.Text = qtybefore - Val(ListBox3.SelectedItem)
            'MsgBox("The qty in db is now " & qtybefore - Val(ListBox3.SelectedItem))
            Me.Validate()
            Me.ProductsBindingSource.EndEdit()
            Me.ProductsTableAdapter.Update(Me.HierarchyDbDataSet)
            ranchsearch.Clear()
            qtybefore = 0
        Next
        ProductsTableAdapter.Adapter.SelectCommand.CommandText = "Select * from products"
        Me.ProductsTableAdapter.Fill(Me.HierarchyDbDataSet.products)
    End Sub

    Private Sub isear2()
        ProductsTableAdapter.Adapter.SelectCommand.CommandText = "Select * from products where items like '%" & ranchsearch.Text & "%'"
        Me.ProductsTableAdapter.Fill(Me.HierarchyDbDataSet.products)
    End Sub

    Private Sub ranchsearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles ranchsearch.TextChanged

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Me.Close()
        Hierarchy_Admin_Form.Close()
        LoadingForm.Close()
        Lightlogin.Close()
    End Sub

    Private Sub ProductsDataGridView_Click(sender As System.Object, e As System.EventArgs) Handles ProductsDataGridView.Click
        hiddenranchpanel.Hide()
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Dim msg As MsgBoxResult
        msg = MsgBox("Do You Want to Sign Out Fuck?", vbYesNo)
        If msg = vbYes Then
            CashierSettings.Hide()
            SaleHistory.Hide()
            Adsform.Hide()
            Help.Hide()
            LoadingForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        CashierSettings.Show()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        SaleHistory.Show()
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Help.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

    End Sub

End Class
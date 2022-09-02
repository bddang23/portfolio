<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdering
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlReceipt = New System.Windows.Forms.Panel()
        Me.lstReceipt = New System.Windows.Forms.ListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.radDeluxe = New System.Windows.Forms.RadioButton()
        Me.radStandard = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.mtbPhone = New System.Windows.Forms.MaskedTextBox()
        Me.txtLast = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMiddle = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFirst = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.numAmount = New System.Windows.Forms.NumericUpDown()
        Me.pnlReceipt.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label9.Location = New System.Drawing.Point(130, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 30)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Receipt"
        '
        'pnlReceipt
        '
        Me.pnlReceipt.Controls.Add(Me.lstReceipt)
        Me.pnlReceipt.Controls.Add(Me.Label8)
        Me.pnlReceipt.Controls.Add(Me.Label9)
        Me.pnlReceipt.Location = New System.Drawing.Point(437, -1)
        Me.pnlReceipt.Name = "pnlReceipt"
        Me.pnlReceipt.Size = New System.Drawing.Size(355, 274)
        Me.pnlReceipt.TabIndex = 30
        Me.pnlReceipt.Visible = False
        '
        'lstReceipt
        '
        Me.lstReceipt.FormattingEnabled = True
        Me.lstReceipt.ItemHeight = 15
        Me.lstReceipt.Location = New System.Drawing.Point(14, 58)
        Me.lstReceipt.Name = "lstReceipt"
        Me.lstReceipt.Size = New System.Drawing.Size(328, 199)
        Me.lstReceipt.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(74, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(242, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "-----------------------------------------------"
        '
        'txtDiscount
        '
        Me.txtDiscount.Location = New System.Drawing.Point(23, 229)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(132, 23)
        Me.txtDiscount.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 15)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Discount (%)"
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btnReset.Location = New System.Drawing.Point(249, 223)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(88, 33)
        Me.btnReset.TabIndex = 27
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'btnCalc
        '
        Me.btnCalc.Location = New System.Drawing.Point(343, 223)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(88, 33)
        Me.btnCalc.TabIndex = 26
        Me.btnCalc.Text = "Calculate"
        Me.btnCalc.UseVisualStyleBackColor = True
        '
        'radDeluxe
        '
        Me.radDeluxe.AutoSize = True
        Me.radDeluxe.Location = New System.Drawing.Point(148, 37)
        Me.radDeluxe.Name = "radDeluxe"
        Me.radDeluxe.Size = New System.Drawing.Size(107, 34)
        Me.radDeluxe.TabIndex = 1
        Me.radDeluxe.TabStop = True
        Me.radDeluxe.Text = "Deluxe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "($10.00/Person)"
        Me.radDeluxe.UseVisualStyleBackColor = True
        '
        'radStandard
        '
        Me.radStandard.AutoSize = True
        Me.radStandard.Checked = True
        Me.radStandard.Location = New System.Drawing.Point(15, 37)
        Me.radStandard.Name = "radStandard"
        Me.radStandard.Size = New System.Drawing.Size(101, 34)
        Me.radStandard.TabIndex = 0
        Me.radStandard.TabStop = True
        Me.radStandard.Text = "Standard" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "($8.50/Person)"
        Me.radStandard.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radDeluxe)
        Me.GroupBox1.Controls.Add(Me.radStandard)
        Me.GroupBox1.Location = New System.Drawing.Point(161, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 104)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Catering Service Meal"
        '
        'mtbPhone
        '
        Me.mtbPhone.Location = New System.Drawing.Point(23, 124)
        Me.mtbPhone.Mask = "(999) 000-0000"
        Me.mtbPhone.Name = "mtbPhone"
        Me.mtbPhone.Size = New System.Drawing.Size(132, 23)
        Me.mtbPhone.TabIndex = 24
        '
        'txtLast
        '
        Me.txtLast.Location = New System.Drawing.Point(299, 79)
        Me.txtLast.Name = "txtLast"
        Me.txtLast.Size = New System.Drawing.Size(132, 23)
        Me.txtLast.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(299, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 15)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Last Name"
        '
        'txtMiddle
        '
        Me.txtMiddle.Location = New System.Drawing.Point(161, 79)
        Me.txtMiddle.Name = "txtMiddle"
        Me.txtMiddle.Size = New System.Drawing.Size(132, 23)
        Me.txtMiddle.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(161, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 15)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Middle Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Phone Number"
        '
        'txtFirst
        '
        Me.txtFirst.Location = New System.Drawing.Point(23, 79)
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(132, 23)
        Me.txtFirst.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(242, 15)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "-----------------------------------------------"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 15)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "First Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 30)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Order Form"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 156)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 15)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Amount"
        '
        'numAmount
        '
        Me.numAmount.Location = New System.Drawing.Point(23, 173)
        Me.numAmount.Name = "numAmount"
        Me.numAmount.Size = New System.Drawing.Size(132, 23)
        Me.numAmount.TabIndex = 33
        '
        'frmOrdering
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 268)
        Me.Controls.Add(Me.numAmount)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.pnlReceipt)
        Me.Controls.Add(Me.txtDiscount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnCalc)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.mtbPhone)
        Me.Controls.Add(Me.txtLast)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtMiddle)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFirst)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmOrdering"
        Me.Text = "frmOrdering"
        Me.pnlReceipt.ResumeLayout(False)
        Me.pnlReceipt.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents pnlReceipt As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDiscount As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents btnCalc As Button
    Friend WithEvents radDeluxe As RadioButton
    Friend WithEvents radStandard As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents mtbPhone As MaskedTextBox
    Friend WithEvents txtLast As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtMiddle As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFirst As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lstReceipt As ListBox
    Friend WithEvents Label10 As Label
    Friend WithEvents numAmount As NumericUpDown
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChezSousad_Dang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstDish = New System.Windows.Forms.ListBox()
        Me.btnDish = New System.Windows.Forms.Button()
        Me.txtDish = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstSelectedPrep = New System.Windows.Forms.ListBox()
        Me.lstPrepped = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPrepped = New System.Windows.Forms.TextBox()
        Me.btnPrepped = New System.Windows.Forms.Button()
        Me.lstRaw = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstSelectedRaw = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRaw = New System.Windows.Forms.TextBox()
        Me.btnRaw = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "List of all Dishes:"
        '
        'lstDish
        '
        Me.lstDish.FormattingEnabled = True
        Me.lstDish.ItemHeight = 16
        Me.lstDish.Location = New System.Drawing.Point(17, 32)
        Me.lstDish.Name = "lstDish"
        Me.lstDish.Size = New System.Drawing.Size(744, 100)
        Me.lstDish.TabIndex = 1
        '
        'btnDish
        '
        Me.btnDish.Location = New System.Drawing.Point(460, 147)
        Me.btnDish.Name = "btnDish"
        Me.btnDish.Size = New System.Drawing.Size(79, 47)
        Me.btnDish.TabIndex = 2
        Me.btnDish.Text = "Add New Dish"
        Me.btnDish.UseVisualStyleBackColor = True
        '
        'txtDish
        '
        Me.txtDish.Location = New System.Drawing.Point(551, 157)
        Me.txtDish.Name = "txtDish"
        Me.txtDish.Size = New System.Drawing.Size(209, 22)
        Me.txtDish.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Prepped items in Selected Dish:"
        '
        'lstSelectedPrep
        '
        Me.lstSelectedPrep.FormattingEnabled = True
        Me.lstSelectedPrep.ItemHeight = 16
        Me.lstSelectedPrep.Location = New System.Drawing.Point(17, 231)
        Me.lstSelectedPrep.Name = "lstSelectedPrep"
        Me.lstSelectedPrep.Size = New System.Drawing.Size(303, 100)
        Me.lstSelectedPrep.TabIndex = 5
        '
        'lstPrepped
        '
        Me.lstPrepped.FormattingEnabled = True
        Me.lstPrepped.ItemHeight = 16
        Me.lstPrepped.Location = New System.Drawing.Point(458, 231)
        Me.lstPrepped.Name = "lstPrepped"
        Me.lstPrepped.Size = New System.Drawing.Size(303, 100)
        Me.lstPrepped.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(455, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "List of all Prepped Items:"
        '
        'txtPrepped
        '
        Me.txtPrepped.Location = New System.Drawing.Point(552, 354)
        Me.txtPrepped.Name = "txtPrepped"
        Me.txtPrepped.Size = New System.Drawing.Size(209, 22)
        Me.txtPrepped.TabIndex = 9
        '
        'btnPrepped
        '
        Me.btnPrepped.Location = New System.Drawing.Point(460, 337)
        Me.btnPrepped.Name = "btnPrepped"
        Me.btnPrepped.Size = New System.Drawing.Size(79, 64)
        Me.btnPrepped.TabIndex = 8
        Me.btnPrepped.Text = "Add New Prepped Item"
        Me.btnPrepped.UseVisualStyleBackColor = True
        '
        'lstRaw
        '
        Me.lstRaw.FormattingEnabled = True
        Me.lstRaw.ItemHeight = 16
        Me.lstRaw.Location = New System.Drawing.Point(458, 449)
        Me.lstRaw.Name = "lstRaw"
        Me.lstRaw.Size = New System.Drawing.Size(303, 100)
        Me.lstRaw.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(455, 419)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "List of all Raw Ingredient:"
        '
        'lstSelectedRaw
        '
        Me.lstSelectedRaw.FormattingEnabled = True
        Me.lstSelectedRaw.ItemHeight = 16
        Me.lstSelectedRaw.Location = New System.Drawing.Point(18, 449)
        Me.lstSelectedRaw.Name = "lstSelectedRaw"
        Me.lstSelectedRaw.Size = New System.Drawing.Size(303, 100)
        Me.lstSelectedRaw.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 419)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(209, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Prepped items in Selected Dish:"
        '
        'txtRaw
        '
        Me.txtRaw.Location = New System.Drawing.Point(552, 572)
        Me.txtRaw.Name = "txtRaw"
        Me.txtRaw.Size = New System.Drawing.Size(209, 22)
        Me.txtRaw.TabIndex = 15
        '
        'btnRaw
        '
        Me.btnRaw.Location = New System.Drawing.Point(461, 562)
        Me.btnRaw.Name = "btnRaw"
        Me.btnRaw.Size = New System.Drawing.Size(79, 47)
        Me.btnRaw.TabIndex = 14
        Me.btnRaw.Text = "Add New Raw Ingr"
        Me.btnRaw.UseVisualStyleBackColor = True
        '
        'ChezSousad_Dang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 620)
        Me.Controls.Add(Me.txtRaw)
        Me.Controls.Add(Me.btnRaw)
        Me.Controls.Add(Me.lstSelectedRaw)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lstRaw)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPrepped)
        Me.Controls.Add(Me.btnPrepped)
        Me.Controls.Add(Me.lstPrepped)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lstSelectedPrep)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDish)
        Me.Controls.Add(Me.btnDish)
        Me.Controls.Add(Me.lstDish)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ChezSousad_Dang"
        Me.Text = "Chez SouSad"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lstDish As ListBox
    Friend WithEvents btnDish As Button
    Friend WithEvents txtDish As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lstSelectedPrep As ListBox
    Friend WithEvents lstPrepped As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPrepped As TextBox
    Friend WithEvents btnPrepped As Button
    Friend WithEvents lstRaw As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lstSelectedRaw As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRaw As TextBox
    Friend WithEvents btnRaw As Button
End Class

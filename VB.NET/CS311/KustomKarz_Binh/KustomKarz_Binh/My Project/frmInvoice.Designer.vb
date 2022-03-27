<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoice
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
        Me.lstInvoice = New System.Windows.Forms.ListBox()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstInvoice
        '
        Me.lstInvoice.FormattingEnabled = True
        Me.lstInvoice.ItemHeight = 16
        Me.lstInvoice.Location = New System.Drawing.Point(12, 12)
        Me.lstInvoice.Name = "lstInvoice"
        Me.lstInvoice.Size = New System.Drawing.Size(615, 436)
        Me.lstInvoice.TabIndex = 0
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(12, 471)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(185, 59)
        Me.btnChange.TabIndex = 1
        Me.btnChange.Text = "Change Order"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(237, 471)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(185, 59)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "Submit to Manufacturing"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(442, 471)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(185, 59)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(641, 553)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.lstInvoice)
        Me.Name = "frmInvoice"
        Me.Text = "Kustom Karz Invoice"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstInvoice As ListBox
    Friend WithEvents btnChange As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
End Class

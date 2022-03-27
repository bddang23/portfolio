<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrder
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
        Me.btnPlaceOrder = New System.Windows.Forms.Button()
        Me.chkBluetooth = New System.Windows.Forms.CheckBox()
        Me.chkCD = New System.Windows.Forms.CheckBox()
        Me.chkStereo = New System.Windows.Forms.CheckBox()
        Me.chkRear = New System.Windows.Forms.CheckBox()
        Me.chkAir = New System.Windows.Forms.CheckBox()
        Me.chkHeated = New System.Windows.Forms.CheckBox()
        Me.optElect = New System.Windows.Forms.RadioButton()
        Me.optHybrid = New System.Windows.Forms.RadioButton()
        Me.optV4 = New System.Windows.Forms.RadioButton()
        Me.optV6 = New System.Windows.Forms.RadioButton()
        Me.chkEvt = New System.Windows.Forms.CheckBox()
        Me.chkGPS = New System.Windows.Forms.CheckBox()
        Me.optV8 = New System.Windows.Forms.RadioButton()
        Me.optV12 = New System.Windows.Forms.RadioButton()
        Me.chkLeather = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstType = New System.Windows.Forms.ListBox()
        Me.nudQuantity = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPlaceOrder
        '
        Me.btnPlaceOrder.Location = New System.Drawing.Point(15, 329)
        Me.btnPlaceOrder.Name = "btnPlaceOrder"
        Me.btnPlaceOrder.Size = New System.Drawing.Size(514, 51)
        Me.btnPlaceOrder.TabIndex = 17
        Me.btnPlaceOrder.Text = "Place Car(s) Order"
        Me.btnPlaceOrder.UseVisualStyleBackColor = True
        '
        'chkBluetooth
        '
        Me.chkBluetooth.AutoSize = True
        Me.chkBluetooth.Location = New System.Drawing.Point(329, 21)
        Me.chkBluetooth.Name = "chkBluetooth"
        Me.chkBluetooth.Size = New System.Drawing.Size(90, 21)
        Me.chkBluetooth.TabIndex = 5
        Me.chkBluetooth.Text = "Bluetooth"
        Me.chkBluetooth.UseVisualStyleBackColor = True
        '
        'chkCD
        '
        Me.chkCD.AutoSize = True
        Me.chkCD.Location = New System.Drawing.Point(158, 99)
        Me.chkCD.Name = "chkCD"
        Me.chkCD.Size = New System.Drawing.Size(163, 21)
        Me.chkCD.TabIndex = 4
        Me.chkCD.Text = "CD/MP3 Connections"
        Me.chkCD.UseVisualStyleBackColor = True
        '
        'chkStereo
        '
        Me.chkStereo.AutoSize = True
        Me.chkStereo.Location = New System.Drawing.Point(158, 59)
        Me.chkStereo.Name = "chkStereo"
        Me.chkStereo.Size = New System.Drawing.Size(131, 21)
        Me.chkStereo.TabIndex = 3
        Me.chkStereo.Text = "Premium Stereo"
        Me.chkStereo.UseVisualStyleBackColor = True
        '
        'chkRear
        '
        Me.chkRear.AutoSize = True
        Me.chkRear.Location = New System.Drawing.Point(14, 99)
        Me.chkRear.Name = "chkRear"
        Me.chkRear.Size = New System.Drawing.Size(124, 21)
        Me.chkRear.TabIndex = 2
        Me.chkRear.Text = "Rear Defroster"
        Me.chkRear.UseVisualStyleBackColor = True
        '
        'chkAir
        '
        Me.chkAir.AutoSize = True
        Me.chkAir.Location = New System.Drawing.Point(158, 21)
        Me.chkAir.Name = "chkAir"
        Me.chkAir.Size = New System.Drawing.Size(129, 21)
        Me.chkAir.TabIndex = 2
        Me.chkAir.Text = "Air Conditioning"
        Me.chkAir.UseVisualStyleBackColor = True
        '
        'chkHeated
        '
        Me.chkHeated.AutoSize = True
        Me.chkHeated.Location = New System.Drawing.Point(14, 59)
        Me.chkHeated.Name = "chkHeated"
        Me.chkHeated.Size = New System.Drawing.Size(116, 21)
        Me.chkHeated.TabIndex = 1
        Me.chkHeated.Text = "Heated Seats"
        Me.chkHeated.UseVisualStyleBackColor = True
        '
        'optElect
        '
        Me.optElect.AutoSize = True
        Me.optElect.Location = New System.Drawing.Point(417, 21)
        Me.optElect.Name = "optElect"
        Me.optElect.Size = New System.Drawing.Size(75, 21)
        Me.optElect.TabIndex = 5
        Me.optElect.Text = "Electric"
        Me.optElect.UseVisualStyleBackColor = True
        '
        'optHybrid
        '
        Me.optHybrid.AutoSize = True
        Me.optHybrid.Location = New System.Drawing.Point(329, 21)
        Me.optHybrid.Name = "optHybrid"
        Me.optHybrid.Size = New System.Drawing.Size(70, 21)
        Me.optHybrid.TabIndex = 4
        Me.optHybrid.Text = "Hybrid"
        Me.optHybrid.UseVisualStyleBackColor = True
        '
        'optV4
        '
        Me.optV4.AutoSize = True
        Me.optV4.Location = New System.Drawing.Point(255, 21)
        Me.optV4.Name = "optV4"
        Me.optV4.Size = New System.Drawing.Size(51, 21)
        Me.optV4.TabIndex = 3
        Me.optV4.Text = "V-4"
        Me.optV4.UseVisualStyleBackColor = True
        '
        'optV6
        '
        Me.optV6.AutoSize = True
        Me.optV6.Location = New System.Drawing.Point(176, 21)
        Me.optV6.Name = "optV6"
        Me.optV6.Size = New System.Drawing.Size(51, 21)
        Me.optV6.TabIndex = 2
        Me.optV6.Text = "V-6"
        Me.optV6.UseVisualStyleBackColor = True
        '
        'chkEvt
        '
        Me.chkEvt.AutoSize = True
        Me.chkEvt.Location = New System.Drawing.Point(329, 99)
        Me.chkEvt.Name = "chkEvt"
        Me.chkEvt.Size = New System.Drawing.Size(177, 21)
        Me.chkEvt.TabIndex = 7
        Me.chkEvt.Text = "Entertainment Package"
        Me.chkEvt.UseVisualStyleBackColor = True
        '
        'chkGPS
        '
        Me.chkGPS.AutoSize = True
        Me.chkGPS.Location = New System.Drawing.Point(329, 59)
        Me.chkGPS.Name = "chkGPS"
        Me.chkGPS.Size = New System.Drawing.Size(59, 21)
        Me.chkGPS.TabIndex = 6
        Me.chkGPS.Text = "GPS"
        Me.chkGPS.UseVisualStyleBackColor = True
        '
        'optV8
        '
        Me.optV8.AutoSize = True
        Me.optV8.Location = New System.Drawing.Point(97, 21)
        Me.optV8.Name = "optV8"
        Me.optV8.Size = New System.Drawing.Size(51, 21)
        Me.optV8.TabIndex = 1
        Me.optV8.Text = "V-8"
        Me.optV8.UseVisualStyleBackColor = True
        '
        'optV12
        '
        Me.optV12.AutoSize = True
        Me.optV12.Location = New System.Drawing.Point(12, 21)
        Me.optV12.Name = "optV12"
        Me.optV12.Size = New System.Drawing.Size(59, 21)
        Me.optV12.TabIndex = 0
        Me.optV12.Text = "V-12"
        Me.optV12.UseVisualStyleBackColor = True
        '
        'chkLeather
        '
        Me.chkLeather.AutoSize = True
        Me.chkLeather.Location = New System.Drawing.Point(14, 21)
        Me.chkLeather.Name = "chkLeather"
        Me.chkLeather.Size = New System.Drawing.Size(119, 21)
        Me.chkLeather.TabIndex = 0
        Me.chkLeather.Text = "Leather Seats"
        Me.chkLeather.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkEvt)
        Me.GroupBox2.Controls.Add(Me.chkGPS)
        Me.GroupBox2.Controls.Add(Me.chkBluetooth)
        Me.GroupBox2.Controls.Add(Me.chkCD)
        Me.GroupBox2.Controls.Add(Me.chkStereo)
        Me.GroupBox2.Controls.Add(Me.chkRear)
        Me.GroupBox2.Controls.Add(Me.chkAir)
        Me.GroupBox2.Controls.Add(Me.chkHeated)
        Me.GroupBox2.Controls.Add(Me.chkLeather)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 160)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(514, 147)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options : "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optElect)
        Me.GroupBox1.Controls.Add(Me.optHybrid)
        Me.GroupBox1.Controls.Add(Me.optV4)
        Me.GroupBox1.Controls.Add(Me.optV6)
        Me.GroupBox1.Controls.Add(Me.optV8)
        Me.GroupBox1.Controls.Add(Me.optV12)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 103)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 51)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Driver Train Selection :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(296, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Quantity : "
        '
        'lstType
        '
        Me.lstType.DisplayMember = "Coupe"
        Me.lstType.FormattingEnabled = True
        Me.lstType.HorizontalScrollbar = True
        Me.lstType.ItemHeight = 16
        Me.lstType.Items.AddRange(New Object() {"Coupe", "Luxury", "Sedan", "Sports Edition", "SUV"})
        Me.lstType.Location = New System.Drawing.Point(92, 44)
        Me.lstType.Name = "lstType"
        Me.lstType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstType.Size = New System.Drawing.Size(132, 36)
        Me.lstType.TabIndex = 10
        '
        'nudQuantity
        '
        Me.nudQuantity.Location = New System.Drawing.Point(387, 58)
        Me.nudQuantity.Name = "nudQuantity"
        Me.nudQuantity.Size = New System.Drawing.Size(120, 22)
        Me.nudQuantity.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Car Type :"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(133, 12)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(374, 22)
        Me.txtName.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Customer Name :"
        '
        'frmOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 394)
        Me.Controls.Add(Me.btnPlaceOrder)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lstType)
        Me.Controls.Add(Me.nudQuantity)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmOrder"
        Me.Text = "Kustom Karz Order Form"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPlaceOrder As Button
    Friend WithEvents chkBluetooth As CheckBox
    Friend WithEvents chkCD As CheckBox
    Friend WithEvents chkStereo As CheckBox
    Friend WithEvents chkRear As CheckBox
    Friend WithEvents chkAir As CheckBox
    Friend WithEvents chkHeated As CheckBox
    Friend WithEvents optElect As RadioButton
    Friend WithEvents optHybrid As RadioButton
    Friend WithEvents optV4 As RadioButton
    Friend WithEvents optV6 As RadioButton
    Friend WithEvents chkEvt As CheckBox
    Friend WithEvents chkGPS As CheckBox
    Friend WithEvents optV8 As RadioButton
    Friend WithEvents optV12 As RadioButton
    Friend WithEvents chkLeather As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents nudQuantity As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label1 As Label
    Public WithEvents lstType As ListBox
End Class
